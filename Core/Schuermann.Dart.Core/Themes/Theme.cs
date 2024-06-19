// -----------------------------------------------------------------------
// <copyright file="Theme.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using Schuermann.Dart.Core.Themes;

namespace Schuermann.Dart.Core.Themes
{
   /// <summary>The theme.</summary>
   public class Theme : ITheme
   {
      #region Public Constructors

      /// <summary>Initializes a new instance of the <see cref="Theme" /> class.</summary>
      public Theme()
          : this(BaseTheme.light, ColorSchema.blue)
      {
      }

      /// <summary>Initializes a new instance of the <see cref="Theme" /> class.</summary>
      /// <param name="baseTheme">The base theme.</param>
      /// <param name="colorSchema">The color schema.</param>
      public Theme(BaseTheme baseTheme, ColorSchema colorSchema)
      {
         BaseTheme = baseTheme;
         ColorSchema = colorSchema;
      }

      #endregion Public Constructors

      #region Public Properties

      /// <summary>Gets the base theme.</summary>
      /// <value>The base theme.</value>
      public BaseTheme BaseTheme { get; }

      /// <summary>Gets the color schema.</summary>
      /// <value>The color schema.</value>
      public ColorSchema ColorSchema { get; }

      #endregion Public Properties
   }
}