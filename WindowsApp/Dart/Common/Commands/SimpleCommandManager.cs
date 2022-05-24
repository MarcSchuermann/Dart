// -----------------------------------------------------------------------
// <copyright file="SimpleCommandManager.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Dart.Common.Commands
{
    /// <summary>The simple command manager.</summary>
    public static class SimpleCommandManager
    {
        #region Private Fields

        private static readonly List<Action> raiseCanExecuteChangedActions = new();

        #endregion Private Fields

        #region Public Methods

        /// <summary>Adds the raise can execute changed action.</summary>
        /// <param name="raiseCanExecuteChangedAction">
        ///    The raise can execute changed action.
        /// </param>
        public static void AddRaiseCanExecuteChangedAction(ref Action raiseCanExecuteChangedAction)
        {
            raiseCanExecuteChangedActions.Add(raiseCanExecuteChangedAction);
        }

        /// <summary>Removes the raise can execute changed action.</summary>
        /// <param name="raiseCanExecuteChangedAction">
        ///    The raise can execute changed action.
        /// </param>
        public static void RemoveRaiseCanExecuteChangedAction(Action raiseCanExecuteChangedAction)
        {
            raiseCanExecuteChangedActions.Remove(raiseCanExecuteChangedAction);
        }

        #endregion Public Methods
    }
}