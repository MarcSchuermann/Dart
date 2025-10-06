// -----------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using ControlzEx.Theming;
using Microsoft.Win32;
using Schuermann.Dart.Core.Game;
using Schuermann.Dart.Core.EnvironmentProps;
using Schuermann.Dart.Core.Extensibility;
using Schuermann.Dart.Core.Save;
using Schuermann.Dart.App.Settings.UserInterface.ViewModels;
using Schuermann.Dart.App.Common.UserInterface.ViewModels;
using Schuermann.Dart.App.Game.Interfaces;
using Schuermann.Dart.App.Common.UserInterface.Interfaces;
using Schuermann.Dart.App.Settings.Interfaces;
using Schuermann.Dart.App.Common.Theme;
using Schuermann.Dart.App.Common.PlugIns;
using Schuermann.Dart.App.Common.Commands;
using Schuermann.Dart.App.Settings;
using Schuermann.Dart.Core.Service;

namespace Schuermann.Dart.App.Game.UserInterface.ViewModels
{
   /// <summary>The MainWindowViewModel.</summary>
   public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel, ICloneable
   {
      #region Private Fields

#if (Configuration == Develop)
      private string path = @"D:\_gitHub\Dart\Extensions\Charts\Schuermann.Dart.Charts\bin\Develop\net6.0-windows";
#else
            string path = @"D:\_gitHub\Dart\Extensions\Charts\Schuermann.Dart.Charts\bin\Debug\net6.0-windows\";
#endif




      private readonly Predicate<object> canStart = (currentContent) =>
                                                               {
                                                                  if (currentContent is not GameOptionsViewModel currentGameOptions || currentGameOptions.GameSettings == null)
                                                                     return false;

                                                                  if (string.IsNullOrWhiteSpace(currentGameOptions.GameSettings.SelectedPlayerCount))
                                                                     return false;

                                                                  if (string.IsNullOrWhiteSpace(currentGameOptions.GameSettings.SelectedStartPoints))
                                                                     return false;

                                                                  foreach (var player in currentGameOptions.Playerlist)
                                                                  {
                                                                     if (player.Name == null || player.Name.Length < 3)
                                                                        return false;
                                                                  }

                                                                  return true;
                                                               };

      private IViewModelBase currentContent;

      #endregion Private Fields


      #region Public Constructors

      /// <summary>
      ///    Initializes a new instance of the <see cref="MainWindowViewModel" /> class.
      /// </summary>
      public MainWindowViewModel()
      {
         CurrentContent = new GameOptionsViewModel();

         SettingsViewModel = new ApplicationSettingsViewModel(GetSettings());
         SettingsViewModel.PropertyChanged += SettingsPropertyChanged;

         SetCulture(SettingsViewModel.CurrentApplicationSettings.SelectedCultureInfo);

         CurrentProperties = new Core.EnvironmentProps.Properties(SettingsViewModel.CurrentApplicationSettings.CurrentTheme.OriginalTheme.Name, SettingsViewModel.CurrentApplicationSettings.SelectedCultureInfo);

         var plugInLoader = new PlugInLoader(path);
         PlugIns = plugInLoader.LoadPlugIns();
      }

      #endregion Public Constructors

      #region Public Events

      /// <summary>Occurs when [game started].</summary>
      public event EventHandler<EventArgs> GameStarted;

      #endregion Public Events

      #region Public Properties

      /// <summary>Gets or sets the configured game options.</summary>
      /// <value>The configured game options.</value>
      public IGameOptions ConfiguredGameOptions { get; set; }

      /// <summary>Gets or sets the content of the current.</summary>
      /// <value>The content of the current.</value>
      public IViewModelBase CurrentContent
      {
         get => currentContent;

         set
         {
            if (currentContent == value)
               return;

            currentContent = value;
            RaisePropertyChanged(nameof(CurrentContent));
         }
      }

      /// <summary>Gets the properties.</summary>
      /// <value>The properties.</value>
      //[Export(typeof(IProperties))]
      public IProperties CurrentProperties { get; private set; }

      /// <summary>Gets or sets the plug ins.</summary>
      /// <value>The plug ins.</value>
      //[ImportMany(AllowRecomposition = true)]
      public IEnumerable<IPlugIn> PlugIns { get; set; }

      /// <summary>Gets the settings view model.</summary>
      /// <value>The settings view model.</value>
      public IApplicationSettingsViewModel SettingsViewModel { get; }

      /// <summary>Gets the start game.</summary>
      /// <value>The start game.</value>
      public ICommand StartGame => new RelayCommand(x => StartDartGame(), canStart);

      #endregion Public Properties

      #region Public Methods

      /// <summary>Sets the culture.</summary>
      public static void SetCulture(CultureInfo cultureInfo)
      {
         Thread.CurrentThread.CurrentCulture = cultureInfo;
         Thread.CurrentThread.CurrentUICulture = cultureInfo;
      }

      /// <summary>Creates a new object that is a copy of the current instance.</summary>
      /// <returns>A new object that is a copy of this instance.</returns>
      public object Clone()
      {
         return MemberwiseClone();
      }

      /// <summary>Shows the load dialog.</summary>
      public MainWindowViewModel ShowLoadDialog()
      {
         // Create OpenFileDialog
         var dlg = new OpenFileDialog
         {
            // Set filter for file extension and default file extension
            DefaultExt = ".dart",
            Filter = "Dart save games (*.dart)|*.dart"
         };

         // Display OpenFileDialog by calling ShowDialog method
         var result = dlg.ShowDialog();

         // Get the selected file name and display in a TextBox
         if (result == true)
         {
            // Open document
            string filename = dlg.FileName;
            using var fs = new FileStream(filename, FileMode.Open);
            var gameInstance = Persister.Load(fs);
            ConfiguredGameOptions = gameInstance.GameOptions;
            CurrentContent = new DartGameViewModel(this);
         }

         return this;
      }

      /// <summary>Shows the save dialog.</summary>
      public void ShowSaveDialog()
      {
         var saveFileDialog = new SaveFileDialog
         {
            DefaultExt = ".dart",
            AddExtension = true,
            CheckPathExists = true,
            Title = Properties.Resources.Save,
            Filter = "Dart save games (*.dart)|*.dart",
            FileName = $"game_{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}"
         };

         if (saveFileDialog.ShowDialog() == true)
         {
            var instance = new GameInstance(ConfiguredGameOptions);
            var instanceStream = Persister.Save(instance);

            using var fileStream = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate);
            instanceStream.CopyTo(fileStream);
         }
      }

