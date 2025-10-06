//-----------------------------------------------------------------------
// <copyright file="DartBoardVariables.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Schuermann.Dart.App.Common.UserInterface.Helper
{
   internal static class DartBoardUtils
   {
      #region Constants

      private const double defaultBoardWidth = 491.5;

      #endregion

      #region Public Properties

      /// <summary>
      /// Gets the inner bulls eye radius.
      /// </summary>
      /// <value>The inner bulls eye radius.</value>
      public static int GetInnerBullsEyeRadius(double boardWidth)
      {
         return Calculate(8, boardWidth);
      }

      /// <summary>
      /// Gets the points to outer bull.
      /// </summary>
      /// <value>The points to outer bull.</value>
      public static int GetOuterBullsEyeRadius(double boardWidth)
      {
         return Calculate(18, boardWidth);
      }

      /// <summary>
      /// Gets the points to inner double.
      /// </summary>
      /// <value>The points to inner double.</value>
      public static int GetPointsToInnerDouble(double boardWidth)
      {
         return Calculate(174, boardWidth);
      }

      /// <summary>
      /// Gets the points to inner triple.
      /// </summary>
      /// <value>The points to inner triple.</value>
      public static int GetPointsToInnerTriple(double boardWidth)
      {
         return Calculate(106, boardWidth);
      }

      /// <summary>
      /// Gets the points to outer double.
      /// </summary>
      /// <value>The points to outer double.</value>
      public static int GetPointsToOuterDouble(double boardWidth)
      {
         return Calculate(184, boardWidth);
      }

      /// <summary>
      /// Gets the points to outer triple.
      /// </summary>
      /// <value>The points to outer triple.</value>
      public static int GetPointsToOuterTriple(double boardWidth)
      {
         return Calculate(116, boardWidth);
      }

      #endregion Public Properties

      #region Private methods

      private static int Calculate(int radius, double currentDoardWidth)
      {
         var ratio = radius / defaultBoardWidth;

         var value = (int)(currentDoardWidth * ratio);
         return value;
      }

      #endregion
   }
}
