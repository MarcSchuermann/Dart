// -----------------------------------------------------------------------
// <copyright file="GameOptionPersister.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;

namespace Schuermann.Dart.Core.Save.PersistObjects
{
   /// <summary>Persist the game option.</summary>
   internal class GameOptionPersister
   {
      #region Public Properties

      /// <summary>Gets or sets a value indicating whether [double in].</summary>
      /// <value><c>true</c> if [double in]; otherwise, <c>false</c>.</value>
      public bool DoubleIn { get; set; }

      /// <summary>Gets or sets a value indicating whether [double out].</summary>
      /// <value><c>true</c> if [double out]; otherwise, <c>false</c>.</value>
      public bool DoubleOut { get; set; }

      /// <summary>Gets or sets the player list.</summary>
      /// <value>The player list.</value>
      public IEnumerable<PlayerPersister> PlayerList { get; set; }

      /// <summary>Gets or sets the start points.</summary>
      /// <value>The start points.</value>
      public int StartPoints { get; set; }

      #endregion Public Properties
   }
}