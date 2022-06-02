//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using Dart.Game.UserInterface.Converter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Game.UserInterface.Converter.ListToVisibilityConverterTests
{
    /// <summary>The convert back tests.</summary>
    [TestClass]
    public class ConvertBackTests
    {
        #region Public Methods

        /// <summary>Converts the back.</summary>
        [TestMethod]
        [ExcludeFromCodeCoverage]
        public void ConvertBack()
        {
            var converter = new ListToVisibilityConverter();

            Assert.IsNull(converter.ConvertBack(null, null, null, null));
        }

        #endregion Public Methods
    }
}