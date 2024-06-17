// -----------------------------------------------------------------------
// <copyright file="ConstructorTest.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schuermann.Darts.GameCore.Game;
using Schuermann.Darts.GameCore.Thrown;

namespace GameLogicTests.PlayerTests
{
    /// <summary>Tests the constructor.</summary>
    [TestClass]
    public class ConstructorTest
    {
        #region Public Methods

        /// <summary>Initializations the is correct.</summary>
        [TestMethod]
        public void InitializationIsCorrect()
        {
            var throwHistory = new List<IDartThrow> { new DartThrow(DartBoardField.One, DartBoardQuantifier.Single), new DartThrow(DartBoardField.Two, DartBoardQuantifier.Single), new DartThrow(DartBoardField.Three, DartBoardQuantifier.Single) };
            var player = new Player("Hans", 666) { ThrowHistory = throwHistory };

            player.CurrentScore.Should().Be(660);
            Assert.AreEqual(0, player.DartCountThisRound);
            Assert.AreEqual("Hans", player.Name);
            Assert.AreEqual(0, player.PointsThisRound);
            Assert.AreEqual(2, player.Round);
            Assert.AreEqual(throwHistory, player.ThrowHistory);
        }

        #endregion Public Methods
    }
}