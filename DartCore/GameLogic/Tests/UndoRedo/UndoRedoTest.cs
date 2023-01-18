using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schuermann.Darts.GameCore.Game;
using Schuermann.Darts.GameCore.Thrown;

namespace Schuermann.Darts.GameCore.Tests.UndoRedo
{
    /// <summary>The undo redo player test</summary>
    [TestClass]
    public class UndoRedoTest
    {
        #region Public Methods

        /// <summary>Undoes for player.</summary>
        [TestMethod]
        public void UndoForPlayerCount1()
        {
            var dartThrows = new List<IDartThrow> { new DartThrow(DartBoardField.Two, DartBoardQuantifier.Single), new DartThrow(DartBoardField.Ten, DartBoardQuantifier.Double) };
            var player = new Player("Willy", 100) { ThrowHistory = dartThrows };
            var playerClone = player.Clone() as IPlayer;

            var options = new GameOptions(new List<IPlayer> { player });
            var game = new GameProcedure(options);

            game.PlayerThrown(new DartThrow(DartBoardField.Ten, DartBoardQuantifier.Triple));

            player.CurrentScore.Should().Be(48);
            player.DartCountThisRound.Should().Be(0);
            player.PointsThisRound.Should().Be(0);
            player.Round.Should().Be(2);
            player.ThrowHistory.Count.Should().Be(3);

            player.Undo();

            player.CurrentScore.Should().Be(78);
            player.DartCountThisRound.Should().Be(2);
            player.PointsThisRound.Should().Be(22);
            player.Round.Should().Be(1);
            player.ThrowHistory.Count.Should().Be(2);

            player.Should().Be(playerClone);
        }

        [TestMethod]
        public void UndoFourTimesForTwoPlayer()
        {
            var player1 = new Player("Willy1", 100);
            var player2 = new Player("Willy2", 100);

            var options = new GameOptions(new List<IPlayer> { player1, player2 });
            var game = new GameProcedure(options);

            game.PlayerThrown(new DartThrow(DartBoardField.Two, DartBoardQuantifier.Single));

            game.PlayerThrown(new DartThrow(DartBoardField.Ten, DartBoardQuantifier.Double));

            game.PlayerThrown(new DartThrow(DartBoardField.Ten, DartBoardQuantifier.Triple));

            player1.CurrentScore.Should().Be(48);
            player1.DartCountThisRound.Should().Be(0);
            player1.PointsThisRound.Should().Be(0);
            player1.Round.Should().Be(2);
            player1.ThrowHistory.Count.Should().Be(3);

            game.Undo();

            player1.CurrentScore.Should().Be(78);
            player1.DartCountThisRound.Should().Be(2);
            player1.PointsThisRound.Should().Be(22);
            player1.Round.Should().Be(1);
            player1.ThrowHistory.Count.Should().Be(2);

            game.Undo();

            player1.CurrentScore.Should().Be(98);
            player1.DartCountThisRound.Should().Be(1);
            player1.PointsThisRound.Should().Be(2);
            player1.Round.Should().Be(1);
            player1.ThrowHistory.Count.Should().Be(1);

            game.Undo();

            player1.CurrentScore.Should().Be(100);
            player1.DartCountThisRound.Should().Be(0);
            player1.PointsThisRound.Should().Be(0);
            player1.Round.Should().Be(1);
            player1.ThrowHistory.Count.Should().Be(0);

            game.Undo();

            player1.CurrentScore.Should().Be(100);
            player1.DartCountThisRound.Should().Be(0);
            player1.PointsThisRound.Should().Be(0);
            player1.Round.Should().Be(1);
            player1.ThrowHistory.Count.Should().Be(0);
        }

