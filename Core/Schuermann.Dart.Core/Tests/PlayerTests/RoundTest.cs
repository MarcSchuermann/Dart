// -----------------------------------------------------------------------
// <copyright file="RoundTest.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schuermann.Darts.GameCore.Game;
using Schuermann.Darts.GameCore.Thrown;

namespace Schuermann.Darts.GameCore.Tests.PlayerTests
{
    [TestClass]
    public class RoundTest
    {
        #region Public Methods

        [TestMethod]
        public void Simple()
        {
            var udo = new Player("Udo", 10);

            Check(udo, 1, 0, 10);

            udo.Thrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Single));

            Check(udo, 1, 1, 9);

            udo.Thrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Single));

            Check(udo, 1, 2, 8);

            udo.Thrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Single));

            Check(udo, 2, 0, 7);

            udo.Thrown(new DartThrow(DartBoardField.Six, DartBoardQuantifier.Single));

            Check(udo, 2, 1, 1);

            udo.Thrown(new DartThrow(DartBoardField.Two, DartBoardQuantifier.Single));

            Check(udo, 3, 0, 1);
        }

        #endregion Public Methods

        #region Private Methods

        private static void Check(IPlayer player, int expectedRound, int expectedDartCountThisRound, uint expectedCurrentScore)
        {
            player.Round.Should().Be(expectedRound);
            player.DartCountThisRound.Should().Be(expectedDartCountThisRound);
            player.CurrentScore.Should().Be(expectedCurrentScore);
        }

        #endregion Private Methods
    }
}