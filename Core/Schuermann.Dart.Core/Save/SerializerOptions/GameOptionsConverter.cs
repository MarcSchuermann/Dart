using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Schuermann.Dart.Core.Game;
using Schuermann.Dart.Core.Game;

namespace Schuermann.Darts.GameCore.Save.SerializerOptions
{
   internal class GameOptionsConverter : JsonConverter<IGameOptions>
    {
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
    }
}
