// -----------------------------------------------------------------------
// <copyright file="ToolBarViewModel.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows.Input;
using Core;

namespace Dart
{
    /// <summary>The ToolBarViewModel.</summary>
    /// <seealso cref="Dart.ViewModelBase"/>
    public class ToolBarViewModel : ViewModelBase
    {
        #region Public Constructors

        /// <summary>Initializes a new instance of the <see cref="ToolBarViewModel"/> class.</summary>
        /// <param name="owner">The owner.</param>
        public ToolBarViewModel(IViewModelBase owner)
        {
            OwnerViewModel = owner as MainWindowViewModel;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>Gets the open settings.</summary>
        /// <value>The open settings.</value>
        public ICommand OpenSettings => new RelayCommand(OpenApplicationSettings);

        /// <summary>Gets the owner view model.</summary>
        /// <value>The owner view model.</value>
        public MainWindowViewModel OwnerViewModel { get; }

        /// <summary>Gets the quit application.</summary>
        /// <value>The quit application.</value>
        public ICommand QuitApplication => new RelayCommand(QuitCurrentApplication, () => true);

        /// <summary>Gets the reset game.</summary>
        /// <value>The reset game.</value>
        public ICommand ResetGame => new RelayCommand(ResetCurrentGame, CanReset);

        #endregion Public Properties

        #region Private Methods

        /// <summary>Determines whether this instance can reset.</summary>
        /// <returns><c>true</c> if this instance can reset; otherwise, <c>false</c>.</returns>
        private bool CanReset()
        {
            return OwnerViewModel.CurrentContent is GameOptionsViewModel;
        }

        /// <summary>Opens the application settings.</summary>
        private void OpenApplicationSettings()
        {
            var settingsView = new ApplicationSettingsView();

            if (OwnerViewModel.SettingsViewModel != null)
                settingsView.DataContext = OwnerViewModel.SettingsViewModel;
            else
                settingsView.DataContext = new ApplicationSettingsViewModel(OwnerViewModel);

            settingsView.ShowDialog();
        }

        private void QuitCurrentApplication()
        {
            if (OwnerViewModel is IMainWindowViewModel mainWindowViewModel)
            {
                mainWindowViewModel.QuitApplication.Execute(this);
            }
        }

        /// <summary>Resets the current game.</summary>
        private void ResetCurrentGame()
        {
            var gameOptionsViewModel = OwnerViewModel.CurrentContent as GameOptionsViewModel;

            gameOptionsViewModel.GameSettings = new GameSettingsViewModel();
            gameOptionsViewModel.PlayerlistViewModel = new PlayerlistViewModel(gameOptionsViewModel.GameSettings);
        }

        #endregion Private Methods
    }
}