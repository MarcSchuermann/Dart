// -----------------------------------------------------------------------
// <copyright file="IApplicationSettings.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Globalization;
using Dart.Common.Theme;

namespace Dart.Settings.Interfaces
{
    /// <summary>The application settings interface.</summary>
    public interface IApplicationSettings
    {
        #region Public Properties

        /// <summary>Gets or sets a value indicating whether [all play till zero].</summary>
        /// <value><c>true</c> if [all play till zero]; otherwise, <c>false</c>.</value>
        bool AllPlayTillZero { get; set; }

        /// <summary>Gets or sets the current theme.</summary>
        /// <value>The current theme.</value>
        INamedTheme CurrentTheme { get; set; }

        /// <summary>Gets or sets the selected culture information.</summary>
        /// <value>The selected culture information.</value>
        CultureInfo SelectedCultureInfo { get; set; }

        /// <summary>
        ///    Gets or sets a value indicating whether [show user interface dart board data].
        /// </summary>
        /// <value>
        ///    <c>true</c> if [show user interface dart board data]; otherwise, <c>false</c>.
        /// </value>
        bool ShowUserInterfaceDartBoardData { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>Equals the specified to compare.</summary>
        /// <param name="settingsToCompare">To compare.</param>
        /// <returns>True or false.</returns>
        bool Equals(IApplicationSettings settingsToCompare);

        #endregion Public Methods
    }
}