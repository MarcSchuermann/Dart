//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using System.Globalization;
using Dart.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Settings.ApplicationSettingsTests
{
    /// <summary>The constructor test.</summary>
    [TestClass]
    public class ConstructorTests
    {
        #region Public Methods

        /// <summary>Initializes the correct.</summary>
        [TestMethod]
        public void InitializeCorrect()
        {
            var applicationSettings = new ApplicationSettings() { SelectedCultureInfo = new CultureInfo("de-DE"), ShowUserInterfaceDartBoardData = true };

            Assert.AreEqual(new CultureInfo("de-DE"), applicationSettings.SelectedCultureInfo);
            Assert.IsTrue(applicationSettings.ShowUserInterfaceDartBoardData);
        }

        #endregion Public Methods
    }
}