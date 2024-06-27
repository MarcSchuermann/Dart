// -----------------------------------------------------------------------
// <copyright file="DartGameView.xaml.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using Dart.Tools.DartBoardData;
using Schuermann.Dart.App.Common.UserInterface.Helper;
using Schuermann.Dart.Core.Thrown;
using Schuermann.Dart.Core.UI;

namespace Schuermann.Dart.App.Game.UserInterface.Views
{
   /// <summary>Interaction logic for DartGameView.</summary>
   public partial class DartGameView : UserControl
   {
      #region Private Fields

      private DartCircleAdorner adorner;

      #endregion Private Fields

      #region Public Constructors

      /// <summary>Initializes a new instance of the <see cref="DartGameView" /> class.</summary>
      public DartGameView()
      {
         InitializeComponent();

         DartBoard = new DartBoard();
      }

      #endregion Public Constructors

      #region Public Properties

      /// <summary>Gets the current points.</summary>
      /// <value>The current points.</value>
      public IDartThrow CurrentPoints { get; private set; }

      /// <summary>Gets the dart board.</summary>
      /// <value>The dart board.</value>
      public IDartBoard DartBoard { get; }

      #endregion Public Properties

      #region Private Methods

      /// <summary>Handles the MouseLeave event of the DartBoard control.</summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">
      ///    The <see cref="MouseEventArgs" /> instance containing the event data.
      /// </param>
      private void DartBoardMouseLeave(object sender, MouseEventArgs e)
      {
         var adornerLayer = AdornerLayer.GetAdornerLayer((System.Windows.Media.Visual)sender);
         adornerLayer?.Remove(adorner);
      }

      /// <summary>Handles the MouseMove event of the DartBoard control.</summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">
      ///    The <see cref="MouseEventArgs" /> instance containing the event data.
      /// </param>
      private void DartBoardMouseMove(object sender, MouseEventArgs e)
      {
         var throwInfo = new ThrowInfo(DartBoardImage);
         CurrentPoints = throwInfo.GetPointsAtMousePosition;

         PointsUnderMousePlaceholder.Content = CurrentPoints;

         RenderPointsAdorner(sender, GetCurrentMousePosition(), CurrentPoints.Points);

         ((DartBoard)DartBoard).Update(throwInfo);
      }

      /// <summary>Gets the current mouse position.</summary>
      /// <returns>The current mouse position.</returns>
      private Point GetCurrentMousePosition()
      {
         var currentPosition = Mouse.GetPosition(DartBoardImage);

         return new Point(Math.Round(currentPosition.X, 2), Math.Round(currentPosition.Y, 2));
      }

      /// <summary>Renders the points adorner.</summary>
      /// <param name="sender">The sender.</param>
      /// <param name="actuallyMousePosition">The actually mouse position.</param>
      /// <param name="actuallyPoints">The actually points.</param>
      private void RenderPointsAdorner(object sender, Point actuallyMousePosition, int actuallyPoints)
      {
         var adornerLayer = AdornerLayer.GetAdornerLayer((System.Windows.Media.Visual)sender);
         if (adorner != null)
            adornerLayer.Remove(adorner);

         adorner = new DartCircleAdorner((UIElement)sender, actuallyMousePosition, actuallyPoints);
         adornerLayer.Add(adorner);
      }

      #endregion Private Methods
   }
}