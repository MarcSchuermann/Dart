// -----------------------------------------------------------------------
// <copyright file="MainWindowView.xaml.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using ControlzEx.Theming;
using MahApps.Metro.Controls;
using Schuermann.Dart.App.Common.UserInterface.PlugInsDialog;
using Schuermann.Dart.App.Common.Utils;
using Schuermann.Dart.App.Game.Interfaces;
using Schuermann.Dart.App.Game.UserInterface.ViewModels;
using Schuermann.Dart.App.Settings.UserInterface.ViewModels;
using Schuermann.Dart.App.Tools.ExceptionHandling;
using Schuermann.Dart.App.Tools.IconSetter;
using Schuermann.Dart.Core.Service;

namespace Schuermann.Dart.App.Game.UserInterface.Views
{
   /// <summary>The MainWindow.</summary>
   /// <seealso cref="System.Windows.Window" />
   /// <seealso cref="System.Windows.Markup.IComponentConnector" />
   public partial class MainWindowView : MetroWindow
   {
      #region Public Constructors

      /// <summary>
      ///    Initializes a new instance of the <see cref="MainWindowView" /> class.
      /// </summary>
      public MainWindowView()
      {
         AttachToCatchUnhaendledExceptions();

         Common.Splashscreen.SplashScreen.ShowSplashScreen();

         InitializeComponent();
         InitServices();
         IconSetter.SetProgramsIcon();
         LoadUserSettings();

         SubscribeToSettingsChangedEvent();

         Common.Splashscreen.SplashScreen.HideSplashScreen();

         if (DataContext is MainWindowViewModel mainWindowViewModel)
         {
            HamburgerMenuControl.Content = mainWindowViewModel.CurrentContent;
            mainWindowViewModel.GameStarted += MainWindowViewModel_GameStarted;

            KeyDown += MainWindowView_KeyDown;
         }

         //InitMef();
      }

      private void InitServices()
      {
         ServiceProvider.Instance.Add(new ThrowGameService());
         if (DataContext is MainWindowViewModel mainWindowViewModel)
            ServiceProvider.Instance.Add(new EnvironmentService(mainWindowViewModel.CurrentProperties));
      }

      #endregion Public Constructors

      #region Protected Methods

      /// <summary>Raises the <see cref="E:System.Windows.Window.Closing" /> event.</summary>
      /// <param name="e">
      ///    A <see cref="T:System.ComponentModel.CancelEventArgs" /> that contains the event data.
      /// </param>
      protected override void OnClosing(CancelEventArgs e)
      {
         base.OnClosing(e);
         Properties.Settings.Default.WindowHeight = Height;
         Properties.Settings.Default.WindowWidth = Width;
         Properties.Settings.Default.WindowState = WindowState;
         Properties.Settings.Default.WindowTop = Top;
         Properties.Settings.Default.WindowLeft = Left;

         Properties.Settings.Default.Save();
      }

      #endregion Protected Methods

      #region Private Methods

      private void AppDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
      {
         var exceptionCatchWindow = new ExceptionCatchWindow(e);
         exceptionCatchWindow.ShowDialog();
      }

      private void AttachToCatchUnhaendledExceptions()
      {
         AppDomain currentDomain = AppDomain.CurrentDomain;
         currentDomain.UnhandledException += AppDomain_UnhandledException;
      }

      private void HamburgerMenuControl_OnItemInvoked(object sender, HamburgerMenuItemInvokedEventArgs e)
      {
         if (DataContext is MainWindowViewModel mainWindowViewModel)
         {
            if (e.InvokedItem is HamburgerMenuGlyphItem menuItem)
            {
               switch (menuItem.Tag.ToString())
               {
                  case "settings":
                     mainWindowViewModel.CurrentContent = mainWindowViewModel.SettingsViewModel;
                     HamburgerMenuControl.Content = (DataContext as MainWindowViewModel).CurrentContent;
                     break;

                  case "throwgame":
                     mainWindowViewModel.CurrentContent = new GameOptionsViewModel();
                     HamburgerMenuControl.Content = (DataContext as MainWindowViewModel).CurrentContent;
                     break;
               }
            }
            if (e.InvokedItem is HamburgerMenuIconItem menuIconItem)
            {
               switch (menuIconItem.Tag.ToString())
               {
                  case "info":
                     mainWindowViewModel.CurrentContent = null;
                     HamburgerMenuControl.Content = "TODO";
                     break;
               }
            }
         }

         if (!e.IsItemOptions && HamburgerMenuControl.IsPaneOpen)
            HamburgerMenuControl.SetCurrentValue(HamburgerMenu.IsPaneOpenProperty, false);
      }

      private void InitMef()
      {
         try
         {
            // An aggregate catalog that combines multiple catalogs.
            var catalog = new AggregateCatalog();
            // Adds all the parts found in the same assembly as the Program class.
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(MainWindowView).Assembly));