        [TestMethod]
        public void UndoTwiceForTwoPlayerWithSetThrowHistory()
        {
            var dartThrows = new List<IDartThrow> { new DartThrow(DartBoardField.Two, DartBoardQuantifier.Single), new DartThrow(DartBoardField.Ten, DartBoardQuantifier.Double) };
            var player1 = new Player("Willy", 100) { ThrowHistory = dartThrows };
            var player2 = new Player("Willy", 100) { ThrowHistory = dartThrows };

            var options = new GameOptions(new List<IPlayer> { player1, player2 });
            var game = new GameProcedure(options);

            game.PlayerThrown(new DartThrow(DartBoardField.Ten, DartBoardQuantifier.Triple));

            player1.CurrentScore.Should().Be(48);
            player1.DartCountThisRound.Should().Be(0);
            player1.PointsThisRound.Should().Be(0);
            player1.Round.Should().Be(2);
            player1.ThrowHistory.Count.Should().Be(3);

            player1.Undo();

            player1.CurrentScore.Should().Be(78);
            player1.DartCountThisRound.Should().Be(2);
            player1.PointsThisRound.Should().Be(22);
            player1.Round.Should().Be(1);
            player1.ThrowHistory.Count.Should().Be(2);

            player1.Undo();

            // Undo stack is empty because throw history was set.
            player1.CurrentScore.Should().Be(78);
            player1.DartCountThisRound.Should().Be(2);
            player1.PointsThisRound.Should().Be(22);
            player1.Round.Should().Be(1);
            player1.ThrowHistory.Count.Should().Be(2);
        }

        [TestMethod]
        public void UndoWhenChangePlayer()
        {
            var player1 = new Player("Willy1", 100);
            var player2 = new Player("Willy2", 100);

            var options = new GameOptions(new List<IPlayer> { player1, player2 });
            var game = new GameProcedure(options);

            game.PlayerThrown(new DartThrow(DartBoardField.Two, DartBoardQuantifier.Single));

            game.PlayerThrown(new DartThrow(DartBoardField.Ten, DartBoardQuantifier.Double));

            game.PlayerThrown(new DartThrow(DartBoardField.Ten, DartBoardQuantifier.Triple));

            game.PlayerThrown(new DartThrow(DartBoardField.One, DartBoardQuantifier.Single));

            player1.CurrentScore.Should().Be(48);
            player1.DartCountThisRound.Should().Be(0);
            player1.PointsThisRound.Should().Be(0);
            player1.Round.Should().Be(2);
            player1.ThrowHistory.Count.Should().Be(3);

            player2.CurrentScore.Should().Be(99);
            player2.DartCountThisRound.Should().Be(1);
            player2.PointsThisRound.Should().Be(1);
            player2.Round.Should().Be(1);
            player2.ThrowHistory.Count.Should().Be(1);

            game.Instance.CurrentPlayer.Name.Should().Be("Willy2");

            game.Undo();

            player1.CurrentScore.Should().Be(48);
            player1.DartCountThisRound.Should().Be(0);
            player1.PointsThisRound.Should().Be(0);
            player1.Round.Should().Be(2);
            player1.ThrowHistory.Count.Should().Be(3);

            player2.CurrentScore.Should().Be(100);
            player2.DartCountThisRound.Should().Be(0);
            player2.PointsThisRound.Should().Be(0);
            player2.Round.Should().Be(1);
            player2.ThrowHistory.Count.Should().Be(0);

            game.Instance.CurrentPlayer.Name.Should().Be("Willy2");

            game.Undo();

            player1.CurrentScore.Should().Be(78);
            player1.DartCountThisRound.Should().Be(2);
            player1.PointsThisRound.Should().Be(22);
            player1.Round.Should().Be(1);
            player1.ThrowHistory.Count.Should().Be(2);

            player2.CurrentScore.Should().Be(100);
            player2.DartCountThisRound.Should().Be(0);
            player2.PointsThisRound.Should().Be(0);
            player2.Round.Should().Be(1);
            player2.ThrowHistory.Count.Should().Be(0);

            game.Instance.CurrentPlayer.Name.Should().Be("Willy1");
        }

        #endregion Public Methods
    }
}