// <copyright file="GameProcedure.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>

using System.ComponentModel;
using System.Linq;
using Schuermann.Darts.GameCore.Thrown;

namespace Schuermann.Darts.GameCore.Game
{
    /// <summary>The game instance.</summary>
    /// <seealso cref="IGameProcedure" />
    /// <seealso cref="INotifyPropertyChanged" />
    public class GameProcedure : IGameProcedure, INotifyPropertyChanged
    {
        #region Public Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="GameProcedure" /> class.
        /// </summary>
        /// <param name="gameOptions">The game options.</param>
        public GameProcedure(IGameOptions gameOptions)
        {
            GameOptions = gameOptions;
            CurrentPlayer = GameOptions.PlayerList.First();
        }

        #endregion Public Constructors

        #region Public Events

        /// <summary>Occurs when a property value changes.</summary>
        /// <returns></returns>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Public Events

        #region Public Properties

        /// <summary>Gets the current player.</summary>
        public IPlayer CurrentPlayer { get; private set; }

        /// <summary>Gets the game options.</summary>
        /// <value>The game options.</value>
        public IGameOptions GameOptions { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>Players the thrown.</summary>
        /// <param name="pointsThrown">The points thrown from the current player.</param>
        /// <returns>
        ///    True if the remaining points are zero. False if the remaining points are more than
        ///    zero or rather where below zero.
        /// </returns>
        public bool PlayerThrown(IDartThrow pointsThrown)
        {
            if (pointsThrown == null)
                return CurrentPlayer.CurrentScore == 0;

            if (CurrentPlayer.CurrentScore >= pointsThrown.Points)
            {
                CurrentPlayer.CurrentScore -= pointsThrown.Points;
                CurrentPlayer.DartCountThisRound++;
                CurrentPlayer.PointsThisRound += pointsThrown.Points;
                AddThrowHistory(pointsThrown);

                if (CurrentPlayer.CurrentScore == 0)
                    return true;
            }
            else
            {
                AddThrowHistory(pointsThrown);

                CurrentPlayer.CurrentScore += CurrentPlayer.PointsThisRound;
                GoToNextPlayer();
            }

            if (CurrentPlayer.DartCountThisRound >= 3)
                GoToNextPlayer();

            RaisePropertyChanged(nameof(CurrentPlayer.CurrentScore));

            return false;
        }

        #endregion Public Methods

        #region Private Methods

        private void AddThrowHistory(IDartThrow thrownPoints)
        {
            CurrentPlayer?.ThrowHistory.Add(thrownPoints);
        }

        /// <summary>All the points are zero.</summary>
        /// <returns>True if all players points are zero.</returns>
        private bool AllPointsAreZero()
        {
            foreach (var player in GameOptions.PlayerList)
            {
                if (player.CurrentScore != 0)
                    return false;
            }

            return true;
        }

        /// <summary>At least one players points are zero.</summary>
        /// <returns>True or false..</returns>
        private bool AtLeastOnePlayersPointsAreZero()
        {
            foreach (var player in GameOptions.PlayerList)
            {
                if (player.CurrentScore == 0)
                    return true;
            }

            return false;
        }

        /// <summary>Goes to next player.</summary>
        private void GoToNextPlayer()
        {
            if (AllPointsAreZero())
                return;

            if (AtLeastOnePlayersPointsAreZero() && !GameOptions.AllPlayTillZero)
                return;

            CurrentPlayer.Round++;

            foreach (var player in GameOptions.PlayerList)
            {
                if (player == CurrentPlayer)
                {
                    int index = GameOptions.PlayerList.IndexOf(CurrentPlayer);
                    if (index + 1 < GameOptions.PlayerList.Count)
                    {
                        CurrentPlayer = GameOptions.PlayerList[index + 1];
                        break;
                    }

                    CurrentPlayer = GameOptions.PlayerList.First();
                    break;
                }
            }

            CurrentPlayer.DartCountThisRound = 0;
            CurrentPlayer.PointsThisRound = 0;

            if (CurrentPlayer.CurrentScore == 0 && GameOptions.AllPlayTillZero && !AllPointsAreZero())
                GoToNextPlayer();
        }

        /// <summary>Raises the property changed.</summary>
        /// <param name="propertyName">Name of the property.</param>
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion Private Methods
    }
}