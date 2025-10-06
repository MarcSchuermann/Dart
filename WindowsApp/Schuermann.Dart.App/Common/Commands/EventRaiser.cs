// -----------------------------------------------------------------------
// <copyright file="EventRaiser.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Dart.Common.Commands
{
    /// <summary>The event raiser.</summary>
    public static class EventRaiser
    {
        #region Public Methods

        /// <summary>Raises the specified sender.</summary>
        /// <param name="handler">The handler.</param>
        /// <param name="sender">The sender.</param>
        public static void Raise(this EventHandler handler, object sender)
        {
            handler?.Invoke(sender, EventArgs.Empty);
        }

        /// <summary>Raises the specified sender.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="handler">The handler.</param>
        /// <param name="sender">The sender.</param>
        /// <param name="value">The value.</param>
        public static void Raise<T>(this EventHandler<EventArgs<T>> handler, object sender, T value)
        {
            handler?.Invoke(sender, new EventArgs<T>(value));
        }

        /// <summary>Raises the specified sender.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="handler">The handler.</param>
        /// <param name="sender">The sender.</param>
        /// <param name="value">The value.</param>
        public static void Raise<T>(this EventHandler<T> handler, object sender, T value) where T : EventArgs
        {
            handler?.Invoke(sender, value);
        }

        /// <summary>Raises the specified sender.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="handler">The handler.</param>
        /// <param name="sender">The sender.</param>
        /// <param name="value">
        ///    The <see cref="EventArgs{T}" /> instance containing the event data.
        /// </param>
        public static void Raise<T>(this EventHandler<EventArgs<T>> handler, object sender, EventArgs<T> value)
        {
            handler?.Invoke(sender, value);
        }

        #endregion Public Methods
    }
}