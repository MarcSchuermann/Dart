// <copyright file="IPlayer.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Schuermann.Darts.GameCore.Thrown;

namespace Schuermann.Darts.GameCore.Game
{
    /// <summary>The player interface.</summary>
    public interface IPlayer : ICloneable
    {
        #region Public Properties

        /// <summary>Gets or sets the current score.</summary>
        /// <value>The current score.</value>
        uint CurrentScore { get; }

        /// <summary>Gets or sets the dart count per round.</summary>
        /// <value>The dart count per round.</value>
        int DartCountThisRound { get; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        string Name { get; }

        /// <summary>Gets or sets the points this round.</summary>
        /// <value>The points this round.</value>
        int PointsThisRound { get; }

        /// <summary>Gets or sets the round.</summary>
        /// <value>The round.</value>
        int Round { get; }

        /// <summary>Gets the start points.</summary>
        /// <value>The start points.</value>
        uint StartPoints { get; }

        /// <summary>Gets or sets the throw history.</summary>
        /// <value>The throw history.</value>
        IList<IDartThrow> ThrowHistory { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>Throws the specified dart throw.</summary>
        /// <param name="dartThrow">The dart throw.</param>
        void Thrown(IDartThrow dartThrow);

        #endregion Public Methods
    }
}