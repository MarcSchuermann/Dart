// -----------------------------------------------------------------------
// <copyright file="DartThrow.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Schuermann.Dart.Core.Thrown
{
   /// <summary>A thrown dart.</summary>
   /// <seealso cref="IDartThrow" />
   public class DartThrow : IDartThrow
   {
      #region Public Constructors

      /// <summary>Initializes a new instance of the <see cref="DartThrow" /> class.</summary>
      /// <param name="dartBoardField">The dart board field.</param>
      /// <param name="dartBoardQuantifier">The dart board quantifier.</param>
      public DartThrow(DartBoardField dartBoardField, DartBoardQuantifier dartBoardQuantifier)
      {
         DartBoardField = dartBoardField;
         DartBoardQuantifier = dartBoardQuantifier;
      }

      #endregion Public Constructors

      #region Public Properties

      /// <summary>Gets the dart board field.</summary>
      /// <value>The dart board field.</value>
      public DartBoardField DartBoardField { get; }

      /// <summary>Gets the dart board quantifier.</summary>
      /// <value>The dart board quantifier.</value>
      public DartBoardQuantifier DartBoardQuantifier { get; }

      /// <summary>Gets the points.</summary>
      /// <value>The points.</value>
      public int Points => (int)DartBoardQuantifier * (int)DartBoardField;

      #endregion Public Properties

      #region Public Methods

      /// <summary>Implements the operator !=.</summary>
      /// <param name="left">The left.</param>
      /// <param name="right">The right.</param>
      /// <returns>The result of the operator.</returns>
      public static bool operator !=(DartThrow left, DartThrow right)
      {
         return !(left == right);
      }

      /// <summary>Implements the operator &lt;.</summary>
      /// <param name="left">The left.</param>
      /// <param name="right">The right.</param>
      /// <returns>The result of the operator.</returns>
      public static bool operator <(DartThrow left, DartThrow right)
      {
         if (left == null)
            return false;

         if (right == null)
            return true;

         return left.Points < right.Points;
      }

      /// <summary>Implements the operator &lt;=.</summary>
      /// <param name="left">The left.</param>
      /// <param name="right">The right.</param>
      /// <returns>The result of the operator.</returns>
      public static bool operator <=(DartThrow left, DartThrow right)
      {
         if (left == null)
            return false;

         if (right == null)
            return true;

         return left.Points <= right.Points;
      }

      /// <summary>Implements the operator ==.</summary>
      /// <param name="left">The left.</param>
      /// <param name="right">The right.</param>
      /// <returns>The result of the operator.</returns>
      public static bool operator ==(DartThrow left, DartThrow right)
      {
         if (left == null)
            return false;

         return left.Equals(right);
      }

      /// <summary>Implements the operator &gt;.</summary>
      /// <param name="left">The left.</param>
      /// <param name="right">The right.</param>
      /// <returns>The result of the operator.</returns>
      public static bool operator >(DartThrow left, DartThrow right)
      {
         if (left == null)
            return true;

         if (right == null)
            return false;

         return left.Points > right.Points;
      }

      /// <summary>Implements the operator &gt;=.</summary>
      /// <param name="left">The left.</param>
      /// <param name="right">The right.</param>
      /// <returns>The result of the operator.</returns>
      public static bool operator >=(DartThrow left, DartThrow right)
      {
         if (left == null)
            return true;

         if (right == null)
            return false;

         return left.Points >= right.Points;
      }

      /// <summary>Creates a new object that is a copy of the current instance.</summary>
      /// <returns>A new object that is a copy of this instance.</returns>
      public object Clone()
      {
         var field = (DartBoardField)(int)DartBoardField;
         var quantifier = (DartBoardQuantifier)(int)DartBoardQuantifier;
         return new DartThrow(field, quantifier);
      }

      /// <summary>Compares to.</summary>
      /// <param name="other">The other.</param>
      /// <returns>The compare value.</returns>
      public int CompareTo(IDartThrow other)
      {
         if (other == null)
            return 1;

         if (other.Points > Points)
            return -1;

         if (other.Points == Points)
            return 0;

         return 1;
      }

      /// <summary>
      ///    Indicates whether the current object is equal to another object of the same type.
      /// </summary>
      /// <param name="other">An object to compare with this object.</param>
      /// <returns>
      ///    true if the current object is equal to the <paramref name="other">other</paramref>
      ///    parameter; otherwise, false.
      /// </returns>
      public bool Equals(IDartThrow other)
      {
         if (other == null)
            return false;

         return other.DartBoardField == DartBoardField && other.DartBoardQuantifier == DartBoardQuantifier;
      }

      /// <summary>
      ///    Determines whether the specified <see cref="object" />, is equal to this instance.
      /// </summary>
      /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
      /// <returns>
      ///    <c>true</c> if the specified <see cref="object" /> is equal to this instance;
      ///    otherwise, <c>false</c>.
      /// </returns>
      public override bool Equals(object obj)
      {
         if (obj is IDartThrow dartThrow)
            return Equals(dartThrow);

         return false;
      }

      /// <summary>Returns a hash code for this instance.</summary>
      /// <returns>
      ///    A hash code for this instance, suitable for use in hashing algorithms and data
      ///    structures like a hash table.
      /// </returns>
      public override int GetHashCode()
      {
         return DartBoardQuantifier.GetHashCode() ^ DartBoardField.GetHashCode();
      }

      /// <summary>Converts to string.</summary>
      /// <returns>A <see cref="string" /> that represents this instance.</returns>
      public override string ToString() => $"{DartBoardQuantifier} {DartBoardField}";

      #endregion Public Methods
   }
}