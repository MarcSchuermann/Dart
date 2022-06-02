//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using System.Windows;
using Dart;
using Dart.Game.UserInterface.Converter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Game.UserInterface.Converter.ViewModelTypeToVisibilityConverterTests
{
    /// <summary>The convert tests.</summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ConvertTests
    {
        #region Public Methods

        /// <summary>Converts to invisible.</summary>
        [TestMethod]
        public void ConvertToInvisible()
        {
            var converter = new ViewModelTypeToVisibilityConverter();

            Assert.AreEqual(Visibility.Hidden, converter.Convert(null, null, null, null));
        }

        /// <summary>Converts to visible.</summary>
        [TestMethod]
        public void ConvertToVisible()
        {
            var converter = new ViewModelTypeToVisibilityConverter();

            var gameOptionsViewModel = new GameOptionsViewModel();

            Assert.AreEqual(Visibility.Visible, converter.Convert(gameOptionsViewModel, null, null, null));
        }

        #endregion Public Methods
    }
}