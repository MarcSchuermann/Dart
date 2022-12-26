using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Schuermann.Darts.GameCore.Game;

namespace Schuermann.Darts.GameCore.Save.SerializerOptions
{
    internal class PlayerConverter : JsonConverter<IPlayer>
    {
        #region Public Methods

        public override IPlayer Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var player = JsonSerializer.Deserialize(ref reader, typeof(Player), options);
            return player as IPlayer;
        }

        public override void Write(Utf8JsonWriter writer, IPlayer value, JsonSerializerOptions options)
        {
            var type = value.GetType();
            JsonSerializer.Serialize(writer, value, type, options);
        }

        #endregion Public Methods
    }
}