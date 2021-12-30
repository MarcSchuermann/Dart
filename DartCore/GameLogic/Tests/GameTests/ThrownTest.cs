// -----------------------------------------------------------------------
// <copyright file="ThrownTest.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using GameLogic.DartThrow;
using GameLogic.GameOptions;
using GameLogic.GameProcedure;
using GameLogic.Player;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameLogicTests.GameTests
{
    /// <summary>Tests the method player thrown.</summary>
    [TestClass]
    public class ThrownTest
    {
        #region Public Methods

        /// <summary>Alls the player zero points thrown.</summary>
        [TestMethod]
        public void AllPlayerZeroPointsThrown()
        {
            var player1 = new Player() { Name = "Hans", CurrentScore = 0, };
            var player2 = new Player() { Name = "Dieter", CurrentScore = 0 };

            var playerList = new List<IPlayer>() { player1, player2 };
            var gameOptions = new GameOptions() { PlayerList = playerList, AllPlayTillZero = true };

            var game = new GameProcedure(gameOptions);

            var thrown = game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Single));

            Assert.IsFalse(thrown);
        }

        /// <summary>Nexts the player has zero points but all play till zero thrown.</summary>
        [TestMethod]
        public void NextPlayerHasZeroPointsButAllPlayTillZeroThrown()
        {
            var player1 = new Player() { Name = "Hans", CurrentScore = 2, DartCountThisRound = 2 };
            var player2 = new Player() { Name = "Dieter", CurrentScore = 0 };

            var playerList = new List<IPlayer>() { player1, player2 };
            var gameOptions = new GameOptions() { PlayerList = playerList, AllPlayTillZero = true };

            var game = new GameProcedure(gameOptions);

            var thrown = game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Single));

            Assert.IsFalse(thrown);
        }

        /// <summary>Called when [player has zero points but all play till zero thrown].</summary>
        [TestMethod]
        public void OnePlayerHasZeroPointsButAllPlayTillZeroThrown()
        {
            var player1 = new Player() { Name = "Hans", CurrentScore = 0, };
            var player2 = new Player() { Name = "Dieter", CurrentScore = 100 };

            var playerList = new List<IPlayer>() { player1, player2 };
            var gameOptions = new GameOptions() { PlayerList = playerList, AllPlayTillZero = false };

            var game = new GameProcedure(gameOptions);

            var thrown = game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Single));

            Assert.IsFalse(thrown);
        }

        /// <summary>Players the third throw go to next player.</summary>
        [TestMethod]
        public void PlayerThirdThrowGoToNextPlayer()
        {
            var player1 = new Player() { Name = "Hans", CurrentScore = 10, DartCountThisRound = 2 };
            var player2 = new Player() { Name = "Dieter", CurrentScore = 6 };

            var playerList = new List<IPlayer>() { player1, player2 };
            var gameOptions = new GameOptions() { PlayerList = playerList };

            var game = new GameProcedure(gameOptions);

            game.PlayerThrown(new DartThrow(DartBoardField.Two, DartBoardQuantifier.Single));

            Assert.AreEqual(player2, game.CurrentPlayer);
        }

        /// <summary>Players the thrown below zero.</summary>
        [TestMethod]
        public void PlayerThrownBelowZero()
        {
            var player = new Player() { Name = "Hans", CurrentScore = 10 };
            var playerList = new List<IPlayer>() { player };
            var gameOptions = new GameOptions() { PlayerList = playerList };

            var game = new GameProcedure(gameOptions);

            game.PlayerThrown(new DartThrow(DartBoardField.Twenty, DartBoardQuantifier.Single));

            Assert.AreEqual(10, game.CurrentPlayer.CurrentScore);
        }

        /// <summary>Players the thrown below zero go to next player.</summary>
        [TestMethod]
        public void PlayerThrownBelowZeroGoToNextPlayer()
        {
            var player1 = new Player() { Name = "Hans", CurrentScore = 10 };
            var player2 = new Player() { Name = "Dieter", CurrentScore = 6 };

            var playerList = new List<IPlayer>() { player1, player2 };
            var gameOptions = new GameOptions() { PlayerList = playerList };

            var game = new GameProcedure(gameOptions);

            game.PlayerThrown(new DartThrow(DartBoardField.Twenty, DartBoardQuantifier.Single));

            Assert.AreEqual(player2, game.CurrentPlayer);
        }

        /// <summary>Players the thrown succesfully.</summary>
        [TestMethod]
        public void PlayerThrownSuccesfully()
        {
            var player = new Player() { Name = "Hans", CurrentScore = 100 };
            var playerList = new List<IPlayer>() { player };
            var gameOptions = new GameOptions() { PlayerList = playerList };

            var game = new GameProcedure(gameOptions);

            game.PlayerThrown(new DartThrow(DartBoardField.Twenty, DartBoardQuantifier.Single));

            Assert.AreEqual(80, game.CurrentPlayer.CurrentScore);
        }

        /// <summary>Players the thrown succesfully current score changed.</summary>
        [TestMethod]
        public void PlayerThrownSuccesfullyCurrentScoreChanged()
        {
            var risenEvents = new List<string>();

            var player = new Player() { Name = "Hans", CurrentScore = 100 };
            var playerList = new List<IPlayer>() { player };
            var gameOptions = new GameOptions() { PlayerList = playerList };

            var game = new GameProcedure(gameOptions);
            game.PropertyChanged += (sender, e) =>
            {
                risenEvents.Add(e.PropertyName);
            };

            game.PlayerThrown(new DartThrow(DartBoardField.Twenty, DartBoardQuantifier.Single));

            Assert.AreEqual("CurrentScore", risenEvents.First());
        }

        /// <summary>Players the thrown to zero.</summary>
        [TestMethod]
        public void PlayerThrownToZero()
        {
            var player = new Player() { Name = "Hans", CurrentScore = 60 };
            var playerList = new List<IPlayer>() { player };
            var gameOptions = new GameOptions() { PlayerList = playerList };

            var game = new GameProcedure(gameOptions);

            var playerFinished = game.PlayerThrown(new DartThrow(DartBoardField.Twenty, DartBoardQuantifier.Triple));

            Assert.IsTrue(playerFinished);
            Assert.AreEqual(0, game.CurrentPlayer.CurrentScore);
        }

        #endregion Public Methods
    }
}