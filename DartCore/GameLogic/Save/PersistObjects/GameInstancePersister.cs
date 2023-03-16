// -----------------------------------------------------------------------
// <copyright file="GameInstancePersister.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Schuermann.Darts.GameCore.Save.PersistObjects
{
    /// <summary>Persists the game instance.</summary>
    internal class GameInstancePersister
    {
        #region Public Properties

        /// <summary>Gets or sets the game option.</summary>
        /// <value>The game option.</value>
        public GameOptionPersister GameOption { get; set; }

        /// <summary>Gets or sets the player.</summary>
        /// <value>The player.</value>
        public PlayerPersister CurrentPlayer { get; set; }

        #endregion Public Properties
    }
}