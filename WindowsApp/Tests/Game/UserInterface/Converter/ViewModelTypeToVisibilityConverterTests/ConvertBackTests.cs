//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schuermann.Dart.App.Common.UserInterface.Converter;

namespace UnitTests.Game.UserInterface.Converter.ViewModelTypeToVisibilityConverterTests
{
    /// <summary>The convert back tests.</summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ConvertBackTests
    {
        #region Public Methods

        /// <summary>Converts the back.</summary>
        [TestMethod]
        public void ConvertBack()
        {
            var converter = new ViewModelTypeToVisibilityConverter();

            Assert.IsNull(converter.ConvertBack(null, null, null, null));
        }

        #endregion Public Methods
    }
}