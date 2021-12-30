//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using Dart;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace UnitTests.Game.UserInterface.ViewModels.DartGameViewModelTests
{
    /// <summary>The constructor tests.</summary>
    /// <seealso cref="UnitTests.Game.TestBase"/>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ConstructorTests : TestBase
    {
        #region Public Methods

        /// <summary>Initialized the correct.</summary>
        [TestMethod]
        public void InitializedCorrect()
        {
            var getMainWindowViewModelMock = GetMainWindowViewModelMock();

            var dartGameViewModel = new DartGameViewModel(getMainWindowViewModelMock.Object);

            Assert.AreEqual("Hannes", dartGameViewModel.Game.CurrentPlayer.Name);
        }

        #endregion Public Methods
    }
}