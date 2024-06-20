// -----------------------------------------------------------------------
// <copyright file="IGameSettingsViewModel.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;

namespace Schuermann.Dart.App.Game.Interfaces
{
   /// <summary>The game settings view model.</summary>
   internal interface IGameSettingsViewModel
   {
      #region Public Properties

      /// <summary>Gets the selectable start points.</summary>
      /// <value>The selectable start points.</value>
      public IList<int> SelectableStartPoints { get; }

      /// <summary>Gets or sets a value indicating whether [double in].</summary>
      /// <value><c>true</c> if [double in]; otherwise, <c>false</c>.</value>
      public bool DoubleIn { get; set; }

      /// <summary>Gets or sets a value indicating whether [double out].</summary>
      /// <value><c>true</c> if [double out]; otherwise, <c>false</c>.</value>
      public bool DoubleOut { get; set; }

      /// <summary>Gets or sets the selected player count.</summary>
      /// <value>The selected player count.</value>
      public string SelectedPlayerCount { get; set; }

      /// <summary>Gets or sets the selected start points.</summary>
      /// <value>The selected start points.</value>
      public string SelectedStartPoints { get; set; }

      #endregion Public Properties
   }
}