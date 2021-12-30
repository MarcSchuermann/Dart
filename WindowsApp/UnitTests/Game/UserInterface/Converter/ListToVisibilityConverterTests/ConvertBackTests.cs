//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using Dart;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

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