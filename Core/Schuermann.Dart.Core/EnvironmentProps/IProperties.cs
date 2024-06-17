// -----------------------------------------------------------------------
// <copyright file="IProperties.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Globalization;
using Schuermann.Dart.Core.Themes;

namespace Schuermann.Dart.Core.EnvironmentProps
{
   /// <summary>The properties.</summary>
   public interface IProperties
   {
      #region Public Properties

      /// <summary>Gets the culture.</summary>
      /// <value>The culture.</value>
      CultureInfo Culture { get; }

      /// <summary>Gets the theme.</summary>
      /// <value>The theme.</value>
      Theme Theme { get; }

      #endregion Public Properties
   }
}