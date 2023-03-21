// -----------------------------------------------------------------------
// <copyright file="PlayerUtils.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using FluentAssertions;
using Schuermann.Darts.GameCore.Game;

namespace Schuermann.Darts.GameCore.Tests.Utils
{
    /// <summary>Utils for the player.</summary>
    internal static class PlayerUtils
    {
        #region Public Methods

        /// <summary>Validates the specified expected score.</summary>
        /// <param name="player">The player.</param>
        /// <param name="expectedScore">The expected score.</param>
        public static void Validate(this IPlayer player, uint expectedScore)
        {
            player.CurrentScore.Should().Be(expectedScore);
        }

        /// <summary>Validates the specified expected score.</summary>
        /// <param name="player">The player.</param>
        /// <param name="expectedScore">The expected score.</param>
        /// <param name="expectedThrowHistoryCount">The expected throw history count.</param>
        /// <param name="expectedRound">The expected round.</param>
        /// <param name="expectedDartCountThisRound">The expected dart count this round.</param>
        public static void Validate(this IPlayer player, uint expectedScore, int expectedThrowHistoryCount, int expectedRound, int expectedDartCountThisRound)
        {
            player.CurrentScore.Should().Be(expectedScore);
            player.ThrowHistory.Count.Should().Be(expectedThrowHistoryCount);
            player.Round.Should().Be(expectedRound);
            player.DartCountThisRound.Should().Be(expectedDartCountThisRound);
        }

        #endregion Public Methods
    }
}