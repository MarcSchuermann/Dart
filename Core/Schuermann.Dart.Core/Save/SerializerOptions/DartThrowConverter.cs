// -----------------------------------------------------------------------
// <copyright file="DartThrowConverter.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Schuermann.Dart.Core.Thrown;

namespace Schuermann.Dart.Core.Save.SerializerOptions
{
   internal class DartThrowConverter : JsonConverter<IDartThrow>
   {
      #region Public Methods

      public override IDartThrow Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
      {
         var dartThrow = JsonSerializer.Deserialize(ref reader, typeof(DartThrow), options);
         return dartThrow as IDartThrow;
      }

      public override void Write(Utf8JsonWriter writer, IDartThrow value, JsonSerializerOptions options)
      {
         var type = value.GetType();
         JsonSerializer.Serialize(writer, value, type, options);
      }

      #endregion Public Methods
   }
}