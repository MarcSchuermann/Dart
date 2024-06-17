// -----------------------------------------------------------------------
// <copyright file="IPlayerViewModel.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel;

namespace Dart.Game.Interfaces
{
    /// <summary>The view model for a player.</summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public interface IPlayerViewModel : INotifyPropertyChanged
    {
        #region Public Properties

        /// <summary>Gets or sets the current score.</summary>
        /// <value>The current score.</value>
        uint CurrentScore { get; set; }

        /// <summary>Gets the name.</summary>
        /// <value>The name.</value>
        string Name { get; }

        #endregion Public Properties
    }
}