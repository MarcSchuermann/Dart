// -----------------------------------------------------------------------
// <copyright file="ThrowInfo.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Input;
using Dart.Common.UserInterface.Helper;
using Schuermann.Dart.Core.Thrown;

namespace Dart
{
   /// <summary>The throw info.</summary>
   /// <seealso cref="Common.UserInterface.Helper.NotifyPropertyChanged" />
   public class ThrowInfo : NotifyPropertyChanged
   {
      #region Public Constructors

      /// <summary>Initializes a new instance of the <see cref="ThrowInfo" /> class.</summary>
      /// <param name="dartBoardElement">The dart board.</param>
      public ThrowInfo(UIElement dartBoardElement)
      {
         DartBoard = dartBoardElement;
      }

      #endregion Public Constructors

      #region Public Properties

      /// <summary>Gets the dart board.</summary>
      /// <value>The dart board.</value>
      public UIElement DartBoard { get; }

      /// <summary>Gets the current angle.</summary>
      /// <returns>The angle.</returns>
      public double GetCurrentAngle
      {
         get
         {
            double dx = GetCurrentMousePosition.X - GetDartBoardCenter.X;
            double dy = GetCurrentMousePosition.Y - GetDartBoardCenter.Y;

            double angle = 60 * Math.Atan2(dy, dx);
            return Math.Round(angle, 2);
         }
      }

      /// <summary>Gets the current distance between mouse and center.</summary>
      /// <returns>The current distance between mouse and center.</returns>
      public double GetCurrentDistanceBetweenMouseAndCenter
      {
         get
         {
            return Math.Round(Math.Sqrt(Math.Pow(GetCurrentMousePosition.X - GetDartBoardCenter.X, 2) + Math.Pow(GetCurrentMousePosition.Y - GetDartBoardCenter.Y, 2)), 2);
         }
      }

      /// <summary>Gets the current mouse position.</summary>
      /// <returns>The current mouse position.</returns>
      public Point GetCurrentMousePosition
      {
         get
         {
            return Mouse.GetPosition(DartBoard);
         }
      }

      /// <summary>Gets the dart board center.</summary>
      /// <returns>The dart board center.</returns>
      public Point GetDartBoardCenter
      {
         get
         {
            return new Point(Math.Round(DartBoard.RenderSize.Width / 2, 0), Math.Round(DartBoard.RenderSize.Height / 2, 0));
         }
      }

      /// <summary>Gets the get points at mouse position.</summary>
      /// <value>The get points at mouse position.</value>
      public IDartThrow GetPointsAtMousePosition
      {
         get
         {
            return CalculatePoints(GetCurrentAngle, GetCurrentDistanceBetweenMouseAndCenter);
         }
      }

      /// <summary>Gets a value indicating whether this instance is double.</summary>
      /// <value><c>true</c> if this instance is double; otherwise, <c>false</c>.</value>
      public bool IsDouble
      {
         get
         {
            // The outer double ring.
            if (GetCurrentDistanceBetweenMouseAndCenter > DartBoardVariables.PointsToInnerDouble && GetCurrentDistanceBetweenMouseAndCenter < DartBoardVariables.PointsToOuterDouble)
               return true;

            // The double bullseye.
            if (GetCurrentDistanceBetweenMouseAndCenter > DartBoardVariables.InnerBullsEyeRadius && GetCurrentDistanceBetweenMouseAndCenter < DartBoardVariables.OuterBullsEyeRadius)
               return true;

            return false;
         }
      }

      /// <summary>Gets a value indicating whether this instance is single.</summary>
      /// <value><c>true</c> if this instance is single; otherwise, <c>false</c>.</value>
      public bool IsSingle
      {
         get
         {
            // The single bullseye.
            if (GetCurrentDistanceBetweenMouseAndCenter < DartBoardVariables.InnerBullsEyeRadius)
               return true;

            // The inner single ring.
            if (GetCurrentDistanceBetweenMouseAndCenter > DartBoardVariables.OuterBullsEyeRadius && GetCurrentDistanceBetweenMouseAndCenter < DartBoardVariables.PointsToInnerTriple)
               return true;

            // The outer singel ring.
            if (GetCurrentDistanceBetweenMouseAndCenter > DartBoardVariables.PointsToOuterTriple && GetCurrentDistanceBetweenMouseAndCenter < DartBoardVariables.PointsToInnerDouble)
               return true;

            return false;
         }
      }

      /// <summary>Gets a value indicating whether this instance is triple.</summary>
      /// <value><c>true</c> if this instance is triple; otherwise, <c>false</c>.</value>
      public bool IsTriple
      {
         get
         {
            return GetCurrentDistanceBetweenMouseAndCenter > DartBoardVariables.PointsToInnerTriple && GetCurrentDistanceBetweenMouseAndCenter < DartBoardVariables.PointsToOuterTriple;
         }
      }

      #endregion Public Properties

      #region Private Methods

