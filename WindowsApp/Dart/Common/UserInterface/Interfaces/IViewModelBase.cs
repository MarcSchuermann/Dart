// -----------------------------------------------------------------------
// <copyright file="IViewModelBase.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel;

namespace Dart
{
    /// <summary>The IViewModelBase.</summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public interface IViewModelBase : INotifyPropertyChanged
    {
        #region Public Properties

        /// <summary>Gets the label.</summary>
        /// <value>The label.</value>
        static string Label { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>Raises the property changed.</summary>
        /// <param name="propertyName">Name of the property.</param>
        void RaisePropertyChanged(string propertyName);

        #endregion Public Methods
    }
}