// -----------------------------------------------------------------------
// <copyright file="ConstructorTest.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schuermann.Darts.GameCore.Game;

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
            var player = new Player("Hans", 301);
            var playerList = new List<IPlayer>() { player };
            var gameOptions = new GameOptions(playerList);

            var game = new GameProcedure(gameOptions);

            Assert.AreEqual(gameOptions, game.Instance.GameOptions);
            Assert.AreEqual(player, game.Instance.CurrentPlayer);
        }

        #endregion Public Methods
    }
}