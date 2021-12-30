//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using GameLogic.GameOptions;
using GameLogic.Player;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace UnitTests.Game.Impl.GameOptionsTests
{
    /// <summary>The constructor test.</summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ConstructorTest
    {
        #region Public Methods

        /// <summary>Initialization the should be correct.</summary>
        [TestMethod]
        public void InitializationShouldBeCorrect()
        {
            var gameOptions = new GameOptions();

            Assert.AreEqual(false, gameOptions.DoubleIn);
            Assert.AreEqual(false, gameOptions.DoubleOut);
            Assert.AreEqual(null, gameOptions.PlayerList);
            Assert.AreEqual(0, gameOptions.StartPoints);
        }

        /// <summary>Sets the parameter.</summary>
        [TestMethod]
        public void SetParameter()
        {
            var gameOptions = new GameOptions();

            gameOptions.DoubleIn = true;
            gameOptions.DoubleOut = true;
            gameOptions.PlayerList = new List<IPlayer> { new Player() { Name = "Detlef" }, new Player() { Name = "Dieter" } };
            gameOptions.StartPoints = 301;

            Assert.AreEqual(true, gameOptions.DoubleIn);
            Assert.AreEqual(true, gameOptions.DoubleOut);
            Assert.AreEqual(2, gameOptions.PlayerList.Count);
            Assert.AreEqual(2, gameOptions.PlayerList.Count);
            Assert.AreEqual("Detlef", gameOptions.PlayerList[0].Name);
            Assert.AreEqual("Dieter", gameOptions.PlayerList[1].Name);
            Assert.AreEqual(301, gameOptions.StartPoints);
        }

        #endregion Public Methods
    }
}