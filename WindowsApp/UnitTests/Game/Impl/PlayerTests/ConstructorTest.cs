//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using GameLogic.DartThrow;
using GameLogic.Player;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace UnitTests.Game.Impl.PlayerTests
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
            var player = new Player();

            Assert.AreEqual(0, player.CurrentScore);
            Assert.AreEqual(0, player.DartCountThisRound);
            Assert.AreEqual(null, player.Name);
            Assert.AreEqual(0, player.PointsThisRound);
            Assert.AreEqual(0, player.Round);
            Assert.AreEqual(null, player.ThrowHistory);
        }

        /// <summary>Sets the parameter.</summary>
        [TestMethod]
        public void SetParameter()
        {
            var player = new Player();

            player.CurrentScore = 123;
            player.DartCountThisRound = 77;
            player.Name = "Hans";
            player.PointsThisRound = 180;
            player.Round = 7;
            player.ThrowHistory = new List<IDartThrow> { new DartThrow(DartBoardField.Twenty, DartBoardQuantifier.Triple), new DartThrow(DartBoardField.Twenty, DartBoardQuantifier.Single), new DartThrow(DartBoardField.Twelve, DartBoardQuantifier.Single) };

            Assert.AreEqual(123, player.CurrentScore);
            Assert.AreEqual(77, player.DartCountThisRound);
            Assert.AreEqual("Hans", player.Name);
            Assert.AreEqual(180, player.PointsThisRound);
            Assert.AreEqual(7, player.Round);
            Assert.AreEqual(3, player.ThrowHistory.Count);
            Assert.AreEqual(new DartThrow(DartBoardField.Twenty, DartBoardQuantifier.Triple), player.ThrowHistory[0]);
            Assert.AreEqual(new DartThrow(DartBoardField.Twenty, DartBoardQuantifier.Single), player.ThrowHistory[1]);
            Assert.AreEqual(new DartThrow(DartBoardField.Twelve, DartBoardQuantifier.Single), player.ThrowHistory[2]);
        }

        #endregion Public Methods
    }
}