      /// <summary>Calculates the points.</summary>
      /// <param name="angle">The angle.</param>
      /// <param name="distance">The distance.</param>
      /// <returns>The points.</returns>
      private IDartThrow CalculatePoints(double angle, double distance)
      {
         if (distance < DartBoardVariables.InnerBullsEyeRadius)
            return new DartThrow(DartBoardField.Bullseye, DartBoardQuantifier.Double);

         if (distance < DartBoardVariables.OuterBullsEyeRadius)
            return new DartThrow(DartBoardField.Bullseye, DartBoardQuantifier.Single);

         if (angle > DartBoardConstants.AngleBetween13And6 - 9 && angle < DartBoardConstants.AngleBetween6And10)
            return CalculateWithMultiplier(6, distance);

         if (angle > DartBoardConstants.AngleBetween6And10 && angle < DartBoardConstants.AngleBetween10And15)
            return CalculateWithMultiplier(10, distance);

         if (angle > DartBoardConstants.AngleBetween10And15 && angle < DartBoardConstants.AngleBetween15And2)
            return CalculateWithMultiplier(15, distance);

         if (angle > DartBoardConstants.AngleBetween15And2 && angle < DartBoardConstants.AngleBetween2And17)
            return CalculateWithMultiplier(2, distance);

         if (angle > DartBoardConstants.AngleBetween2And17 && angle < DartBoardConstants.AngleBetween17And3)
            return CalculateWithMultiplier(17, distance);

         if (angle > DartBoardConstants.AngleBetween17And3 && angle < DartBoardConstants.AngleBetween3And19)
            return CalculateWithMultiplier(3, distance);

         if (angle > DartBoardConstants.AngleBetween3And19 && angle < DartBoardConstants.AngleBetween19And7)
            return CalculateWithMultiplier(19, distance);

         if (angle > DartBoardConstants.AngleBetween19And7 && angle < DartBoardConstants.AngleBetween7And16)
            return CalculateWithMultiplier(7, distance);

         if (angle > DartBoardConstants.AngleBetween7And16 && angle < DartBoardConstants.AngleBetween16And8)
            return CalculateWithMultiplier(16, distance);

         if (angle > DartBoardConstants.AngleBetween16And8 && angle < DartBoardConstants.AngleBetween8And11)
            return CalculateWithMultiplier(8, distance);

         if (angle > DartBoardConstants.AngleBetween8And11 || angle < DartBoardConstants.AngleBetween11And14)
            return CalculateWithMultiplier(11, distance);

         if (angle > DartBoardConstants.AngleBetween11And14 && angle < DartBoardConstants.AngleBetween14And9)
            return CalculateWithMultiplier(14, distance);

         if (angle > DartBoardConstants.AngleBetween14And9 && angle < DartBoardConstants.AngleBetween9And12)
            return CalculateWithMultiplier(9, distance);

         if (angle > DartBoardConstants.AngleBetween9And12 && angle < DartBoardConstants.AngleBetween12And5)
            return CalculateWithMultiplier(12, distance);

         if (angle > DartBoardConstants.AngleBetween12And5 && angle < DartBoardConstants.AngleBetween5And20)
            return CalculateWithMultiplier(5, distance);

         if (angle > DartBoardConstants.AngleBetween5And20 && angle < DartBoardConstants.AngleBetween20And1)
            return CalculateWithMultiplier(20, distance);

         if (angle > DartBoardConstants.AngleBetween20And1 && angle < DartBoardConstants.AngleBetween1And18)
            return CalculateWithMultiplier(1, distance);

         if (angle > DartBoardConstants.AngleBetween1And18 && angle < DartBoardConstants.AngleBetween18And4)
            return CalculateWithMultiplier(18, distance);

         if (angle > DartBoardConstants.AngleBetween18And4 && angle < DartBoardConstants.AngleBetween4And13)
            return CalculateWithMultiplier(4, distance);

         if (angle > DartBoardConstants.AngleBetween4And13 && angle < DartBoardConstants.AngleBetween13And6)
            return CalculateWithMultiplier(13, distance);

         return new DartThrow(DartBoardField.Zero, DartBoardQuantifier.Single);
      }

      /// <summary>Calculates the with multiplier.</summary>
      /// <param name="segmentPoints">The segment points.</param>
      /// <param name="distance">The distance.</param>
      /// <returns>The points with multiplier.</returns>
      private IDartThrow CalculateWithMultiplier(int segmentPoints, double distance)
      {
         if (Enum.TryParse<DartBoardField>(segmentPoints.ToString(), out var points))
         {
            if (IsTriple)
               return new DartThrow(points, DartBoardQuantifier.Triple);

            if (IsDouble)
               return new DartThrow(points, DartBoardQuantifier.Double);

            if (IsSingle)
               return new DartThrow(points, DartBoardQuantifier.Single);
         }

         return new DartThrow(DartBoardField.Zero, DartBoardQuantifier.Single);
      }

      #endregion Private Methods
   }
}