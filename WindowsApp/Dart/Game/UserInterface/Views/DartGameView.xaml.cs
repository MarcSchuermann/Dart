// -----------------------------------------------------------------------
// <copyright file="DartGameView.xaml.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using Dart.Tools;
using GameLogic.DartThrow;

namespace Dart
{
    /// <summary>Interaction logic for DartGameView.</summary>
    public partial class DartGameView : UserControl
    {
        #region Private Fields

        private DartCircleAdorner adorner;

        private DevelopmentPropertiesView developmentPropertiesView;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>Initializes a new instance of the <see cref="DartGameView"/> class.</summary>
        public DartGameView()
        {
            InitializeComponent();

            ShowDevUiData();
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>Gets the current points.</summary>
        /// <value>The current points.</value>
        public IDartThrow CurrentPoints { get; private set; }

        #endregion Public Properties

        #region Private Methods

        /// <summary>Handles the MouseLeave event of the DartBoard control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void DartBoardMouseLeave(object sender, MouseEventArgs e)
        {
            var adornerLayer = AdornerLayer.GetAdornerLayer((System.Windows.Media.Visual)sender);
            adornerLayer.Remove(adorner);
        }

        /// <summary>Handles the MouseMove event of the DartBoard control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void DartBoardMouseMove(object sender, MouseEventArgs e)
        {
            CurrentPoints = new ThrowInfo(DartBoardImage).GetPointsAtMousePosition;

            PointsUnderMousePlaceholder.Content = CurrentPoints;

            RenderPointsAdorner(sender, GetCurrentMousePosition(), CurrentPoints.Points);

            ShowDevUiData();
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

        /// <summary>Shows the development UI data.</summary>
        private void ShowDevUiData()
        {
            if (!Properties.Settings.Default.ShowUserInterfaceDartBoardData)
                return;

            if (developmentPropertiesView == null)
            {
                developmentPropertiesView = new DevelopmentPropertiesView();
                developmentPropertiesView.Show();
            }

            developmentPropertiesView.propertyView.SelectedObject = new ThrowInfo(DartBoardImage);
        }

        #endregion Private Methods
    }
}