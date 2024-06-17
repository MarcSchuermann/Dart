// -----------------------------------------------------------------------
// <copyright file="ThrownTest.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schuermann.Dart.Core.Game;
using Schuermann.Dart.Core.Thrown;
using Schuermann.Darts.GameCore.Game;

namespace GameLogicTests.GameTests
{
   [TestClass]
    public class ThrownTest
    {
        #region Public Methods

        [TestMethod]
        public void AllPlayerZeroPointsThrown()
        {
            var player1 = new Player("Hans", 0);
            var player2 = new Player("Dieter", 0);

            var playerList = new List<IPlayer>() { player1, player2 };
            var gameOptions = new GameOptions(playerList);

            var game = new GameProcedure(gameOptions);

            var thrown = game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Single));

            thrown.Should().Be(true);
        }

        [TestMethod]
        public void NextPlayerHasZeroPointsButAllPlayTillZeroThrown()
        {
            var player1 = new Player("Hans", 2);
            var player2 = new Player("Dieter", 0);

            var playerList = new List<IPlayer>() { player1, player2 };
            var gameOptions = new GameOptions(playerList);

            var game = new GameProcedure(gameOptions);

            var thrown = game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Single));

            Assert.IsFalse(thrown);
        }

        [TestMethod]
        public void OnePlayerHasZeroPointsButAllPlayTillZeroThrown()
        {
            var player1 = new Player("Hans", 0);
            var player2 = new Player("Dieter", 100);

            var playerList = new List<IPlayer>() { player1, player2 };
            var gameOptions = new GameOptions(playerList);

            var game = new GameProcedure(gameOptions);

            var thrown = game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Single));

            Assert.IsFalse(thrown);
        }

        [TestMethod]
        public void PlayerThirdThrowGoToNextPlayer()
        {
            var player1 = new Player("Hans", 10);
            var player2 = new Player("Dieter", 6);

            var playerList = new List<IPlayer>() { player1, player2 };
            var gameOptions = new GameOptions(playerList);

            var game = new GameProcedure(gameOptions);

            game.PlayerThrown(new DartThrow(DartBoardField.Two, DartBoardQuantifier.Single));

            game.Instance.CurrentPlayer.Should().Be(player1);
        }

        [TestMethod]
        public void PlayerThrownBelowZero()
        {
            var player = new Player("Hans", 10);
            var playerList = new List<IPlayer>() { player };
            var gameOptions = new GameOptions(playerList);

            var game = new GameProcedure(gameOptions);

            game.PlayerThrown(new DartThrow(DartBoardField.Twenty, DartBoardQuantifier.Single));

            game.Instance.CurrentPlayer.CurrentScore.Should().Be(10);
        }

        /// <summary>Players the thrown below zero go to next player.</summary>
        [TestMethod]
        public void PlayerThrownBelowZeroGoToNextPlayer()
        {
            var player1 = new Player("Hans", 10);
            var player2 = new Player("Dieter", 6);

            var playerList = new List<IPlayer>() { player1, player2 };
            var gameOptions = new GameOptions(playerList);

            var game = new GameProcedure(gameOptions);

            game.PlayerThrown(new DartThrow(DartBoardField.Twenty, DartBoardQuantifier.Single));

            Assert.AreEqual(player2, game.Instance.CurrentPlayer);
        }

        [TestMethod]
        public void PlayerThrownSuccesfully()
        {
            var player = new Player("Hans", 100);
            var playerList = new List<IPlayer>() { player };
            var gameOptions = new GameOptions(playerList);

            var game = new GameProcedure(gameOptions);

            game.PlayerThrown(new DartThrow(DartBoardField.Twenty, DartBoardQuantifier.Single));

            game.Instance.CurrentPlayer.CurrentScore.Should().Be(80);
        }

        [TestMethod]
        public void PlayerThrownToZero()
        {
            var player = new Player("Hans", 60);
            var playerList = new List<IPlayer>() { player };
            var gameOptions = new GameOptions(playerList);

            var game = new GameProcedure(gameOptions);

            var playerFinished = game.PlayerThrown(new DartThrow(DartBoardField.Twenty, DartBoardQuantifier.Triple));

            playerFinished.Should().BeTrue();
            game.Instance.CurrentPlayer.CurrentScore.Should().Be(0);
        }

        #endregion Public Methods
    }
}