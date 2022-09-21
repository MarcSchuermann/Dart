// -----------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using Autofac;
using ControlzEx.Theming;
using Dart.Common;
using Dart.Common.Commands;
using Dart.Common.Theme;
using Dart.Settings.Interfaces;
using Schuermann.Darts.Environment.EnvironmentProps;
using Schuermann.Darts.Environment.Extensibility;
using Schuermann.Darts.GameCore.Game;

namespace Dart
{
    /// <summary>The MainWindowViewModel.</summary>
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel, ICloneable
    {
        #region Private Fields

        private readonly Predicate<object> canShutdown = (currentContent) => { return true; };

        private readonly Predicate<object> canStart = (currentContent) =>
                                                               {
                                                                   if (currentContent is not GameOptionsViewModel currentGameOptions || currentGameOptions.GameSettings == null || currentGameOptions.PlayerlistViewModel == null)
                                                                       return false;

                                                                   if (string.IsNullOrWhiteSpace(currentGameOptions.GameSettings.SelectedPlayerCount))
                                                                       return false;

                                                                   if (string.IsNullOrWhiteSpace(currentGameOptions.GameSettings.SelectedStartPoints))
                                                                       return false;

                                                                   foreach (var player in currentGameOptions.PlayerlistViewModel.Playerlist)
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

            LoadPlugIns();
        }

        #endregion Public Constructors

        #region Public Events

        public event EventHandler<EventArgs> GameStarted;

        #endregion Public Events

        #region Public Properties

        /// <summary>Gets or sets the configured game options.</summary>
        /// <value>The configured game options.</value>
        [Export(typeof(IGameOptions))]
        public IGameOptions ConfiguredGameOptions { get; set; }

        /// <summary>Gets or sets the content of the current.</summary>
        /// <value>The content of the current.</value>
        public IViewModelBase CurrentContent
        {
            get
            {
                return currentContent;
            }

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
        [Export(typeof(IProperties))]
        public IProperties CurrentProperties { get; private set; }

        /// <summary>Gets or sets the plug ins.</summary>
        /// <value>The plug ins.</value>
        [ImportMany]
        public IEnumerable<IPlugIn> PlugIns { get; set; }

        /// <summary>Gets the quit application.</summary>
        /// <value>The quit application.</value>
        public ICommand QuitApplication => new RelayCommand(x => ShowQuitDialog(), canShutdown);

        /// <summary>Gets the settings view model.</summary>
        /// <value>The settings view model.</value>
        public IApplicationSettingsViewModel SettingsViewModel { get; private set; }

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
            var container = ServiceContainer.GetContainer();
            var gameOptions = container.Resolve<IGameOptions>();

            if (CurrentContent is GameOptionsViewModel currentGameOptionsViewModel)
            {
                gameOptions.StartPoints = Convert.ToInt16(currentGameOptionsViewModel.GameSettings.SelectedStartPoints);

                foreach (var player in currentGameOptionsViewModel.PlayerlistViewModel.Playerlist)
                {
                    gameOptions.PlayerList.Add(new Player() { Name = player.Name, CurrentScore = gameOptions.StartPoints, Round = 0, DartCountThisRound = 0, PointsThisRound = 0 });
                }
            }

            return gameOptions;
        }

        /// <summary>Gets the current settings.</summary>
        /// <returns>The current applications settings.</returns>
        private IApplicationSettings GetSettings()
        {
            var container = ServiceContainer.GetContainer();
            var applicationSettings = container.Resolve<IApplicationSettings>();
            applicationSettings.ShowUserInterfaceDartBoardData = Properties.Settings.Default.ShowUserInterfaceDartBoardData;
            applicationSettings.SelectedCultureInfo = Properties.Settings.Default.CurrentCulture;
            applicationSettings.AllPlayTillZero = Properties.Settings.Default.AllPlayTillZero;
            applicationSettings.CurrentTheme = GetCurrentTheme();
            return applicationSettings;
        }

        private void LoadPlugIns()
        {
            try
            {
                // TODO: Make path configurabel and setable via command line. And compile charts with the new core assemblies.
                var catalog = new DirectoryCatalog(@"D:\_tf\Dart\Dev\Extensions\Charts\Charts\bin\Debug\");
                var container = new CompositionContainer(catalog);
                CurrentProperties = new Schuermann.Darts.Environment.EnvironmentProps.Properties(SettingsViewModel.CurrentApplicationSettings.CurrentTheme.OriginalTheme.Name, SettingsViewModel.CurrentApplicationSettings.SelectedCultureInfo);

                container.ComposeParts(this);
            }
            catch (Exception)
            {
            }
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

            CurrentContent = new DartGameViewModel(this);
            //mainWindowViewModel.CurrentContent = new GameOptionsViewModel();
            GameStarted?.Invoke(this, EventArgs.Empty);
            //HamburgerMenuControl.Content = (DataContext as MainWindowViewModel).CurrentContent;
        }

        #endregion Private Methods
    }
}