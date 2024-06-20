// -----------------------------------------------------------------------
// <copyright file="DartBoard.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using Schuermann.Dart.Core.Thrown;
using Schuermann.Dart.Core.UI;

namespace Dart.Tools.DartBoardData
{
   internal class DartBoard : IDartBoard
   {
      #region Public Events

      /// <summary>Occurs when [values changed].</summary>
      public event EventHandler ValuesChanged;

      #endregion Public Events

      #region Public Properties

      /// <summary>Gets the current angle.</summary>
      /// <value>The current angle.</value>
      public double CurrentAngle { get; private set; }

      /// <summary>Gets the current distance between mouse and center.</summary>
      /// <value>The current distance between mouse and center.</value>
      public double CurrentDistanceBetweenMouseAndCenter { get; private set; }

      /// <summary>Gets the current mouse position.</summary>
      /// <value>The current mouse position.</value>
      public Tuple<double, double> CurrentMousePosition { get; private set; }

      /// <summary>Gets the dart board center.</summary>
      /// <value>The dart board center.</value>
      public Tuple<double, double> DartBoardCenter { get; private set; }

      /// <summary>Gets the height.</summary>
      /// <value>The height.</value>
      public double Height { get; private set; }

      /// <summary>Gets a value indicating whether this instance is double.</summary>
      /// <value><c>true</c> if this instance is double; otherwise, <c>false</c>.</value>
      public bool IsDouble { get; private set; }

      /// <summary>Gets a value indicating whether this instance is single.</summary>
      /// <value><c>true</c> if this instance is single; otherwise, <c>false</c>.</value>
      public bool IsSingle { get; private set; }

      /// <summary>Gets a value indicating whether this instance is triple.</summary>
      /// <value><c>true</c> if this instance is triple; otherwise, <c>false</c>.</value>
      public bool IsTriple { get; private set; }

      /// <summary>Gets the points at mouse position.</summary>
      /// <value>The points at mouse position.</value>
      public IDartThrow PointsAtMousePosition { get; private set; }

      /// <summary>Gets the width.</summary>
      /// <value>The width.</value>
      public double Width { get; private set; }

      #endregion Public Properties

      #region Public Methods

      /// <summary>Updates the specified throw information.</summary>
      /// <param name="throwInfo">The throw information.</param>
      public void Update(ThrowInfo throwInfo)
      {
         if (throwInfo == null)
            return;

         CurrentAngle = throwInfo.GetCurrentAngle;
         CurrentDistanceBetweenMouseAndCenter = throwInfo.GetCurrentDistanceBetweenMouseAndCenter;
         CurrentMousePosition = Tuple.Create(throwInfo.GetCurrentMousePosition.X, throwInfo.GetCurrentMousePosition.X);
         DartBoardCenter = Tuple.Create(throwInfo.GetDartBoardCenter.X, throwInfo.GetDartBoardCenter.Y);
         Height = throwInfo.DartBoard.RenderSize.Height;
         IsDouble = throwInfo.IsDouble;
         IsSingle = throwInfo.IsSingle;
         IsTriple = throwInfo.IsTriple;
         PointsAtMousePosition = throwInfo.GetPointsAtMousePosition;
         Width = throwInfo.DartBoard.RenderSize.Width;

         ValuesChanged?.Invoke(this, EventArgs.Empty);
      }

      #endregion Public Methods
   }
}