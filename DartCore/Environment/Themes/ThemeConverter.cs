// <copyright file="ThemeConverter.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>

using System;
using System.Diagnostics;

namespace Environment.Themes
{
    /// <summary>The theme converter.</summary>
    public static class ThemeConverter
    {
        #region Public Methods

        /// <summary>Converts the specified theme.</summary>
        /// <param name="theme">The theme.</param>
        /// <returns>The converted theme.</returns>
        public static Theme Convert(string theme)
        {
            try
            {
                var themeArray = theme.Split(new char[] { '.' }, 2);

                if (themeArray.Length != 2 || string.IsNullOrWhiteSpace(themeArray[0]) || string.IsNullOrWhiteSpace(themeArray[1]))
                    throw new FormatException();

                return Convert(themeArray[0], themeArray[1]);
            }
            catch (Exception)
            {
                Debug.WriteLine($"{nameof(theme)} {theme} could not be converted.");
            }

            return new Theme();
        }

        /// <summary>Converts the specified base theme.</summary>
        /// <param name="baseTheme">The base theme.</param>
        /// <param name="colorSchema">The color schema.</param>
        /// <returns>The converted theme.</returns>
        public static Theme Convert(string baseTheme, string colorSchema)
        {
            if (string.IsNullOrWhiteSpace(baseTheme) || string.IsNullOrWhiteSpace(colorSchema))
                return new Theme();

            if (Enum.TryParse(baseTheme.ToLower(), out BaseTheme convertedBaseTheme) && Enum.TryParse(colorSchema.ToLower(), out ColorSchema convertedColorSchema))
                return new Theme(convertedBaseTheme, convertedColorSchema);

            return new Theme();
        }

        #endregion Public Methods
    }
}