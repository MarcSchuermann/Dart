// -----------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using Autofac;
using Dart.Common;
using Environment.Extensibility;
using GameLogic.DartThrow;
using GameLogic.GameOptions;
using GameLogic.Player;
using MvvmTools;
using Schuermann.Darts.Environment.EnvironmentProps;

namespace Dart
{
    /// <summary>The MainWindowViewModel.</summary>
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel, ICloneable
    {
        #region Private Fields

        private Predicate<object> canShutdown = (object x) => { return true; };

        private Predicate<object> canStart = (object currentContent) =>
             {
                 var currentGameOptions = currentContent as GameOptionsViewModel;

                 if (currentGameOptions == null || currentGameOptions.GameSettings == null || currentGameOptions.PlayerlistViewModel == null)
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

        private IViewModelBase toolBarViewModel;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="MainWindowViewModel" /> class.
        /// </summary>
        public MainWindowViewModel()
        {
            SettingsViewModel = new ApplicationSettingsViewModel(this);
            SettingsViewModel.LanguageChangedEvent += SettingsViewModel_LanguageChangedEvent;

            SetCulture();

            CurrentContent = new GameOptionsViewModel();
            ToolBarViewModel = new ToolBarViewModel(this);

            LoadPlugIns();
        }

        #endregion Public Constructors

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
        public ICommand QuitApplication => new RelayCommand(ShowQuitDialog, canShutdown);

        /// <summary>Gets the settings view model.</summary>
        /// <value>The settings view model.</value>
        public IApplicationSettingsViewModel SettingsViewModel { get; private set; }

        /// <summary>Gets the start game.</summary>
        /// <value>The start game.</value>
        public ICommand StartGame => new RelayCommand(StartDartGame, canStart);

        /// <summary>Gets or sets the current tool bar view model.</summary>
        /// <value>The current tool bar view model.</value>
        public IViewModelBase ToolBarViewModel
        {
            get
            {
                return toolBarViewModel;
            }

            set
            {
                if (toolBarViewModel == value)
                    return;

                toolBarViewModel = value;
                RaisePropertyChanged(nameof(ToolBarViewModel));
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>Creates a new object that is a copy of the current instance.</summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public object Clone()
        {
            return MemberwiseClone();
        }

        /// <summary>Sets the culture.</summary>
        public void SetCulture()
        {
            Thread.CurrentThread.CurrentCulture = Properties.Settings.Default.CurrentCulture;
            Thread.CurrentThread.CurrentUICulture = Properties.Settings.Default.CurrentCulture;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>Creates the current game options.</summary>
        /// <returns>The current game options.</returns>
        private IGameOptions CreateCurrentGameOptions()
        {
            var container = ServiceContainer.GetContainer();
            var gameOptions = container.Resolve<IGameOptions>();

            var currentGameOptionsViewModel = CurrentContent as GameOptionsViewModel;

            if (currentGameOptionsViewModel != null)
            {
                gameOptions.StartPoints = Convert.ToInt16(currentGameOptionsViewModel.GameSettings.SelectedStartPoints);
                gameOptions.PlayerList = new List<IPlayer>();

                foreach (var player in currentGameOptionsViewModel.PlayerlistViewModel.Playerlist)
                {
                    gameOptions.PlayerList.Add(new Player() { Name = player.Name, CurrentScore = gameOptions.StartPoints, ThrowHistory = new List<IDartThrow>(), Round = 0, DartCountThisRound = 0, PointsThisRound = 0 });
                }
            }

            return gameOptions;
        }

        private void LoadPlugIns()
        {
            try
            {
                var catalog = new DirectoryCatalog(@"D:\_tf\Dart\Dev\Extensions\Charts\Charts\bin\Debug\");
                var container = new CompositionContainer(catalog);
                CurrentProperties = new Schuermann.Darts.Environment.EnvironmentProps.Properties(SettingsViewModel.CurrentApplicationSettings.CurrentTheme.OriginalTheme.Name, SettingsViewModel.CurrentApplicationSettings.SelectedCultureInfo);

                container.ComposeParts(this);
            }
            catch (Exception)
            {
            }
        }

        private void SettingsViewModel_LanguageChangedEvent(object sender, EventArgs args)
        {
            SetCulture();
        }

        /// <summary>Shows the quit dialog.</summary>
        /// <param name="x">The x.</param>
        private void ShowQuitDialog(object x)
        {
            if (MessageBox.Show(Properties.Resources.CloseText, Properties.Resources.Close, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown(0);
            }
        }

        /// <summary>Starts the dart game.</summary>
        /// <param name="x">The x.</param>
        private void StartDartGame(object x)
        {
            ConfiguredGameOptions = CreateCurrentGameOptions();

            CurrentContent = new DartGameViewModel(this);
        }

        #endregion Private Methods
    }
}