using Environment.Themes;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnvironmentTests.ThemesTests
{
    /// <summary>The constructor test.</summary>
    [TestClass]
    public class ConstructorTest
    {
        #region Public Methods

        /// <summary>Initializes the correct.</summary>
        [TestMethod]
        public void InitCorrect()
        {
            var theme = new Theme(BaseTheme.dark, ColorSchema.red);
            theme.ColorSchema.Should().Be(ColorSchema.red);
            theme.BaseTheme.Should().Be(BaseTheme.dark);
        }

        /// <summary>Initializes the correct default.</summary>
        [TestMethod]
        public void InitCorrectDefault()
        {
            var theme = new Theme();
            theme.ColorSchema.Should().Be(ColorSchema.blue);
            theme.BaseTheme.Should().Be(BaseTheme.light);
        }

        #endregion Public Methods
    }
}