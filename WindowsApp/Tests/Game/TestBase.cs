//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Schuermann.Dart.App.Game.Interfaces;
using Schuermann.Dart.App.Settings.Interfaces;
using Schuermann.Dart.Core.Game;

namespace UnitTests.Game
{
   /// <summary>The unit test base.</summary>
   [TestClass]
    [ExcludeFromCodeCoverage]
    public class TestBase
    {
        #region Public Methods

        /// <summary>Gets the main window view model mock.</summary>
        /// <returns>The mock.</returns>
        public static Mock<IMainWindowViewModel> GetMainWindowViewModelMock()
        {
            var playerList = new List<IPlayer>();
            var player = new Player("Hannes", 666);
            playerList.Add(player);

            return GetMainWindowViewModelMock(playerList);
        }

        /// <summary>Gets the main window view model mock.</summary>
        /// <param name="playerlist">The player list.</param>
        /// <param name="allPlayTillZero">if set to <c>true</c> [all play till zero].</param>
        /// <returns>The mock.</returns>
        public static Mock<IMainWindowViewModel> GetMainWindowViewModelMock(List<IPlayer> playerlist)
        {
            var mainWindowViewModelMock = new Mock<IMainWindowViewModel>();
            var configuredGameOptions = new Mock<IGameOptions>();

            configuredGameOptions.SetupGet(x => x.PlayerList).Returns(playerlist);
            mainWindowViewModelMock.SetupGet(x => x.ConfiguredGameOptions).Returns(configuredGameOptions.Object);

            var currentApplicationSettings = new Mock<IApplicationSettings>();

            var applicationSettingsViewModel = new Mock<IApplicationSettingsViewModel>();
            applicationSettingsViewModel.SetupGet(x => x.CurrentApplicationSettings).Returns(currentApplicationSettings.Object);

            mainWindowViewModelMock.SetupGet(x => x.SettingsViewModel).Returns(applicationSettingsViewModel.Object);

            return mainWindowViewModelMock;
        }

        #endregion Public Methods
    }
}