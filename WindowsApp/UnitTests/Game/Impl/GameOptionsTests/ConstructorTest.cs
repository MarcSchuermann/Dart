//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schuermann.Darts.GameCore.Game;

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
            var gameOptions = new GameOptions(Array.Empty<IPlayer>());

            Assert.AreEqual(false, gameOptions.DoubleIn);
            Assert.AreEqual(false, gameOptions.DoubleOut);
            gameOptions.PlayerList.Count().Should().Be(0);
            Assert.AreEqual(0, gameOptions.StartPoints);
        }

        /// <summary>Sets the parameter.</summary>
        [TestMethod]
        public void SetParameter()
        {
            var gameOptions = new GameOptions(new List<IPlayer> { new Player("Detlef", 301), new Player("Dieter", 301) })
            {
                DoubleIn = true,
                DoubleOut = true
            };

            Assert.AreEqual(true, gameOptions.DoubleIn);
            Assert.AreEqual(true, gameOptions.DoubleOut);
            Assert.AreEqual(2, gameOptions.PlayerList.Count());
            Assert.AreEqual(2, gameOptions.PlayerList.Count());
            Assert.AreEqual("Detlef", gameOptions.PlayerList.ToArray()[0].Name);
            Assert.AreEqual("Dieter", gameOptions.PlayerList.ToArray()[1].Name);
            Assert.AreEqual(301, gameOptions.StartPoints);
        }

        #endregion Public Methods
    }
}