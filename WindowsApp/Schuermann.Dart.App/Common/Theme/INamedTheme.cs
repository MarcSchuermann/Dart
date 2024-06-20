// -----------------------------------------------------------------------
// <copyright file="INamedTheme.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Schuermann.Dart.App.Common.Theme
{
   using System;
   using ControlzEx.Theming;

   /// <summary>The theme with an to string method.</summary>
   public interface INamedTheme : IEquatable<INamedTheme>
   {
      #region Public Properties

      /// <summary>Gets the display name.</summary>
      /// <value>The display name.</value>
      string DisplayName { get; }

      /// <summary>Gets the original theme.</summary>
      /// <value>The original theme.</value>
      Theme OriginalTheme { get; }

      #endregion Public Properties

      #region Public Methods

      /// <summary>Converts to string.</summary>
      /// <returns>A <see cref="string"/> that represents this instance.</returns>
      string ToString();

      #endregion Public Methods
   }
}