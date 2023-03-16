using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schuermann.Darts.GameCore.Game;
using Schuermann.Darts.GameCore.Save;
using Schuermann.Darts.GameCore.Thrown;

namespace Schuermann.Darts.GameCore.Tests.PersistTests
{
    /// <summary>Save and load tests.</summary>
    [TestClass]
    public class LoadSaveTest
    {
        #region Public Methods

        /// <summary>Creates the save and reload game correct.</summary>
        [TestMethod]
        public void CreateSaveAndReloadGameCorrect()
        {
            var players = new List<IPlayer> { new Player("Willi", 123), new Player("Hans", 666)};
            var gameOptions = new GameOptions(players);
            var gameInstance = new GameInstance(gameOptions);
            var stream = Persister.Save(gameInstance);

            gameInstance.Dispose();

            var loaded = Persister.Load(stream);
            loaded.CurrentPlayer.Name.Should().Be("Willi");
            loaded.CurrentPlayer.CurrentScore.Should().Be(123);
            loaded.GameOptions.PlayerList.Count().Should().Be(2);
        }

        /// <summary>Creates the save and reload single player complete.</summary>
        [TestMethod]
        public void CreateSaveAndReloadSinglePlayerComplete()
        {
            var players = new List<IPlayer> { new Player("Ralf", 666)};
            var gameOptions = new GameOptions(players);
            var gameInstance = new GameInstance(gameOptions);
            var gameProcedure = new GameProcedure(gameOptions);

            gameProcedure.PlayerThrown(new DartThrow(DartBoardField.Twenty, DartBoardQuantifier.Triple));

            var stream = Persister.Save(gameInstance);

            gameInstance.Dispose();

            var loaded = Persister.Load(stream);
            loaded.CurrentPlayer.Name.Should().Be("Ralf");
            loaded.CurrentPlayer.CurrentScore.Should().Be(606);
            loaded.CurrentPlayer.Round.Should().Be(1);
            loaded.CurrentPlayer.DartCountThisRound.Should().Be(1);
            loaded.CurrentPlayer.PointsThisRound.Should().Be(60);
            var throwHistory = new List<IDartThrow> { new DartThrow(DartBoardField.Twenty, DartBoardQuantifier.Triple) };
            loaded.CurrentPlayer.ThrowHistory.Should().BeEquivalentTo(throwHistory);

            loaded.GameOptions.PlayerList.Count().Should().Be(1);
        }

        /// <summary>Saves the with null.</summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SaveWithNull()
        {
            Persister.Save(null);
        }

        /// <summary>Writes to file.</summary>
        [TestMethod]
        public void WriteToFile()
        {
            var players = new List<IPlayer> { new Player("Ralf", 666)};
            var gameOptions = new GameOptions(players);
            var gameInstance = new GameInstance(gameOptions);
            var gameProcedure = new GameProcedure(gameOptions);
            gameProcedure.PlayerThrown(new DartThrow(DartBoardField.Two, DartBoardQuantifier.Single));
            gameProcedure.PlayerThrown(new DartThrow(DartBoardField.Fourteen, DartBoardQuantifier.Triple));

            var stream = Persister.Save(gameInstance);

            gameInstance.Dispose();

            var path = Path.GetTempFileName();
            var fileStream = new FileStream(path, FileMode.Open);
            stream.CopyTo(fileStream);

            fileStream.Flush();
            fileStream.Close();

            var readFile = File.ReadAllText(path);

            readFile.Should().Be("{\r\n  \"GameOption\": {\r\n    \"AllPlayTillZero\": false,\r\n    \"DoubleIn\": false,\r\n    \"DoubleOut\": false,\r\n    \"PlayerList\": [\r\n      {\r\n        \"Name\": \"Ralf\",\r\n        \"StartPoints\": 666,\r\n        \"ThrowHistory\": [\r\n          {\r\n            \"DartBoardField\": 2,\r\n            \"DartBoardQuantifier\": 1,\r\n            \"Points\": 2\r\n          },\r\n          {\r\n            \"DartBoardField\": 14,\r\n            \"DartBoardQuantifier\": 3,\r\n            \"Points\": 42\r\n          }\r\n        ]\r\n      }\r\n    ],\r\n    \"StartPoints\": 0\r\n  },\r\n  \"CurrentPlayer\": {\r\n    \"Name\": \"Ralf\",\r\n    \"StartPoints\": 666,\r\n    \"ThrowHistory\": [\r\n      {\r\n        \"DartBoardField\": 2,\r\n        \"DartBoardQuantifier\": 1,\r\n        \"Points\": 2\r\n      },\r\n      {\r\n        \"DartBoardField\": 14,\r\n        \"DartBoardQuantifier\": 3,\r\n        \"Points\": 42\r\n      }\r\n    ]\r\n  }\r\n}");
        }

        #endregion Public Methods
    }
}