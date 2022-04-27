using System.Globalization;
using Environment.Themes;

namespace Schuermann.Darts.Environment.EnvironmentProps
{
    /// <summary>The properties of the environment like the culture or the theme.</summary>
    public class Properties : IProperties
    {
        #region Public Constructors

        /// <summary>Initializes a new instance of the <see cref="Properties" /> class.</summary>
        /// <param name="theme">The theme.</param>
        /// <param name="culture">The culture.</param>
        public Properties(string theme, CultureInfo culture)
        {
            Theme = ThemeConverter.Convert(theme);
            Culture = culture;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>Gets the culture.</summary>
        /// <value>The culture.</value>
        public CultureInfo Culture { get; }

        /// <summary>Gets the theme.</summary>
        /// <value>The theme.</value>
        public Theme Theme { get; }

        #endregion Public Properties
    }
}