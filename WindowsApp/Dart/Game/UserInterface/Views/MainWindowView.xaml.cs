// -----------------------------------------------------------------------
// <copyright file="MainWindowView.xaml.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using ControlzEx.Theming;
using Dart.Common.UserInterface.PlugInsDialog;
using Dart.Tools;
using Dart.Tools.ExceptionHandling;
using MahApps.Metro.Controls;

namespace Dart
{
   /// <summary>The MainWindow.</summary>
   /// <seealso cref="System.Windows.Window" />
   /// <seealso cref="System.Windows.Markup.IComponentConnector" />
   [ExcludeFromCodeCoverage]
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
         IconSetter.SetProgramsIcon();
         LoadUserSettings();

         SubscribeToSettingsChangedEvent();

         //Thread.Sleep(1500);

         Common.Splashscreen.SplashScreen.HideSplashScreen();

         if (DataContext is MainWindowViewModel mainWindowViewModel)
         {
            HamburgerMenuControl.Content = mainWindowViewModel.CurrentContent;
            mainWindowViewModel.GameStarted += MainWindowViewModel_GameStarted;

            KeyDown += MainWindowView_KeyDown;
         }
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

      private static bool IsCtrlPressed()
      {
         return (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl));
      }

      private static bool IsNumberPressed(int number)
      {
         if (number == 0)
            return Keyboard.IsKeyDown(Key.D0);

         if (number == 1)
            return Keyboard.IsKeyDown(Key.D1);

         if (number == 2)
            return Keyboard.IsKeyDown(Key.D2);

         if (number == 3)
            return Keyboard.IsKeyDown(Key.D4);

         return false;
      }

      private static bool IsShiftPressed()
      {
         return Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift);
      }

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
         // Safe
         if (IsCtrlPressed() && Keyboard.IsKeyDown(Key.S))
         {
            ((MainWindowViewModel)DataContext)?.ShowSaveDialog();
         }

         // Load
         if (IsCtrlPressed() && Keyboard.IsKeyDown(Key.L))
         {
            var loadedMainWindowViewModel = ((MainWindowViewModel)DataContext).ShowLoadDialog();

            if (DataContext is MainWindowViewModel mainWindowViewModel)
            {
               mainWindowViewModel.CurrentContent = loadedMainWindowViewModel.CurrentContent;
               HamburgerMenuControl.Content = loadedMainWindowViewModel.CurrentContent;
            }
         }

         // Undo
         if (IsCtrlPressed() && Keyboard.IsKeyDown(Key.Z) && !IsShiftPressed())
         {
            if (DataContext is MainWindowViewModel mainWindowViewModel)
            {
               if (mainWindowViewModel.CurrentContent is DartGameViewModel dartGameViewModel)
               {
                  dartGameViewModel.Game.Undo();
                  dartGameViewModel.UpdatePlayers();
               }
            }
         }

         // Redo
         if (IsCtrlPressed() && Keyboard.IsKeyDown(Key.Z) && IsShiftPressed())
         {
            if (DataContext is MainWindowViewModel mainWindowViewModel)
            {
               if (mainWindowViewModel.CurrentContent is DartGameViewModel dartGameViewModel)
               {
                  dartGameViewModel.Game.Redo();
                  dartGameViewModel.UpdatePlayers();
               }
            }
         }

         if (DataContext is MainWindowViewModel mainWindowViewModel2)
         {
            mainWindowViewModel2.LoadPlugIns();

            // Open PlugIn Window
            if (IsCtrlPressed() && Keyboard.IsKeyDown(Key.E) && Keyboard.IsKeyDown(Key.A))
            {
               var plugInsDialog = new PlugInsDialog(mainWindowViewModel2.PlugIns);
               plugInsDialog.ShowDialog();
            }

            // Open PlugIns
            for (var i = 0; i <= mainWindowViewModel2.PlugIns.Count(); i++)
            {
               if (IsCtrlPressed() && Keyboard.IsKeyDown(Key.E) && IsNumberPressed(i))
               {
                  if (mainWindowViewModel2.PlugIns.Count() > i)
                  {
                     mainWindowViewModel2.PlugIns.ElementAt(i).GameOptions = mainWindowViewModel2.ConfiguredGameOptions;
                     mainWindowViewModel2.PlugIns.ElementAt(i).PlugInCommand.OnExecute();
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