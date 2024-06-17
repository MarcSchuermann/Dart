//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using Dart;
using Dart.Common.UserInterface.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Game.UserInterface.ViewModels.MainWindowViewModelTests
{
    /// <summary>The StartGameCommandTests.</summary>
    [TestClass]
    public class StartGameCommandTests
    {
        #region Public Methods

        /// <summary>Starts the game command current player is correct.</summary>
        [TestMethod]
        public void StartGameCommandCurrentPlayerIsCorrect()
        {
            var mainWindowViewModel = new MainWindowViewModel();
            var gameSettingsViewModel = mainWindowViewModel.CurrentContent as GameOptionsViewModel;
            gameSettingsViewModel.PlayerlistViewModel.Playerlist = new ItemsChangeObservableCollection<PlayerViewModel>();
            gameSettingsViewModel.PlayerlistViewModel.Playerlist.Add(new PlayerViewModel("Hans-Dieter"));

            mainWindowViewModel.StartGame.Execute(null);

            Assert.AreEqual("Hans-Dieter", (mainWindowViewModel.CurrentContent as DartGameViewModel).Game.Instance.CurrentPlayer.Name);
        }

        /// <summary>Starts the game command set content to dart game.</summary>
        [TestMethod]
        public void StartGameCommandSetContentToDartGame()
        {
            var mainWindowViewModel = new MainWindowViewModel();
            var gameSettingsViewModel = mainWindowViewModel.CurrentContent as GameOptionsViewModel;
            gameSettingsViewModel.PlayerlistViewModel.Playerlist = new ItemsChangeObservableCollection<PlayerViewModel>();
            gameSettingsViewModel.PlayerlistViewModel.Playerlist.Add(new PlayerViewModel("Hans-Dieter"));

            mainWindowViewModel.StartGame.Execute(null);

            Assert.IsInstanceOfType(mainWindowViewModel.CurrentContent, typeof(DartGameViewModel));
        }

        #endregion Public Methods
    }
}