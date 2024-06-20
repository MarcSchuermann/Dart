// -----------------------------------------------------------------------
// <copyright file="IDartBoard.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using Schuermann.Dart.Core.Thrown;

namespace Schuermann.Dart.Core.UI
{
   /// <summary>Geometrie and current values of the dard board.</summary>
   public interface IDartBoard
   {
      #region Public Events

      /// <summary>Occurs when [values changed].</summary>
      event EventHandler ValuesChanged;

      #endregion Public Events

      #region Public Properties

      /// <summary>Gets the current angle.</summary>
      /// <value>The current angle.</value>
      double CurrentAngle { get; }

      /// <summary>Gets the current distance between mouse and center.</summary>
      /// <value>The current distance between mouse and center.</value>
      double CurrentDistanceBetweenMouseAndCenter { get; }

      /// <summary>Gets the current mouse position.</summary>
      /// <value>The current mouse position.</value>
      Tuple<double, double> CurrentMousePosition { get; }

      /// <summary>Gets the dart board center.</summary>
      /// <value>The dart board center.</value>
      Tuple<double, double> DartBoardCenter { get; }

      /// <summary>Gets the height.</summary>
      /// <value>The height.</value>
      double Height { get; }

      /// <summary>Gets a value indicating whether this instance is double.</summary>
      /// <value><c>true</c> if this instance is double; otherwise, <c>false</c>.</value>
      bool IsDouble { get; }

      /// <summary>Gets a value indicating whether this instance is single.</summary>
      /// <value><c>true</c> if this instance is single; otherwise, <c>false</c>.</value>
      bool IsSingle { get; }

      /// <summary>Gets a value indicating whether this instance is triple.</summary>
      /// <value><c>true</c> if this instance is triple; otherwise, <c>false</c>.</value>
      bool IsTriple { get; }

      /// <summary>Gets the points at mouse position.</summary>
      /// <value>The points at mouse position.</value>
      IDartThrow PointsAtMousePosition { get; }

      /// <summary>Gets the width.</summary>
      /// <value>The width.</value>
      double Width { get; }

      #endregion Public Properties
   }
}