            // Create the CompositionContainer with the parts in the catalog.
            var _container = new CompositionContainer(catalog);
            _container.ComposeParts(this);
         }
         catch (CompositionException compositionException)
         {
            Console.WriteLine(compositionException.ToString());
         }
      }

      private void LoadUserSettings()
      {
         Height = Properties.Settings.Default.WindowHeight;
         Width = Properties.Settings.Default.WindowWidth;
         WindowState = Properties.Settings.Default.WindowState;
         Top = Properties.Settings.Default.WindowTop;
         Left = Properties.Settings.Default.WindowLeft;

         CultureInfo.CurrentCulture = Properties.Settings.Default.CurrentCulture;
         CultureInfo.CurrentUICulture = Properties.Settings.Default.CurrentCulture;

         ThemeManager.Current.ChangeTheme(this, $"{Properties.Settings.Default.BaseColorScheme}.{Properties.Settings.Default.ColorScheme}");
      }

      private void MainWindowView_KeyDown(object sender, KeyEventArgs e)
      {
         if (!(DataContext is MainWindowViewModel mainWindowViewModel))
            return;

         // Safe
         if (KeyboardUtils.IsCtrlPressed() && Keyboard.IsKeyDown(Key.S))
         {
            mainWindowViewModel.ShowSaveDialog();
            return;
         }

         // Load
         if (KeyboardUtils.IsCtrlPressed() && Keyboard.IsKeyDown(Key.L))
         {
            var loadedMainWindowViewModel = mainWindowViewModel.ShowLoadDialog();

            mainWindowViewModel.CurrentContent = loadedMainWindowViewModel.CurrentContent;
            HamburgerMenuControl.Content = loadedMainWindowViewModel.CurrentContent;

            return;
         }

         // Undo
         if (KeyboardUtils.IsCtrlPressed() && Keyboard.IsKeyDown(Key.Z) && !KeyboardUtils.IsShiftPressed())
         {
            if (mainWindowViewModel.CurrentContent is DartGameViewModel dartGameViewModel)
            {
               var throwGameService = ServiceProvider.Instance.Get<IThrowGameService>() as IThrowGameService;
               throwGameService.GetGameProcedure().Undo();
               dartGameViewModel.UpdatePlayers();
            }

            return;
         }

         // Redo
         if (KeyboardUtils.IsCtrlPressed() && Keyboard.IsKeyDown(Key.Z) && KeyboardUtils.IsShiftPressed())
         {
            if (mainWindowViewModel.CurrentContent is DartGameViewModel dartGameViewModel)
            {
               var throwGameService = ServiceProvider.Instance.Get<IThrowGameService>() as IThrowGameService;
               throwGameService.GetGameProcedure().Redo();
               dartGameViewModel.UpdatePlayers();
            }

            return;
         }

         // Open PlugIn Window
         if (KeyboardUtils.IsCtrlPressed() && Keyboard.IsKeyDown(Key.E) && Keyboard.IsKeyDown(Key.A))
         {
            DartGameViewModel dartGameViewModel = new DartGameViewModel(mainWindowViewModel);
            //mainWindowViewModel.LoadPlugIns();

            var plugInsDialog = new PlugInsDialog(mainWindowViewModel.PlugIns);
            plugInsDialog.ShowDialog();

            return;
         }

         // Open PlugIns
         if (KeyboardUtils.IsCtrlPressed() && Keyboard.IsKeyDown(Key.E) && KeyboardUtils.IsNumberPressed())
         {
            for (var i = 0; i <= mainWindowViewModel.PlugIns.Count(); i++)
            {
               if (KeyboardUtils.IsNumberPressed(i))
               {
                  if (mainWindowViewModel.PlugIns.Count() > i)
                  {
                     //mainWindowViewModel.PlugIns.ElementAt(i).GameOptions = mainWindowViewModel.ConfiguredGameOptions;
                     mainWindowViewModel.PlugIns.ElementAt(i).PlugInCommand.OnExecute();
                  }
               }
            }
         }

         InvalidateVisual();
      }

      private void MainWindowViewModel_GameStarted(object sender, EventArgs e)
      {
         HamburgerMenuControl.Content = (DataContext as MainWindowViewModel).CurrentContent;
      }

      private void SetTheme(object sender)
      {
         if (sender is ApplicationSettingsViewModel applicationSettingsViewModel)
         {
            ThemeManager.Current.ChangeTheme(this, applicationSettingsViewModel.CurrentTheme.OriginalTheme);
         }
      }

      private void SettingsViewModel_LanguageChangedEvent(object sender, EventArgs args)
      {
         if (DataContext is ICloneable mainWindowViewModel)
         {
            var clone = mainWindowViewModel.Clone();
            DataContext = null;
            UpdateLayout();
            InvalidateVisual();
            DataContext = clone;
         }
      }

      private void SubscribeToSettingsChangedEvent()
      {
         if (DataContext is IMainWindowViewModel mainWindowViewModel)
         {
            mainWindowViewModel.SettingsViewModel.PropertyChanged += SettingsViewModel_LanguageChangedEvent;
         }
      }

      #endregion Private Methods
   }
}
