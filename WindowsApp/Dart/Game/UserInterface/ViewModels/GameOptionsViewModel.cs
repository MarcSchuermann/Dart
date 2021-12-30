// -----------------------------------------------------------------------
// <copyright file="GameOptionsViewModel.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Dart
{
    /// <summary>The GameOptionsViewModel.</summary>
    public class GameOptionsViewModel : ViewModelBase
    {
        #region Private Fields

        private GameSettingsViewModel gameSettings;

        private PlayerlistViewModel playerlistViewModel;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>Initializes a new instance of the <see cref="GameOptionsViewModel"/> class.</summary>
        public GameOptionsViewModel()
        {
            GameSettings = new GameSettingsViewModel();
            PlayerlistViewModel = new PlayerlistViewModel(GameSettings);
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>Gets or sets the game settings.</summary>
        /// <value>The game settings.</value>
        public GameSettingsViewModel GameSettings
        {
            get
            {
                return gameSettings;
            }

            set
            {
                if (gameSettings == value)
                    return;

                gameSettings = value;
                RaisePropertyChanged(nameof(GameSettings));
            }
        }

        /// <summary>Gets or sets the player list view model.</summary>
        /// <value>The player list view model.</value>
        public PlayerlistViewModel PlayerlistViewModel
        {
            get
            {
                return playerlistViewModel;
            }
            set
            {
                if (playerlistViewModel == value)
                    return;

                playerlistViewModel = value;
                RaisePropertyChanged(nameof(PlayerlistViewModel));
            }
        }

        #endregion Public Properties
    }
}