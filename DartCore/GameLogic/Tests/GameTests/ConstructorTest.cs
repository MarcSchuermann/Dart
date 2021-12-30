// -----------------------------------------------------------------------
// <copyright file="ConstructorTest.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using GameLogic.GameOptions;
using GameLogic.GameProcedure;
using GameLogic.Player;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameLogicTests.GameTests
{
    /// <summary>Tests the constructor.</summary>
    [TestClass]
    public class ConstructorTest
    {
        #region Public Methods

        /// <summary>Initializeds the correct.</summary>
        [TestMethod]
        public void InitializedCorrect()
        {
            var player = new Player() { Name = "Hans" };
            var playerList = new List<IPlayer>() { player };
            var gameOptions = new GameOptions() { PlayerList = playerList };

            var game = new GameProcedure(gameOptions);

            Assert.AreEqual(gameOptions, game.GameOptions);
            Assert.AreEqual(player, game.CurrentPlayer);
        }

        #endregion Public Methods
    }
}