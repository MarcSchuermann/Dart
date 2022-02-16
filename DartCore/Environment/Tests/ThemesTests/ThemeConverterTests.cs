using Environment.Themes;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnvironmentTests.ThemesTests
{
    /// <summary>The converter tests.</summary>
    [TestClass]
    public class ThemeConverterTests
    {
        #region Public Methods

        /// <summary>Converts the correct test.</summary>
        [TestMethod]
        public void ConvertCorrectTest()
        {
            var theme = ThemeConverter.Convert("light.yellow");

            theme.BaseTheme.Should().Be(BaseTheme.light);
            theme.ColorSchema.Should().Be(ColorSchema.yellow);
        }

        /// <summary>Converts the failed with empty base theme.</summary>
        [TestMethod]
        public void ConvertFailedWithEmptyBaseTheme()
        {
            var theme = ThemeConverter.Convert(" .red");

            theme.BaseTheme.Should().Be(BaseTheme.light);
            theme.ColorSchema.Should().Be(ColorSchema.blue);
        }

        /// <summary>Converts the failed with empty base theme and color schema.</summary>
        [TestMethod]
        public void ConvertFailedWithEmptyBaseThemeAndColorSchema()
        {
            var theme = ThemeConverter.Convert(" . ");

            theme.BaseTheme.Should().Be(BaseTheme.light);
            theme.ColorSchema.Should().Be(ColorSchema.blue);
        }

        /// <summary>Converts the failed with empty base theme but set color schema.</summary>
        [TestMethod]
        public void ConvertFailedWithEmptyBaseThemeButSetColorSchema()
        {
            var theme = ThemeConverter.Convert(string.Empty, "red");

            theme.BaseTheme.Should().Be(BaseTheme.light);
            theme.ColorSchema.Should().Be(ColorSchema.blue);
        }

        /// <summary>Converts the failed with empty color schema.</summary>
        [TestMethod]
        public void ConvertFailedWithEmptyColorSchema()
        {
            var theme = ThemeConverter.Convert("dark. ");

            theme.BaseTheme.Should().Be(BaseTheme.light);
            theme.ColorSchema.Should().Be(ColorSchema.blue);
        }

        /// <summary>Converts the failed with empty color schema but set base theme.</summary>
        [TestMethod]
        public void ConvertFailedWithEmptyColorSchemaButSetBaseTheme()
        {
            var theme = ThemeConverter.Convert("dark", string.Empty);

            theme.BaseTheme.Should().Be(BaseTheme.light);
            theme.ColorSchema.Should().Be(ColorSchema.blue);
        }

        /// <summary>Converts the failed with not correct base theme.</summary>
        [TestMethod]
        public void ConvertFailedWithNotCorrectBaseTheme()
        {
            var theme = ThemeConverter.Convert("asdf", "red");

            theme.BaseTheme.Should().Be(BaseTheme.light);
            theme.ColorSchema.Should().Be(ColorSchema.blue);
        }

        /// <summary>Converts the failed with not correct color schema.</summary>
        [TestMethod]
        public void ConvertFailedWithNotCorrectColorSchema()
        {
            var theme = ThemeConverter.Convert("light", "asdf");

            theme.BaseTheme.Should().Be(BaseTheme.light);
            theme.ColorSchema.Should().Be(ColorSchema.blue);
        }

        /// <summary>Converts the failed with null.</summary>
        [TestMethod]
        public void ConvertFailedWithNull()
        {
            var theme = ThemeConverter.Convert(null);

            theme.BaseTheme.Should().Be(BaseTheme.light);
            theme.ColorSchema.Should().Be(ColorSchema.blue);
        }

        /// <summary>Converts the failed with to much entries.</summary>
        [TestMethod]
        public void ConvertFailedWithToMuchEntries()
        {
            var theme = ThemeConverter.Convert("light.red.contrast");

            theme.BaseTheme.Should().Be(BaseTheme.light);
            theme.ColorSchema.Should().Be(ColorSchema.blue);
        }

        #endregion Public Methods
    }
}