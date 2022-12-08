// -----------------------------------------------------------------------
// <copyright file="GameSaver.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.IO;
using System.Text.Json;
using Schuermann.Darts.GameCore.Game;

namespace Dart.Save
{
    /// <summary>Saves the given Game.</summary>
    public static class GameSaver
    {
        #region Public Methods

        /// <summary>Ases the json.</summary>
        /// <param name="currentGame">The current game.</param>
        /// <returns></returns>
        public static Stream AsJson(IGameProcedure currentGame)
        {
            var ms = new MemoryStream();
            JsonSerializer.Serialize(ms, currentGame);

            return ms;
        }

        /// <summary>
        /// Loads the specified stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns></returns>
        public static IGameProcedure Load(Stream stream)
        {
            return JsonSerializer.Deserialize<IGameProcedure>(stream);
        }

        #endregion Public Methods
    }
}