// -----------------------------------------------------------------------
// <copyright file="DartGameViewModel.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
using System.Windows.Input;
using Dart.Common.Commands;
using Schuermann.Darts.GameCore.Game;
using Schuermann.Darts.GameCore.Thrown;

namespace Dart
{
    /// <summary>The DartGameViewModel.</summary>
    /// <seealso cref="Dart.ViewModelBase" />
    public class DartGameViewModel : ViewModelBase
    {
        #region Public Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="DartGameViewModel" /> class.
        /// </summary>
        /// <param name="owner">The owner.</param>
        public DartGameViewModel(IViewModelBase owner)
        {
            MainWindowViewModel = owner as IMainWindowViewModel;

            Game = new GameProcedure(MainWindowViewModel.ConfiguredGameOptions);
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>Gets or sets the current points under mouse.</summary>
        /// <value>The current points under mouse.</value>
        public IDartThrow CurrentPointsUnderMouse { get; set; }

        /// <summary>Gets the dart thrown.</summary>
        /// <value>The dart thrown.</value>
        public ICommand DartThrown => new RelayCommand(x => Thrown());

        /// <summary>Gets the game.</summary>
        /// <value>The game.</value>
        public IGameProcedure Game { get; }

        /// <summary>Gets or sets the main window view model.</summary>
        /// <value>The main window view model.</value>
        public IMainWindowViewModel MainWindowViewModel { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>Thrown this instance.</summary>
        public void Thrown()
        {
            Game.PlayerThrown(CurrentPointsUnderMouse);
        }

        #endregion Public Methods
    }
}