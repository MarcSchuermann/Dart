//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using Dart;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Game.UserInterface.Views.DartGameViewTests
{
    /// <summary>
    /// The construcotr test.
    /// </summary>
    [TestClass]
    public class ConstructorTests
    {
        #region Public Methods

        /// <summary>Noes the crash when initialize.</summary>
        [TestMethod]
        public void NoCrashWhenInitialize()
        {
            var dartGameView = new DartGameView();
        }

        /// <summary>Noes the crash when initialize with dev UI data.</summary>
        [TestMethod]
        public void NoCrashWhenInitializeWithDevUiData()
        {
            //var applicationSettingsSerializer = new ApplicationSettingsSerializer();
            //applicationSettingsSerializer.SerializeApplicationSettings(new ApplicationSettings() { ShowUserInterfaceDartBoardData = true });

            //var dartGameView = new DartGameView();
        }

        #endregion Public Methods
    }
}