////// --------------------------------------------------------------------------------------------------------------------
////// <copyright>Marc Schürmann</copyright>
////// --------------------------------------------------------------------------------------------------------------------

//using Dart;
//using GameLogic.Player;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Collections.Generic;
//using System.Diagnostics.CodeAnalysis;

//namespace UnitTests.Game.UserInterface.ViewModels.DartGameViewModelTests
//{
//    /// <summary>The go to next player tests.</summary>
//    /// <seealso cref="UnitTests.Game.TestBase"/>
//    [TestClass]
//    [ExcludeFromCodeCoverage]
//    public class GoToNextPlayerTests : TestBase
//    {
//        #region Public Methods

//        /// <summary>
//        /// Goes the not to next player when inactive player has zero points and all play till zero
//        /// is false.
//        /// </summary>
//        [TestMethod]
//        public void GoNotToNextPlayerWhenInactivePlayerHasZeroPointsAndAllPlayTillZeroIsFalse()
//        {
//            var playerlist = new List<IPlayer>();

//            var player1 = new Player() { Name = "PlayerOne", CurrentScore = 12 };
//            var player2 = new Player() { Name = "PlayerTwo", CurrentScore = 0 };

//            playerlist.Add(player1);
//            playerlist.Add(player2);

//            var mainWindowViewModelMock = GetMainWindowViewModelMock(playerlist, false);

//            var dartGameViewModel = new DartGameViewModel(mainWindowViewModelMock.Object);

//            dartGameViewModel.CurrentPlayer = player1;
//            dartGameViewModel.GoToNextPlayer();

//            Assert.AreEqual(player1, dartGameViewModel.CurrentPlayer);
//        }

//        /// <summary>
//        /// Goes the not to next player when next player has zero points and all play till zero is true.
//        /// </summary>
//        [TestMethod]
//        public void GoNotToNextPlayerWhenNextPlayerHasZeroPointsAndAllPlayTillZeroIsTrue()
//        {
//            var playerlist = new List<IPlayer>();

//            var player1 = new Player() { Name = "PlayerOne", CurrentScore = 12 };
//            var player2 = new Player() { Name = "PlayerTwo", CurrentScore = 0 };

//            playerlist.Add(player1);
//            playerlist.Add(player2);

//            var mainWindowViewModelMock = GetMainWindowViewModelMock(playerlist, true);

//            var dartGameViewModel = new DartGameViewModel(mainWindowViewModelMock.Object);

//            dartGameViewModel.CurrentPlayer = player1;
//            dartGameViewModel.GoToNextPlayer();

//            Assert.AreEqual(player1, dartGameViewModel.CurrentPlayer);
//        }

//        /// <summary>
//        /// Goes to next player when current player has zero points and all play till zero is true.
//        /// </summary>
//        [TestMethod]
//        public void GoToNextPlayerWhenCurrentPlayerHasZeroPointsAndAllPlayTillZeroIsTrue()
//        {
//            var playerlist = new List<IPlayer>();

//            var player1 = new Player() { Name = "PlayerOne", CurrentScore = 12 };
//            var player2 = new Player() { Name = "PlayerTwo", CurrentScore = 0 };

//            playerlist.Add(player1);
//            playerlist.Add(player2);

//            var mainWindowViewModelMock = GetMainWindowViewModelMock(playerlist, true);

//            var dartGameViewModel = new DartGameViewModel(mainWindowViewModelMock.Object);

//            dartGameViewModel.CurrentPlayer = player2;
//            dartGameViewModel.GoToNextPlayer();

//            Assert.AreEqual(player1, dartGameViewModel.CurrentPlayer);
//        }

//        /// <summary>No current player go to next player.</summary>
//        [TestMethod]
//        public void NoCurrentPlayerGoToNextPlayer()
//        {
//            var playerlist = new List<IPlayer>();

//            var player1 = new Player() { Name = "PlayerOne", CurrentScore = 345 };
//            var player2 = new Player() { Name = "PlayerTwo", CurrentScore = 258 };
//            var player3 = new Player() { Name = "PlayerThree", CurrentScore = 963 };

//            playerlist.Add(player1);
//            playerlist.Add(player2);
//            playerlist.Add(player3);

//            var mainWindowViewModelMock = GetMainWindowViewModelMock(playerlist);

//            var dartGameViewModel = new DartGameViewModel(mainWindowViewModelMock.Object);

//            Assert.AreEqual(player1, dartGameViewModel.CurrentPlayer);

//            dartGameViewModel.GoToNextPlayer();

//            Assert.AreEqual(player2, dartGameViewModel.CurrentPlayer);
//        }

//        /// <summary>Overflows the go to next player.</summary>
//        [TestMethod]
//        public void OverflowGoToNextPlayer()
//        {
//            var playerlist = new List<IPlayer>();

//            var player1 = new Player() { Name = "PlayerOne", CurrentScore = 89 };
//            var player2 = new Player() { Name = "PlayerTwo", CurrentScore = 55 };
//            var player3 = new Player() { Name = "PlayerThree", CurrentScore = 321 };

//            playerlist.Add(player1);
//            playerlist.Add(player2);
//            playerlist.Add(player3);

//            var mainWindowViewModelMock = GetMainWindowViewModelMock(playerlist);

//            var dartGameViewModel = new DartGameViewModel(mainWindowViewModelMock.Object);

//            dartGameViewModel.Game.CurrentPlayer = player3;
//            dartGameViewModel.GoToNextPlayer();

//            Assert.AreEqual(player1, dartGameViewModel.CurrentPlayer);
//        }

//        /// <summary>Repeats the one player go to next player.</summary>
//        [TestMethod]
//        public void RepeatOnePlayerGoToNextPlayer()
//        {
//            var playerlist = new List<IPlayer>();

//            var player1 = new Player() { Name = "PlayerOne" };

//            playerlist.Add(player1);

//            var mainWindowViewModelMock = GetMainWindowViewModelMock(playerlist);

//            var dartGameViewModel = new DartGameViewModel(mainWindowViewModelMock.Object);

//            for (int i = 0; i < 10; i++)
//            {
//                Assert.AreEqual(player1, dartGameViewModel.CurrentPlayer);
//                dartGameViewModel.GoToNextPlayer();
//                Assert.AreEqual(player1, dartGameViewModel.CurrentPlayer);
//            }
//        }

//        /// <summary>Simple go to next player one.</summary>
//        [TestMethod]
//        public void SimplyGoToNextPlayer1()
//        {
//            var playerlist = new List<IPlayer>();

//            var player1 = new Player() { Name = "PlayerOne", CurrentScore = 7 };
//            var player2 = new Player() { Name = "PlayerTwo", CurrentScore = 123 };

//            playerlist.Add(player1);
//            playerlist.Add(player2);

//            var mainWindowViewModelMock = GetMainWindowViewModelMock(playerlist);

//            var dartGameViewModel = new DartGameViewModel(mainWindowViewModelMock.Object);

//            dartGameViewModel.CurrentPlayer = player1;
//            dartGameViewModel.GoToNextPlayer();

//            Assert.AreEqual(player2, dartGameViewModel.CurrentPlayer);
//        }

//        #endregion Public Methods
//    }
//}