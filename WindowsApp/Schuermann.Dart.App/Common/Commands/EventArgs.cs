// -----------------------------------------------------------------------
// <copyright file="EventArgs.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Dart.Common.Commands
{
    /// <summary></summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.EventArgs" />
    public class EventArgs<T> : EventArgs
    {
        #region Public Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="EventArgs{T}" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public EventArgs(T value)
        {
            Value = value;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>Gets the value.</summary>
        /// <value>The value.</value>
        public T Value { get; private set; }

        #endregion Public Properties
    }
}