// -----------------------------------------------------------------------
// <copyright file="ApplicationSettings.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Globalization;
using Dart.Common.Theme;

namespace Dart
{
    /// <summary>The ApplicationSettings.</summary>
    public class ApplicationSettings : IEquatable<IApplicationSettings>, IApplicationSettings
    {
        #region Public Properties

        /// <summary>Gets or sets a value indicating whether [all play till zero].</summary>
        /// <value><c>true</c> if [all play till zero]; otherwise, <c>false</c>.</value>
        public bool AllPlayTillZero { get; set; }

        /// <summary>Gets or sets the current theme.</summary>
        /// <value>The current theme.</value>
        public INamedTheme CurrentTheme { get; set; }

        /// <summary>Gets or sets the selected culture information.</summary>
        /// <value>The selected culture information.</value>
        public CultureInfo SelectedCultureInfo { get; set; }

        /// <summary>Gets or sets a value indicating whether [show user interface dart board data].</summary>
        /// <value><c>true</c> if [show user interface dart board data]; otherwise, <c>false</c>.</value>
        public bool ShowUserInterfaceDartBoardData { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>Implements the operator !=.</summary>
        /// <param name="appSettings1">The application settings1.</param>
        /// <param name="appSettings2">The application settings2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(ApplicationSettings appSettings1, IApplicationSettings appSettings2)
        {
            return !CompareApplicationSettings(appSettings1, appSettings2);
        }

        /// <summary>Implements the operator ==.</summary>
        /// <param name="appSettings1">The application settings1.</param>
        /// <param name="appSettings2">The application settings2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(ApplicationSettings appSettings1, IApplicationSettings appSettings2)
        {
            return CompareApplicationSettings(appSettings1, appSettings2);
        }

        /// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
        /// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            var appSettings = obj as IApplicationSettings;

            if (appSettings != null)
                return Equals(appSettings);

            return false;
        }

        /// <summary>Equals the specified to compare.</summary>
        /// <param name="settingsToCompare">To compare.</param>
        /// <returns>True if equal.</returns>
        public bool Equals(IApplicationSettings settingsToCompare)
        {
            return CompareApplicationSettings(this, settingsToCompare);
        }

        /// <summary>Returns a hash code for this instance.</summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion Public Methods

        #region Private Methods

        private static bool CompareApplicationSettings(IApplicationSettings appSettings1, IApplicationSettings appSettings2)
        {
            if (appSettings2 == null || appSettings1 == null)
                return false;

            var properties = Type.GetType(appSettings1.GetType().FullName).GetProperties();

            foreach (var property in properties)
            {
                var propertyFromSettings1 = appSettings1.GetType().GetProperty(property.Name);
                var propertyFromSettings2 = appSettings2.GetType().GetProperty(property.Name);

                var valueFromSettings1 = propertyFromSettings1.GetValue(appSettings1);
                var valueFromSettings2 = propertyFromSettings2.GetValue(appSettings2);

                if (valueFromSettings1 == null && valueFromSettings2 == null)
                    continue;

                if (valueFromSettings1 != null && valueFromSettings1.Equals(valueFromSettings2))
                    continue;

                return false;
            }

            return true;
        }

        #endregion Private Methods
    }
}