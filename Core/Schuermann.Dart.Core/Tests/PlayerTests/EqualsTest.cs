// -----------------------------------------------------------------------
// <copyright file="EqualsTest.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schuermann.Dart.Core.Game;
using Schuermann.Dart.Core.Thrown;
using Schuermann.Darts.GameCore.Game;

namespace Schuermann.Darts.GameCore.Tests.PlayerTests
{
   [TestClass]
    public class EqualsTest
    {
        #region Public Methods

        [TestMethod]
        public void CloneShouldBeEqual()
        {
            var player1 = new Player("Ralle", 1000);
            var player2 = player1.Clone() as IPlayer;

            player1.Should().Be(player2);
        }

        [TestMethod]
        public void GeneratedInstancesShouldBeEqual()
        {
            var dartThrows1 = new List<IDartThrow> { new DartThrow(DartBoardField.Zero, DartBoardQuantifier.Triple), new DartThrow(DartBoardField.Seven, DartBoardQuantifier.Double) };
            var dartThrows2 = new List<IDartThrow> { new DartThrow(DartBoardField.Zero, DartBoardQuantifier.Triple), new DartThrow(DartBoardField.Seven, DartBoardQuantifier.Double) };
            var player1 = new Player("Werner", 123) { ThrowHistory = dartThrows1 };
            var player2 = new Player("Werner", 123) { ThrowHistory = dartThrows2 };

            player1.Should().Be(player2);
        }

        [TestMethod]
        public void NameDiffersShouldNotBeEqual()
        {
            var dartThrows = new List<IDartThrow> { new DartThrow(DartBoardField.Zero, DartBoardQuantifier.Triple), new DartThrow(DartBoardField.Seven, DartBoardQuantifier.Double) };
            var player1 = new Player("Werner", 123) { ThrowHistory = dartThrows };
            var player2 = new Player("Wernei", 123) { ThrowHistory = dartThrows };

            player1.Should().NotBe(player2);
        }

        [TestMethod]
        public void TwoPlayerThrowSamePointsButDifferentQuantifierShouldNotBeEqual()
        {
            var dartThrows1 = new List<IDartThrow> { new DartThrow(DartBoardField.Zero, DartBoardQuantifier.Triple), new DartThrow(DartBoardField.Seven, DartBoardQuantifier.Double) };
            var dartThrows2 = new List<IDartThrow> { new DartThrow(DartBoardField.Zero, DartBoardQuantifier.Triple), new DartThrow(DartBoardField.Seven, DartBoardQuantifier.Double) };
            var player1 = new Player("Werner", 123) { ThrowHistory = dartThrows1 };
            var player2 = new Player("Werner", 123) { ThrowHistory = dartThrows2 };

            player1.Thrown(new DartThrow(DartBoardField.Two, DartBoardQuantifier.Single));
            player2.Thrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Single));
            player2.Thrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Single));

            player1.Should().NotBe(player2);
        }

        [TestMethod]
        public void TwoPlayerThrowSameShouldBeEqual()
        {
            var dartThrows1 = new List<IDartThrow> { new DartThrow(DartBoardField.Zero, DartBoardQuantifier.Triple), new DartThrow(DartBoardField.Seven, DartBoardQuantifier.Double) };
            var dartThrows2 = new List<IDartThrow> { new DartThrow(DartBoardField.Zero, DartBoardQuantifier.Triple), new DartThrow(DartBoardField.Seven, DartBoardQuantifier.Double) };
            var player1 = new Player("Werner", 123) { ThrowHistory = dartThrows1 };
            var player2 = new Player("Werner", 123) { ThrowHistory = dartThrows2 };

            player1.Thrown(new DartThrow(DartBoardField.Seven, DartBoardQuantifier.Single));
            player2.Thrown(new DartThrow(DartBoardField.Seven, DartBoardQuantifier.Single));

            player1.Should().Be(player2);
        }

        #endregion Public Methods
    }
}