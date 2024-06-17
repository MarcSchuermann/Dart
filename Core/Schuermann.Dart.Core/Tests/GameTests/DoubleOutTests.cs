// -----------------------------------------------------------------------
// <copyright file="DoubleOutTests.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schuermann.Darts.GameCore.Game;
using Schuermann.Darts.GameCore.Tests.Utils;
using Schuermann.Darts.GameCore.Thrown;

namespace Schuermann.Darts.GameCore.Tests.GameTests
{
    [TestClass]
    public class DoubleOutTests
    {
        #region Public Methods

        [TestMethod]
        public void DoubleOutThrowToOnePoint()
        {
            var player = new Player("Hans", 10, false, true);

            var game = GameUtils.SetupGame(new List<IPlayer>() { player });

            player.Validate(10, 0, 1, 0);

            game.PlayerThrown(new DartThrow(DartBoardField.Nine, DartBoardQuantifier.Single));

            player.Validate(10, 1, 2, 0);

            game.PlayerThrown(new DartThrow(DartBoardField.Ten, DartBoardQuantifier.Single));

            player.Validate(10, 2, 3, 0);
        }

        [TestMethod]
        public void DoubleOutShouldWorkOnFirstTry()
        {
            var player = new Player("Hans", 10, false, true);

            var game = GameUtils.SetupGame(new List<IPlayer>() { player });

            player.Validate(10, 0, 1, 0);

            game.PlayerThrown(new DartThrow(DartBoardField.Five, DartBoardQuantifier.Double));

            player.Validate(0, 1, 1, 1);
        }

        [TestMethod]
        public void DoubleOutShouldWorkOnSecondTry()
        {
            var player = new Player("Hans", 10, false, true);

            var game = GameUtils.SetupGame(new List<IPlayer>() { player });

            player.Validate(10, 0, 1, 0);

            game.PlayerThrown(new DartThrow(DartBoardField.Ten, DartBoardQuantifier.Single));

            player.Validate(10, 1, 2, 0);

            game.PlayerThrown(new DartThrow(DartBoardField.Five, DartBoardQuantifier.Double));

            player.Validate(0, 2, 2, 1);
        }

        [TestMethod]
        public void DoubleOutShouldWorkOnThirdTry()
        {
            var player = new Player("Hans", 10, false, true);

            var game = GameUtils.SetupGame(new List<IPlayer>() { player });

            player.Validate(10, 0, 1, 0);

            game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Single));

            player.Validate(9, 1, 1, 1);

            game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Single));

            player.Validate(8, 2, 1, 2);

            game.PlayerThrown(new DartThrow(DartBoardField.Four, DartBoardQuantifier.Double));

            player.Validate(0, 3, 1, 3);
        }

        [TestMethod]
        public void DoubleOutShouldWorkOnFourthTry()
        {
            var player = new Player("Hans", 10, false, true);

            var game = GameUtils.SetupGame(new List<IPlayer>() { player });

            player.Validate(10, 0, 1, 0);

            game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Single));

            player.Validate(9, 1, 1, 1);

            game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Single));

            player.Validate(8, 2, 1, 2);

            game.PlayerThrown(new DartThrow(DartBoardField.Two, DartBoardQuantifier.Single));

            player.Validate(6, 3, 2, 0);

            game.PlayerThrown(new DartThrow(DartBoardField.Three, DartBoardQuantifier.Double));

            player.Validate(0, 4, 2, 1);
        }

        #endregion Public Methods
    }
}