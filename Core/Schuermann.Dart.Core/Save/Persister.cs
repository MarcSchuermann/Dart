// -----------------------------------------------------------------------
// <copyright file="Persist.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using Schuermann.Darts.GameCore.Game;
using Schuermann.Darts.GameCore.Save.PersistObjects;
using Schuermann.Darts.GameCore.Save.SerializerOptions;

namespace Schuermann.Darts.GameCore.Save
{
    /// <summary>Persist the current came instance.</summary>
    /// <seealso cref="Schuermann.Darts.GameCore.Save.IPersist" />
    public static class Persister
    {
        #region Public Methods

        /// <summary>Loads the specified stream.</summary>
        /// <param name="stream">The stream.</param>
        /// <returns></returns>
        public static IGameInstance Load(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            stream.Position = 0;

            var options = new JsonSerializerOptions { WriteIndented = true, Converters = { new DartThrowConverter() } };

            return Convert(JsonSerializer.Deserialize<GameInstancePersister>(stream, options));
        }

        /// <summary>Saves the specified instance.</summary>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        public static Stream Save(IGameInstance instance)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));

            var ms = new MemoryStream();
            var options = new JsonSerializerOptions { WriteIndented = true, Converters = { new DartThrowConverter() } };

            JsonSerializer.Serialize(ms, Convert(instance), options);

            ms.Position = 0;

            return ms;
        }

        #endregion Public Methods

        #region Private Methods

        private static GameInstancePersister Convert(IGameInstance instance)
        {
            return new GameInstancePersister()
            {
                GameOption = Convert(instance.GameOptions),
                CurrentPlayer = instance.CurrentPlayer.Id,
            };
        }

        private static IGameInstance Convert(GameInstancePersister instance)
        {
            var players = instance.GameOption.PlayerList.Select(x => Convert(x));
            var gameOptions = new GameOptions(players);
            return new GameInstance(gameOptions);
        }

        private static IPlayer Convert(PlayerPersister player)
        {
            return new Player(player.Name, player.StartPoints, player.ThrowHistory);
        }

        private static PlayerPersister Convert(IPlayer player)
        {
            return new PlayerPersister
            {
                Id = player.Id,
                Name = player.Name,
                ThrowHistory = player.ThrowHistory,
                StartPoints = player.StartPoints
            };
        }

        private static GameOptionPersister Convert(IGameOptions gameOptions)
        {
            return new GameOptionPersister
            {
                DoubleIn = gameOptions.DoubleIn,
                DoubleOut = gameOptions.DoubleOut,
                StartPoints = gameOptions.StartPoints,
                PlayerList = gameOptions.PlayerList.ToList().Select(x => Convert(x))
            };
        }

        #endregion Private Methods
    }
}