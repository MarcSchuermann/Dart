// -----------------------------------------------------------------------
// <copyright file="IMainWindowViewModel.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using Schuermann.Darts.GameCore.Game;

namespace Dart
{
    /// <summary>The main window view model interface.</summary>
    /// <seealso cref="Dart.IViewModelBase" />
    public interface IMainWindowViewModel : IViewModelBase
    {
        #region Public Events

        /// <summary>Occurs when [game started].</summary>
        event EventHandler<EventArgs> GameStarted;

        #endregion Public Events

        #region Public Properties

        /// <summary>Gets or sets the configured game options.</summary>
        /// <value>The configured game options.</value>
        IGameOptions ConfiguredGameOptions { get; set; }

        /// <summary>Gets the settings view model.</summary>
        /// <value>The settings view model.</value>
        IApplicationSettingsViewModel SettingsViewModel { get; }

        #endregion Public Properties
    }
}