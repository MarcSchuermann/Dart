// -----------------------------------------------------------------------
// <copyright file="IGameOptions.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using Schuermann.Dart.Core.Game;

namespace Schuermann.Darts.GameCore.Game
{
   /// <summary>The game option interface.</summary>
   public interface IGameOptions
    {
        #region Public Properties

        /// <summary>Gets or sets a value indicating whether [double in].</summary>
        /// <value><c>true</c> if [double in]; otherwise, <c>false</c>.</value>
        bool DoubleIn { get; set; }

        /// <summary>Gets or sets a value indicating whether [double out].</summary>
        /// <value><c>true</c> if [double out]; otherwise, <c>false</c>.</value>
        bool DoubleOut { get; set; }

        /// <summary>Gets or sets the player list.</summary>
        /// <value>The player list.</value>
        IEnumerable<IPlayer> PlayerList { get; }

        /// <summary>Gets or sets the start points.</summary>
        /// <value>The start points.</value>
        int StartPoints { get; set; }

        #endregion Public Properties
    }
}