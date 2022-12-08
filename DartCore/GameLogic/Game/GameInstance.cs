// -----------------------------------------------------------------------
// <copyright file="GameInstance.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Linq;

namespace Schuermann.Darts.GameCore.Game
{
    /// <summary>The instance.</summary>
    /// <seealso cref="Schuermann.Darts.GameCore.Game.IGameInstance" />
    public class GameInstance : IGameInstance
    {
        #region Public Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="GameInstance" /> class.
        /// </summary>
        /// <param name="gameOptions">The game options.</param>
        public GameInstance(IGameOptions gameOptions)
        {
            GameOptions = gameOptions;
            CurrentPlayer = GameOptions.PlayerList.FirstOrDefault();
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>Gets the current player.</summary>
        //[JsonConverter(typeof(Player))]
        public IPlayer CurrentPlayer { get; set; }

        /// <summary>Gets the game options.</summary>
        /// <value>The game options.</value>
        //[JsonConverter(typeof(GameOptions))]
        public IGameOptions GameOptions { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///    Performs application-defined tasks associated with freeing, releasing, or resetting
        ///    unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>Releases unmanaged and - optionally - managed resources.</summary>
        /// <param name="disposing">
        ///    <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release
        ///    only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose managed state (managed objects).
                GameOptions = null;
                CurrentPlayer = null;
            }

            // free unmanaged resources (unmanaged objects) and override a finalizer below. set
            // large fields to null.
        }

        #endregion Protected Methods
    }
}