// -----------------------------------------------------------------------
// <copyright file="IPlugIn.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using Schuermann.Darts.Environment.EnvironmentProps;
using Schuermann.Darts.GameCore.Game;

namespace Schuermann.Darts.Environment.Extensibility
{
    /// <summary>The plug in interface.</summary>
    public interface IPlugIn : IEquatable<IPlugIn>
    {
        #region Public Properties

        /// <summary>Gets or sets the game options.</summary>
        /// <value>The game options.</value>
        IGameOptions GameOptions { get; set; }

        /// <summary>Gets the name.</summary>
        /// <value>The name.</value>
        string Name { get; }

        /// <summary>Gets the plug in command.</summary>
        /// <value>The plug in command.</value>
        IPlugInCommand PlugInCommand { get; }

        /// <summary>Gets or sets the properties.</summary>
        /// <value>The properties.</value>
        IProperties Properties { get; set; }

        #endregion Public Properties
    }
}