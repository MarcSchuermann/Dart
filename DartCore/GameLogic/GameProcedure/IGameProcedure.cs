// -----------------------------------------------------------------------
// <copyright file="IGameProcedure.cs" company="Marc Schürmann">
// Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using GameLogic.DartThrow;
using GameLogic.GameOptions;
using GameLogic.Player;

namespace GameLogic.GameProcedure
{
    /// <summary>The logic for a game.</summary>
    public interface IGameProcedure
    {
        #region Public Properties

        /// <summary>Gets the current player.</summary>
        /// <returns>The current player.</returns>
        IPlayer CurrentPlayer { get; }

        /// <summary>Gets the game options.</summary>
        /// <value>The game options.</value>
        IGameOptions GameOptions { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>Players the thrown.</summary>
        /// <param name="pointsThrown">The points thrown from the current player.</param>
        /// <returns>
        /// True if the remaining points are zero. False if the remaining points are more than zero
        /// or rather where below zero.
        /// </returns>
        bool PlayerThrown(IDartThrow pointsThrown);

        #endregion Public Methods
    }
}