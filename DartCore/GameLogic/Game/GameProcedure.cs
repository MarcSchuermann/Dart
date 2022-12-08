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
            Instance = new GameInstance(gameOptions);            
        }

        #endregion Public Constructors

        #region Public Events

        /// <summary>Occurs when a property value changes.</summary>
        /// <returns></returns>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Public Events

        #region Public Properties

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public IGameInstance Instance { get; }

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
                return Instance.CurrentPlayer.CurrentScore == 0;

            if (Instance.CurrentPlayer.CurrentScore >= pointsThrown.Points)
            {
                Instance.CurrentPlayer.CurrentScore -= pointsThrown.Points;
                Instance.CurrentPlayer.DartCountThisRound++;
                Instance.CurrentPlayer.PointsThisRound += pointsThrown.Points;
                AddThrowHistory(pointsThrown);

                if (Instance.CurrentPlayer.CurrentScore == 0)
                    return true;
            }
            else
            {
                AddThrowHistory(pointsThrown);

                Instance.CurrentPlayer.CurrentScore += Instance.CurrentPlayer.PointsThisRound;
                GoToNextPlayer();
            }

            if (Instance.CurrentPlayer.DartCountThisRound >= 3)
                GoToNextPlayer();

            RaisePropertyChanged(nameof(Instance.CurrentPlayer.CurrentScore));

            return false;
        }

        #endregion Public Methods

        #region Private Methods

        private void AddThrowHistory(IDartThrow thrownPoints)
        {
            Instance.CurrentPlayer?.ThrowHistory.Add(thrownPoints);
        }

        /// <summary>All the points are zero.</summary>
        /// <returns>True if all players points are zero.</returns>
        private bool AllPointsAreZero()
        {
            foreach (var player in Instance.GameOptions.PlayerList)
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
            foreach (var player in Instance.GameOptions.PlayerList)
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

            if (AtLeastOnePlayersPointsAreZero() && !Instance.GameOptions.AllPlayTillZero)
                return;

            Instance.CurrentPlayer.Round++;

            foreach (var player in Instance.GameOptions.PlayerList)
            {
                if (player == Instance.CurrentPlayer)
                {
                    int index = Instance.GameOptions.PlayerList.IndexOf(Instance.CurrentPlayer);
                    if (index + 1 < Instance.GameOptions.PlayerList.Count)
                    {
                        Instance.CurrentPlayer = Instance.GameOptions.PlayerList[index + 1];
                        break;
                    }

                    Instance.CurrentPlayer = Instance.GameOptions.PlayerList.First();
                    break;
                }
            }

            Instance.CurrentPlayer.DartCountThisRound = 0;
            Instance.CurrentPlayer.PointsThisRound = 0;

            if (Instance.CurrentPlayer.CurrentScore == 0 && Instance.GameOptions.AllPlayTillZero && !AllPointsAreZero())
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