      #endregion Public Methods

      #region Private Methods

      private static INamedTheme GetCurrentTheme()
      {
         return new NamedTheme(ThemeManager.Current.Themes.FirstOrDefault(x => x.BaseColorScheme == Properties.Settings.Default.BaseColorScheme && x.ColorScheme == Properties.Settings.Default.ColorScheme));
      }

      /// <summary>Shows the quit dialog.</summary>
      private static void ShowQuitDialog()
      {
         if (MessageBox.Show(Properties.Resources.CloseText, Properties.Resources.Close, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
         {
            Application.Current.Shutdown(0);
         }
      }

      /// <summary>Creates the current game options.</summary>
      /// <returns>The current game options.</returns>
      private IGameOptions CreateCurrentGameOptions()
      {
         var players = new List<IPlayer>();

         if (CurrentContent is GameOptionsViewModel currentGameOptionsViewModel)
         {
            var startPoints = Convert.ToUInt16(currentGameOptionsViewModel.GameSettings.SelectedStartPoints);
            var doubleIn = currentGameOptionsViewModel.GameSettings.DoubleIn;
            var doubleOut = currentGameOptionsViewModel.GameSettings.DoubleIn;

            foreach (var player in currentGameOptionsViewModel.Playerlist)
            {
               players.Add(new Player(player.Name, startPoints, doubleIn, doubleOut));
            }

            var gameOptions = new GameOptions(players);
            gameOptions.StartPoints = startPoints;
            gameOptions.DoubleIn = currentGameOptionsViewModel.GameSettings.DoubleIn;
            gameOptions.DoubleOut = currentGameOptionsViewModel.GameSettings.DoubleOut;
            return gameOptions;
         }

         return null;
      }

      /// <summary>Gets the current settings.</summary>
      /// <returns>The current applications settings.</returns>
      private IApplicationSettings GetSettings()
      {
         IApplicationSettings applicationSettings = new ApplicationSettings();
         applicationSettings.ShowUserInterfaceDartBoardData = Properties.Settings.Default.ShowUserInterfaceDartBoardData;
         applicationSettings.SelectedCultureInfo = Properties.Settings.Default.CurrentCulture;
         applicationSettings.CurrentTheme = GetCurrentTheme();
         return applicationSettings;
      }

      private void SettingsPropertyChanged(object sender, EventArgs args)
      {
         if (sender is ApplicationSettingsViewModel applicationSettingsViewModel)
            SetCulture(applicationSettingsViewModel.CurrentApplicationSettings.SelectedCultureInfo);
      }

      /// <summary>Starts the dart game.</summary>
      private void StartDartGame()
      {
         ConfiguredGameOptions = CreateCurrentGameOptions();

         var throwGameService = ServiceProvider.Instance.Get<IThrowGameService>() as IThrowGameService;
         throwGameService.StartGame(ConfiguredGameOptions);

         CurrentContent = new DartGameViewModel(this);

         CurrentProperties = new Core.EnvironmentProps.Properties(SettingsViewModel.CurrentApplicationSettings.CurrentTheme.OriginalTheme.Name, SettingsViewModel.CurrentApplicationSettings.SelectedCultureInfo);

         //var plugInLoader = new PlugInLoader(path);
         //var dartGameViewModel = CurrentContent as DartGameViewModel;
         //PlugIns = plugInLoader.LoadPlugIns();

         GameStarted?.Invoke(this, EventArgs.Empty);
      }

      #endregion Private Methods
   }
}
