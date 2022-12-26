// -----------------------------------------------------------------------
// <copyright file="Persist.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Drawing;
using System.IO;
using System.Text.Json;
using Schuermann.Darts.GameCore.Game;
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

            var options = new JsonSerializerOptions { WriteIndented = true, Converters = { new PlayerConverter(), new GameOptionsConverter(), new DartThrowConverter() } };

            return JsonSerializer.Deserialize<GameInstance>(stream, options);
        }

        /// <summary>Saves the specified instance.</summary>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        public static Stream Save(IGameInstance instance)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));

            var ms = new MemoryStream();
            var options = new JsonSerializerOptions { WriteIndented = true, Converters = { new PlayerConverter(), new GameOptionsConverter(), new DartThrowConverter() } };

            JsonSerializer.Serialize(ms, instance, options);

            ms.Position = 0;

            return ms;
        }

        #endregion Public Methods
    }
}