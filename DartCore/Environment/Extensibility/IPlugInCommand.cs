// -----------------------------------------------------------------------
// <copyright file="IPlugInCommand.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Environment.Extensibility
{
    /// <summary>The plug in command.</summary>
    public interface IPlugInCommand
    {
        #region Public Properties

        /// <summary>Gets the display text.</summary>
        /// <value>The display text.</value>
        string DisplayText { get; }

        /// <summary>Gets a value indicating whether [enabled in game].</summary>
        /// <value><c>true</c> if [enabled in game]; otherwise, <c>false</c>.</value>
        bool EnabledInGame { get; }

        /// <summary>Gets a value indicating whether [enabled in main menu].</summary>
        /// <value><c>true</c> if [enabled in main menu]; otherwise, <c>false</c>.</value>
        bool EnabledInMainMenu { get; }

        /// <summary>Gets the on execute.</summary>
        /// <value>The on execute.</value>
        Action OnExecute { get; }

        /// <summary>Gets the plug in.</summary>
        /// <value>The plug in.</value>
        IPlugIn PlugIn { get; }

        #endregion Public Properties
    }
}