// -----------------------------------------------------------------------
// <copyright file="PlayerViewModel.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using Dart.Game.Interfaces;
using Schuermann.Darts.GameCore.Game;

namespace Dart
{
    /// <summary>The PlayerViewModel.</summary>
    public class PlayerViewModel : ViewModelBase, IPlayerViewModel
    {
        #region Private Fields

        private uint currentScore;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="PlayerViewModel" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public PlayerViewModel(string name)
        {
            Name = name;
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="PlayerViewModel" /> class.
        /// </summary>
        /// <param name="player">The player.</param>
        public PlayerViewModel(IPlayer player)
        {
            Name = player.Name;
            CurrentScore = player.CurrentScore;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>Gets or sets the current score.</summary>
        /// <value>The current score.</value>
        public uint CurrentScore
        {
            get => currentScore;
            set
            {
                currentScore = value;
                RaisePropertyChanged(nameof(CurrentScore));
            }
        }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        #endregion Public Properties
    }
}