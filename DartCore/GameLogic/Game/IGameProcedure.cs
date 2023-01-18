// -----------------------------------------------------------------------
// <copyright file="IGameProcedure.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using Schuermann.Darts.GameCore.Thrown;
using Schuermann.Darts.GameCore.UndoRedo.Interfaces;

namespace Schuermann.Darts.GameCore.Game
{
    /// <summary>The logic for a game.</summary>
    public interface IGameProcedure : IUndoRedoable
    {
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
        bool PlayerThrown(IDartThrow pointsThrown);

        #endregion Public Methods
    }
}