// -----------------------------------------------------------------------
// <copyright file="ConstructorTest.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
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
            var player = new Player() { CurrentScore = 666, DartCountThisRound = 69, Name = "Hans", PointsThisRound = 26, Round = 123, ThrowHistory = throwHistory };

            Assert.AreEqual(666, player.CurrentScore);
            Assert.AreEqual(69, player.DartCountThisRound);
            Assert.AreEqual("Hans", player.Name);
            Assert.AreEqual(26, player.PointsThisRound);
            Assert.AreEqual(123, player.Round);
            Assert.AreEqual(throwHistory, player.ThrowHistory);
        }

        #endregion Public Methods
    }
}