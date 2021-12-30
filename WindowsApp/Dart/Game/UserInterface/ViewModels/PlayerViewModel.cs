// -----------------------------------------------------------------------
// <copyright file="PlayerViewModel.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Dart
{
    /// <summary>The PlayerViewModel.</summary>
    public class PlayerViewModel : ViewModelBase
    {
        #region Public Constructors

        /// <summary>Initializes a new instance of the <see cref="PlayerViewModel"/> class.</summary>
        /// <param name="name">The name.</param>
        public PlayerViewModel(string name)
        {
            Name = name;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        #endregion Public Properties
    }
}