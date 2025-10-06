// -----------------------------------------------------------------------
// <copyright file="NamedTheme.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Schuermann.Dart.App.Common.Theme
{
   using ControlzEx.Theming;

   /// <summary>The named theme.</summary>
   /// <seealso cref="INamedTheme" />
   public class NamedTheme : INamedTheme
   {
      #region Public Constructors

      /// <summary>Initializes a new instance of the <see cref="NamedTheme" /> class.</summary>
      /// <param name="theme">The theme.</param>
      public NamedTheme(Theme theme)
      {
         OriginalTheme = theme;
      }

      #endregion Public Constructors

      #region Public Properties

      /// <summary>Gets the display name.</summary>
      /// <value>The display name.</value>
      public string DisplayName => ToString();

      /// <summary>Gets the original theme.</summary>
      /// <value>The original theme.</value>
      public Theme OriginalTheme { get; }

      #endregion Public Properties

      #region Public Methods

      /// <summary>Implements the operator !=.</summary>
      /// <param name="one">The one.</param>
      /// <param name="two">The two.</param>
      /// <returns>The result of the operator.</returns>
      public static bool operator !=(NamedTheme one, INamedTheme two)
      {
         return !one.Equals(two);
      }

      /// <summary>Implements the operator ==.</summary>
      /// <param name="one">The one.</param>
      /// <param name="two">The two.</param>
      /// <returns>The result of the operator.</returns>
      public static bool operator ==(NamedTheme one, INamedTheme two)
      {
         return one.Equals(two);
      }

      /// <summary>
      ///    Indicates whether the current object is equal to another object of the same type.
      /// </summary>
      /// <param name="other">An object to compare with this object.</param>
      /// <returns>
      ///    true if the current object is equal to the <paramref name="other" /> parameter;
      ///    otherwise, false.
      /// </returns>
      public bool Equals(INamedTheme other)
      {
         return DisplayName == other.DisplayName;
      }

      /// <summary>
      ///    Determines whether the specified <see cref="object" />, is equal to this instance.
      /// </summary>
      /// <param name="other">The <see cref="object" /> to compare with this instance.</param>
      /// <returns>
      ///    <c>true</c> if the specified <see cref="object" /> is equal to this instance;
      ///    otherwise, <c>false</c>.
      /// </returns>
      public override bool Equals(object other)
      {
         if (other is INamedTheme named)
            return Equals(named);
         return false;
      }

      /// <summary>Returns a hash code for this instance.</summary>
      /// <returns>
      ///    A hash code for this instance, suitable for use in hashing algorithms and data
      ///    structures like a hash table.
      /// </returns>
      public override int GetHashCode()
      {
         return base.GetHashCode();
      }

      /// <summary>Converts to string.</summary>
      /// <returns>A <see cref="string" /> that represents this instance.</returns>
      public override string ToString()
      {
         return $"{OriginalTheme.BaseColorScheme} {OriginalTheme.ColorScheme}";
      }

      #endregion Public Methods
   }
}