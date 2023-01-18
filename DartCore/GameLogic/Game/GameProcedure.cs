// -----------------------------------------------------------------------
// <copyright file="GameProcedure.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel;
using Schuermann.Darts.GameCore.Thrown;
using Schuermann.Darts.GameCore.UndoRedo.Interfaces;
using Schuermann.Darts.GameCore.Util;

namespace Schuermann.Darts.GameCore.Game
{
    /// <summary>The game instance.</summary>
    /// <seealso cref="IGameProcedure" />
    /// <seealso cref="INotifyPropertyChanged" />
    public class GameProcedure : IGameProcedure
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

        #region Public Properties

        /// <summary>Gets the instance.</summary>
        /// <value>The instance.</value>
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

            Instance.CurrentPlayer.Thrown(pointsThrown);

            if (Instance.CurrentPlayer.CurrentScore == 0)
                return true;

            return false;
        }

        /// <summary>Redoes this instance.</summary>
        public void Redo()
        {
            if (Instance.CurrentPlayer.DartCountThisRound == 0)
            {
                ((Player)Instance.GameOptions.PlayerList.GetPriviousPlayer(Instance.CurrentPlayer)).Redo();
                return;
            }

            ((Player)Instance.CurrentPlayer).Redo();
        }

        /// <summary>Undoes this instance.</summary>
        public void Undo()
        {
            if (Instance.CurrentPlayer.DartCountThisRound == 0)
            {
                ((Player)Instance.GameOptions.PlayerList.GetPriviousPlayer(Instance.CurrentPlayer)).Undo();
                return;
            }

            ((Player)Instance.CurrentPlayer).Undo();
        }

        #endregion Public Methods
    }
}