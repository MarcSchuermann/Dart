//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using Dart.Game.UserInterface.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Game.UserInterface.Views.DartGameViewTests
{
    /// <summary>The get current points test.</summary>
    [TestClass]
    public class CurrentPointsTests
    {
        #region Public Methods

        /// <summary>Gets the current points.</summary>
        [TestMethod]
        public void GetCurrentPoints()
        {
            ViewTestExecuter.Instance.Run(() =>
            {
                var dartGameView = new DartGameView();

                Assert.IsNull(dartGameView.CurrentPoints);
            });
        }

        #endregion Public Methods
    }
}