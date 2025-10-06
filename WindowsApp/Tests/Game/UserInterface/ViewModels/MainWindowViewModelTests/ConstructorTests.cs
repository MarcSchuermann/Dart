//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schuermann.Dart.App.Game.UserInterface.ViewModels;
using Schuermann.Dart.App.Settings.UserInterface.ViewModels;

namespace UnitTests.Game.UserInterface.ViewModels.MainWindowViewModelTests
{
   /// <summary>The constructor tests.</summary>
   /// <seealso cref="UnitTests.Game.TestBase" />
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
        }

        #endregion Public Methods
    }
}