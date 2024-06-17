// -----------------------------------------------------------------------
// <copyright file="DoubleInTests.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schuermann.Dart.Core.Game;
using Schuermann.Dart.Core.Thrown;
using Schuermann.Darts.GameCore.Game;

namespace Schuermann.Darts.GameCore.Tests.GameTests
{
   [TestClass]
    public class DoubleInTests
    {
        #region Public Methods

        [TestMethod]
        public void DoubleInShouldCountForTheFirstThrow()
        {
            var player1 = new Player("Hans", 100, true, false);

            var playerList = new List<IPlayer>() { player1 };
            var gameOptions = new GameOptions(playerList);
            var game = new GameProcedure(gameOptions);

            player1.CurrentScore.Should().Be(100);
            player1.ThrowHistory.Count.Should().Be(0);
            player1.Round.Should().Be(1);
            player1.DartCountThisRound.Should().Be(0);

            game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Double));

            player1.CurrentScore.Should().Be(98);
            player1.ThrowHistory.Count.Should().Be(1);
            player1.Round.Should().Be(1);
            player1.DartCountThisRound.Should().Be(1);

            game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Single));

            player1.CurrentScore.Should().Be(97);
            player1.ThrowHistory.Count.Should().Be(2);
            player1.Round.Should().Be(1);
            player1.DartCountThisRound.Should().Be(2);

            game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Triple));

            player1.CurrentScore.Should().Be(94);
            player1.ThrowHistory.Count.Should().Be(3);
            player1.Round.Should().Be(2);
            player1.DartCountThisRound.Should().Be(0);

            game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Double));

            player1.CurrentScore.Should().Be(92);
            player1.ThrowHistory.Count.Should().Be(4);
            player1.Round.Should().Be(2);
            player1.DartCountThisRound.Should().Be(1);

            game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Single));

            player1.CurrentScore.Should().Be(91);
            player1.ThrowHistory.Count.Should().Be(5);
            player1.Round.Should().Be(2);
            player1.DartCountThisRound.Should().Be(2);

            game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Triple));

            player1.CurrentScore.Should().Be(88);
            player1.ThrowHistory.Count.Should().Be(6);
            player1.Round.Should().Be(3);
            player1.DartCountThisRound.Should().Be(0);
        }

        [TestMethod]
        public void DoubleInShouldCountForTheSecondThrow()
        {
            var player1 = new Player("Hans", 100, true, false);

            var playerList = new List<IPlayer>() { player1 };
            var gameOptions = new GameOptions(playerList);
            var game = new GameProcedure(gameOptions);

            player1.CurrentScore.Should().Be(100);
            player1.ThrowHistory.Count.Should().Be(0);
            player1.Round.Should().Be(1);
            player1.DartCountThisRound.Should().Be(0);

            game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Single));

            player1.CurrentScore.Should().Be(100);
            player1.ThrowHistory.Count.Should().Be(1);
            player1.Round.Should().Be(1);
            player1.DartCountThisRound.Should().Be(1);

            game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Double));

            player1.CurrentScore.Should().Be(98);
            player1.ThrowHistory.Count.Should().Be(2);
            player1.Round.Should().Be(1);
            player1.DartCountThisRound.Should().Be(2);

            game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Single));

            player1.CurrentScore.Should().Be(97);
            player1.ThrowHistory.Count.Should().Be(3);
            player1.Round.Should().Be(2);
            player1.DartCountThisRound.Should().Be(0);
        }

        [TestMethod]
        public void DoubleInShouldCountForTheThirdThrow()
        {
            var player1 = new Player("Hans", 100, true, false);

            var playerList = new List<IPlayer>() { player1 };
            var gameOptions = new GameOptions(playerList);
            var game = new GameProcedure(gameOptions);

            player1.CurrentScore.Should().Be(100);
            player1.ThrowHistory.Count.Should().Be(0);
            player1.Round.Should().Be(1);
            player1.DartCountThisRound.Should().Be(0);

            game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Single));

            player1.CurrentScore.Should().Be(100);
            player1.ThrowHistory.Count.Should().Be(1);
            player1.Round.Should().Be(1);
            player1.DartCountThisRound.Should().Be(1);

            game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Triple));

            player1.CurrentScore.Should().Be(100);
            player1.ThrowHistory.Count.Should().Be(2);
            player1.Round.Should().Be(1);
            player1.DartCountThisRound.Should().Be(2);

            game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Double));

            player1.CurrentScore.Should().Be(98);
            player1.ThrowHistory.Count.Should().Be(3);
            player1.Round.Should().Be(2);
            player1.DartCountThisRound.Should().Be(0);

            game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Single));

            player1.CurrentScore.Should().Be(97);
            player1.ThrowHistory.Count.Should().Be(4);
            player1.Round.Should().Be(2);
            player1.DartCountThisRound.Should().Be(1);

            game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Triple));

            player1.CurrentScore.Should().Be(94);
            player1.ThrowHistory.Count.Should().Be(5);
            player1.Round.Should().Be(2);
            player1.DartCountThisRound.Should().Be(2);

            game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Double));

            player1.CurrentScore.Should().Be(92);
            player1.ThrowHistory.Count.Should().Be(6);
            player1.Round.Should().Be(3);
            player1.DartCountThisRound.Should().Be(0);
        }

        [TestMethod]
        public void DoubleInShouldNotCountForSingle()
        {
            var player1 = new Player("Hans", 10, true, false);

            var playerList = new List<IPlayer>() { player1 };
            var gameOptions = new GameOptions(playerList);
            var game = new GameProcedure(gameOptions);

            game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Single));

            player1.CurrentScore.Should().Be(10);
            player1.ThrowHistory.Count.Should().Be(1);
            player1.Round.Should().Be(1);
            player1.DartCountThisRound.Should().Be(1);

            game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Single));

            player1.CurrentScore.Should().Be(10);
            player1.ThrowHistory.Count.Should().Be(2);
            player1.Round.Should().Be(1);
            player1.DartCountThisRound.Should().Be(2);

            game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Single));

            player1.CurrentScore.Should().Be(10);
            player1.ThrowHistory.Count.Should().Be(3);
            player1.Round.Should().Be(2);
            player1.DartCountThisRound.Should().Be(0);
        }

        [TestMethod]
        public void DoubleInShouldNotCountForTriple()
        {
            var player1 = new Player("Hans", 100, true, false);

            var playerList = new List<IPlayer>() { player1 };
            var gameOptions = new GameOptions(playerList);
            var game = new GameProcedure(gameOptions);

            game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Triple));

            player1.CurrentScore.Should().Be(100);
            player1.ThrowHistory.Count.Should().Be(1);
            player1.Round.Should().Be(1);
            player1.DartCountThisRound.Should().Be(1);

            game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Triple));

            player1.CurrentScore.Should().Be(100);
            player1.ThrowHistory.Count.Should().Be(2);
            player1.Round.Should().Be(1);
            player1.DartCountThisRound.Should().Be(2);

            game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Triple));

            player1.CurrentScore.Should().Be(100);
            player1.ThrowHistory.Count.Should().Be(3);
            player1.Round.Should().Be(2);
            player1.DartCountThisRound.Should().Be(0);
        }

        #endregion Public Methods
    }
}