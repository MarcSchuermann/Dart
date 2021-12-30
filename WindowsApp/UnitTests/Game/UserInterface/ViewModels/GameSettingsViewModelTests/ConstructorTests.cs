//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using Dart;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

namespace UnitTests.Game.UserInterface.ViewModels.GameSettingsViewModelTests
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
            var gameSettingsViewModel = new GameSettingsViewModel();

            Assert.IsTrue(new List<int> { 301, 501, 701 }.SequenceEqual(gameSettingsViewModel.SelectableStartPoints));
            Assert.IsTrue(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 }.SequenceEqual(gameSettingsViewModel.SelectablePlayerCount));
            Assert.IsTrue(new Dictionary<CultureInfo, string> { { new CultureInfo("de-DE"), "Deutsch" }, { new CultureInfo("en-US"), "English" } }.SequenceEqual(gameSettingsViewModel.AvailableLanguages));
            Assert.IsNull(gameSettingsViewModel.SelectedPlayerCount);
            Assert.IsNull(gameSettingsViewModel.SelectedStartPoints);
        }

        /// <summary>Selecteds the player count set correct.</summary>
        [TestMethod]
        public void SelectedPlayerCountSetCorrect()
        {
            var gameSettingsViewModel = new GameSettingsViewModel() { SelectedPlayerCount = "5" };

            Assert.AreEqual("5", gameSettingsViewModel.SelectedPlayerCount);
        }

        /// <summary>Selecteds the start points set correct.</summary>
        [TestMethod]
        public void SelectedStartPointsSetCorrect()
        {
            var gameSettingsViewModel = new GameSettingsViewModel() { SelectedStartPoints = "501" };

            Assert.AreEqual("501", gameSettingsViewModel.SelectedStartPoints);
        }

        #endregion Public Methods
    }
}