// -----------------------------------------------------------------------
// <copyright file="GameOptionsConverter.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Schuermann.Dart.Core.Game;


namespace Schuermann.Dart.Core.Save.SerializerOptions
{
   internal class GameOptionsConverter : JsonConverter<IGameOptions>
   {
      #region Public Methods

      public override IGameOptions Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
      {
         var gameOptions = JsonSerializer.Deserialize(ref reader, typeof(GameOptions), options);
         return gameOptions as IGameOptions;
      }

      public override void Write(Utf8JsonWriter writer, IGameOptions value, JsonSerializerOptions options)
      {
         var type = value.GetType();
         JsonSerializer.Serialize(writer, value, type, options);
      }

      #endregion Public Methods
   }
}