//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using Dart;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

namespace UnitTests.Game.UserInterface.ViewModels.MainWindowViewModelTests
{
    /// <summary>The constructor tests.</summary>
    /// <seealso cref="UnitTests.Game.TestBase"/>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ConstructorTests
    {
        #region Public Methods

        /// <summary>Initializeds the correct.</summary>
        [TestMethod]
        public void InitializedCorrect()
        {
            var mainWindowViewModel = new MainWindowViewModel();

            Assert.IsTrue(new Dictionary<CultureInfo, string> { { new CultureInfo("de-DE"), "Deutsch" }, { new CultureInfo("en-US"), "English" } }.SequenceEqual(mainWindowViewModel.AvailableLanguages));
            Assert.IsNull(mainWindowViewModel.ConfiguredGameOptions);
            Assert.IsInstanceOfType(mainWindowViewModel.CurrentContent, typeof(GameOptionsViewModel));
            Assert.IsInstanceOfType(mainWindowViewModel.SettingsViewModel, typeof(ApplicationSettingsViewModel));
            Assert.IsInstanceOfType(mainWindowViewModel.ToolBarViewModel, typeof(ToolBarViewModel));
        }

        #endregion Public Methods
    }
}