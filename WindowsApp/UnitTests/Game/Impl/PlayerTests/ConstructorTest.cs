//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schuermann.Darts.GameCore.Game;
using Schuermann.Darts.GameCore.Thrown;

namespace UnitTests.Game.Impl.PlayerTests
{
    /// <summary>The constructor test.</summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ConstructorTest
    {
        #region Public Methods

        /// <summary>Initialization the should be correct.</summary>
        [TestMethod]
        public void InitializationShouldBeCorrect()
        {
            var player = new Player(string.Empty, 66);

            player.CurrentScore.Should().Be(66);
            player.DartCountThisRound.Should().Be(0);
            player.Name.Should().BeEmpty();
            player.PointsThisRound.Should().Be(0);
            player.Round.Should().Be(1);
            player.ThrowHistory.Count.Should().Be(0);
        }

        #endregion Public Methods
    }
}