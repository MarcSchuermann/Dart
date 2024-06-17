// -----------------------------------------------------------------------
// <copyright file="ITheme.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Schuermann.Darts.GameCore.Themes
{
   /// <summary>The Theme.</summary>
   public interface ITheme
   {
      #region Public Properties

      /// <summary>Gets the base theme.</summary>
      /// <value>The base theme.</value>
      BaseTheme BaseTheme { get; }

      /// <summary>Gets the color schema.</summary>
      /// <value>The color schema.</value>
      ColorSchema ColorSchema { get; }

      #endregion Public Properties
   }
}