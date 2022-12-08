// <copyright file="IPlayer.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>

using System.Collections.Generic;
using Schuermann.Darts.GameCore.Thrown;

namespace Schuermann.Darts.GameCore.Game
{
    /// <summary>The player interface.</summary>
    public interface IPlayer
    {
        #region Public Properties

        /// <summary>Gets or sets the current score.</summary>
        /// <value>The current score.</value>
        int CurrentScore { get; set; }

        /// <summary>Gets or sets the dart count per round.</summary>
        /// <value>The dart count per round.</value>
        int DartCountThisRound { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        string Name { get; set; }

        /// <summary>Gets or sets the points this round.</summary>
        /// <value>The points this round.</value>
        int PointsThisRound { get; set; }

        /// <summary>Gets or sets the round.</summary>
        /// <value>The round.</value>
        int Round { get; set; }

        /// <summary>Gets or sets the throw history.</summary>
        /// <value>The throw history.</value>
        IList<IDartThrow> ThrowHistory { get; set; }

        #endregion Public Properties
    }
}