// -----------------------------------------------------------------------
// <copyright file="ConstructorTest.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using FluentAssertions;
using GameLogic.GameOptions;
using GameLogic.Player;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
            var gameOptions = new GameOptions();
            gameOptions.StartPoints.Should().Be(0);
            gameOptions.DoubleOut.Should().BeFalse();
            gameOptions.DoubleIn.Should().BeFalse();
            gameOptions.AllPlayTillZero.Should().BeFalse();
            gameOptions.PlayerList.Should().BeNull();
        }

        /// <summary>Sets the correct.</summary>
        [TestMethod]
        public void SetCorrect()
        {
            var gameOptions = new GameOptions();
            gameOptions.StartPoints = 123;
            gameOptions.DoubleOut = true;
            gameOptions.DoubleIn = true;
            gameOptions.AllPlayTillZero = true;
            gameOptions.PlayerList = new List<IPlayer> { new Player(), new Player(), new Player() };

            gameOptions.StartPoints.Should().Be(123);
            gameOptions.DoubleOut.Should().BeTrue();
            gameOptions.DoubleIn.Should().BeTrue();
            gameOptions.AllPlayTillZero.Should().BeTrue();
            gameOptions.PlayerList.Count.Should().Be(3);
        }

        #endregion Public Methods
    }
}