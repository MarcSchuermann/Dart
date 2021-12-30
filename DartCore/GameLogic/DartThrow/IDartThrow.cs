// -----------------------------------------------------------------------
// <copyright file="IDartThrow.cs" company="Marc Schürmann">
// Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace GameLogic.DartThrow
{
    /// <summary>The dart throw.</summary>
    public interface IDartThrow : IEquatable<IDartThrow>, IComparable<IDartThrow>
    {
        #region Public Properties

        /// <summary>Gets the dart board field.</summary>
        /// <value>The dart board field.</value>
        DartBoardField DartBoardField { get; }

        /// <summary>Gets the dart board quantifier.</summary>
        /// <value>The dart board quantifier.</value>
        DartBoardQuantifier DartBoardQuantifier { get; }

        /// <summary>Gets the points.</summary>
        /// <value>The points.</value>
        int Points { get; }

        #endregion Public Properties
    }
}