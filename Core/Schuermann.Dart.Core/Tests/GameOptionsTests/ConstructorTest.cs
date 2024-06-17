// -----------------------------------------------------------------------
// <copyright file="ConstructorTest.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schuermann.Darts.GameCore.Game;
using Schuermann.Darts.GameCore.Thrown;

namespace GameLogicTests.GameOptionsTests
{
    /// <summary>Tests for the game options.</summary>
    [TestClass]
    public class ConstructorTest
    {
        #region Public Methods

        /// <summary>Initializeds the correct.</summary>
        [TestMethod]
        public void InitializedCorrect()
        {
            var players = new List<IPlayer>();
            var gameOptions = new GameOptions(players);
            gameOptions.StartPoints.Should().Be(0);
            gameOptions.DoubleOut.Should().BeFalse();
            gameOptions.DoubleIn.Should().BeFalse();
            gameOptions.PlayerList.Should().BeEmpty();
        }

        /// <summary>Sets the correct.</summary>
        [TestMethod]
        public void SetCorrect()
        {
            var gameOptions = new GameOptions(new List<IPlayer> { new Player("Wolfi", 1), new Player("Didi", 2), new Player("Klausi", 3) })
            {
                StartPoints = 123,
                DoubleOut = true,
                DoubleIn = true,
            };

            gameOptions.StartPoints.Should().Be(123);
            gameOptions.DoubleOut.Should().BeTrue();
            gameOptions.DoubleIn.Should().BeTrue();
            gameOptions.PlayerList.Count().Should().Be(3);
        }

        #endregion Public Methods
    }
}