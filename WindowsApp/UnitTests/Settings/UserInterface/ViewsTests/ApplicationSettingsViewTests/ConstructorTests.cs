//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using Dart;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Settings.UserInterface.ViewsTests.ApplicationSettingsViewTests
{
    /// <summary>
    /// The constructor test.
    /// </summary>
    [TestClass]
    public class ConstructorTests
    {
        #region Public Methods

        /// <summary>Noes the crash when creating object.</summary>
        [TestMethod]
        public void NoCrashWhenCreatingObject()
        {
            var applicationSettingsView = new ApplicationSettingsView();
        }

        #endregion Public Methods
    }
}