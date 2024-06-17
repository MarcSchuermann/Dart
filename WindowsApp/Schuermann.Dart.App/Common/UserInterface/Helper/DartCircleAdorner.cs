// -----------------------------------------------------------------------
// <copyright file="DartCircleAdorner.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using Dart.Common.UserInterface.Helper;

namespace Dart
{
    /// <summary>The DartCircleAdorner.</summary>
    /// <seealso cref="System.Windows.Documents.Adorner"/>
    public class DartCircleAdorner : Adorner
    {
        #region Private Fields

        private const int HorizontalCenterAdjustment = 0;

        private const int VerticalCenterAdjustment = 0;

        private readonly int points;

        private Point mousePosition;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>Initializes a new instance of the <see cref="DartCircleAdorner"/> class.</summary>
        /// <param name="adornedElement">The adorned element.</param>
        /// <param name="actuallyMousePosition">The actually mouse position.</param>
        /// <param name="actuallyPoints">The actually points.</param>
        public DartCircleAdorner(UIElement adornedElement, Point actuallyMousePosition, int actuallyPoints)
            : base(adornedElement)
        {
            var centerPoint = new Point
            {
                X = Math.Round((adornedElement.RenderSize.Width / 2) + HorizontalCenterAdjustment),
                Y = Math.Round((adornedElement.RenderSize.Height / 2) + VerticalCenterAdjustment),
            };
            Center = centerPoint;

            mousePosition = actuallyMousePosition;
            IsHitTestVisible = false;
            points = actuallyPoints;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>Gets or sets the center.</summary>
        /// <value>The center.</value>
        public Point Center { get; set; }

        #endregion Public Properties

        #region Protected Methods

        /// <summary>
        /// When overridden in a derived class, participates in rendering operations that are directed by the layout system. The rendering
        /// instructions for this element are not used directly when this method is invoked, and are instead preserved for later asynchronous use by
        /// layout and drawing.
        /// </summary>
        /// <param name="drawingContext">The drawing instructions for a specific element. This context is provided to the layout system.</param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            var renderBrush = new SolidColorBrush(Properties.Settings.Default.PrimaryAccentColor) { Opacity = 0.6 };
            var renderPen = new Pen(new SolidColorBrush(Colors.DarkGray), 2.0);

            var distance = Math.Sqrt(Math.Pow(mousePosition.X - Center.X, 2) + Math.Pow(mousePosition.Y - Center.Y, 2));

            var outerBullCircle = new EllipseGeometry(Center, DartBoardVariables.OuterBullsEyeRadius, DartBoardVariables.OuterBullsEyeRadius);
            var innerBullCircle = new EllipseGeometry(Center, DartBoardVariables.InnerBullsEyeRadius, DartBoardVariables.InnerBullsEyeRadius);
            var boardCircle = new EllipseGeometry(Center, DartBoardVariables.PointsToOuterDouble, DartBoardVariables.PointsToOuterDouble);

            var outerTripleCircle = new EllipseGeometry(Center, DartBoardVariables.PointsToOuterTriple, DartBoardVariables.PointsToOuterTriple);
            var innerTripleCirle = new EllipseGeometry(Center, DartBoardVariables.PointsToInnerTriple, DartBoardVariables.PointsToInnerTriple);
            var tripleCirle = new CombinedGeometry(GeometryCombineMode.Exclude, outerTripleCircle, innerTripleCirle);

            var outerDoubleCircle = new EllipseGeometry(Center, DartBoardVariables.PointsToOuterDouble + 1, DartBoardVariables.PointsToOuterDouble + 1);
            var innerDoubleCirle = new EllipseGeometry(Center, DartBoardVariables.PointsToInnerDouble, DartBoardVariables.PointsToInnerDouble);
            var doubleCirle = new CombinedGeometry(GeometryCombineMode.Exclude, outerDoubleCircle, innerDoubleCirle);

            if (distance <= DartBoardVariables.InnerBullsEyeRadius)
            {
                // Draw Inner Bull
                drawingContext.DrawEllipse(renderBrush, renderPen, Center, DartBoardVariables.InnerBullsEyeRadius, DartBoardVariables.InnerBullsEyeRadius);
                return;
            }
            else if (distance <= DartBoardVariables.OuterBullsEyeRadius && distance >= DartBoardVariables.InnerBullsEyeRadius)
            {
                // Draw Outer Bull
                drawingContext.DrawGeometry(renderBrush, renderPen, GetOuterBullGeometry(outerBullCircle, innerBullCircle));
                return;
            }
            else if (distance <= DartBoardVariables.PointsToOuterDouble)
            {
                if (distance >= DartBoardVariables.PointsToInnerDouble && distance <= DartBoardVariables.PointsToOuterDouble)
                {
                    // Draw Double
                    var doubleGeometry = GetDoubleGeometry(Center, doubleCirle);

                    if (doubleGeometry != null)
                        drawingContext.DrawGeometry(renderBrush, renderPen, doubleGeometry);

                    return;
                }
                else if (distance >= DartBoardVariables.PointsToInnerTriple && distance <= DartBoardVariables.PointsToOuterTriple)
                {
                    // Draw Triple
                    var tripleGeometry = GetTripleGeometry(Center, tripleCirle);

                    if (tripleGeometry != null)
                        drawingContext.DrawGeometry(renderBrush, renderPen, tripleGeometry);

                    return;
                }
                else
                {
                    // Draw Single
                    var singleGeometry = GetSingleGeometry(Center, boardCircle, outerBullCircle, tripleCirle, doubleCirle);

                    if (singleGeometry != null)
                        drawingContext.DrawGeometry(renderBrush, renderPen, singleGeometry);

                    return;
                }
            }
            else
            {
                // Draw Zero
                if (points == 0)
                {
                    Geometry wholeImage = new RectangleGeometry(new Rect(new Point(Center.X - 250, Center.Y - 250), new Point(Center.X + 250, Center.Y + 250)));
                    drawingContext.DrawGeometry(renderBrush, renderPen, new CombinedGeometry(GeometryCombineMode.Exclude, wholeImage, boardCircle));
                }
            }
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>Gets the double geometry.</summary>
        /// <param name="center">The render center.</param>
        /// <param name="doubleCircle">The double circle.</param>
        /// <returns>The geometry of the double ring.</returns>
        private Geometry GetDoubleGeometry(Point center, Geometry doubleCircle)
        {
            var transLeft = new RotateTransform(171.0, center.X, center.Y);
            var transRight = new RotateTransform(99.0, center.X, center.Y);

            Geometry rectRight = new RectangleGeometry(new Rect(new Point(center.X, center.Y), new Point(center.X - 1000.0, center.Y - 1000.0)), 0.0, 0.0, transRight);
            Geometry rectLeft = new RectangleGeometry(new Rect(new Point(center.X, center.Y), new Point(center.X + 1000.0, center.Y + 1000.0)), 0.0, 0.0, transLeft);
            Geometry rectButtom = new RectangleGeometry(new Rect(new Point(center.X - 1000.0, center.Y), new Point(center.X + 1000.0, center.Y + 1000.0)));

            var intermediateGeometry = new CombinedGeometry(GeometryCombineMode.Union, rectLeft, rectRight);
            var maskGeometry = new CombinedGeometry(GeometryCombineMode.Union, intermediateGeometry, rectButtom);

            var showGeometry = new CombinedGeometry(GeometryCombineMode.Exclude, doubleCircle, maskGeometry);

            if (points == 12)
            {
                // 6
                showGeometry.Transform = new RotateTransform(90.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 20)
            {
                // 10
                showGeometry.Transform = new RotateTransform(108.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 30)
            {
                // 15
                showGeometry.Transform = new RotateTransform(126.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 4)
            {
                // 2
                showGeometry.Transform = new RotateTransform(144.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 34)
            {
                // 17
                showGeometry.Transform = new RotateTransform(162.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 6)
            {
                // 3
                showGeometry.Transform = new RotateTransform(180.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 38)
            {
                // 19
                showGeometry.Transform = new RotateTransform(-162.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 14)
            {
                // 7
                showGeometry.Transform = new RotateTransform(-144.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 32)
            {
                // 16
                showGeometry.Transform = new RotateTransform(-126.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 16)
            {
                // 8
                showGeometry.Transform = new RotateTransform(-108.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 22)
            {
                // 11
                showGeometry.Transform = new RotateTransform(-90.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 28)
            {
                // 14
                showGeometry.Transform = new RotateTransform(-72.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 18)
            {
                // 9
                showGeometry.Transform = new RotateTransform(-54.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 24)
            {
                // 12
                showGeometry.Transform = new RotateTransform(-36.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 10)
            {
                // 5
                showGeometry.Transform = new RotateTransform(-18.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 40)
            {
                // 20
                showGeometry.Transform = new RotateTransform(0.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 2)
            {
                // 1
                showGeometry.Transform = new RotateTransform(18.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 36)
            {
                // 18
                showGeometry.Transform = new RotateTransform(36.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 8)
            {
                // 4
                showGeometry.Transform = new RotateTransform(54.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 26)
            {
                // 13
                showGeometry.Transform = new RotateTransform(72.0, center.X, center.Y);
                return showGeometry;
            }

            return null;
        }

        /// <summary>Gets the outer bull geometry.</summary>
        /// <param name="circle">The circle.</param>
        /// <param name="circleToSubtract">The circle to subtract.</param>
        /// <returns>The geometry of the outer ring.</returns>
        private Geometry GetOuterBullGeometry(Geometry circle, Geometry circleToSubtract)
        {
            return new CombinedGeometry(GeometryCombineMode.Exclude, circle, circleToSubtract);
        }

        /// <summary>Gets the single geometry.</summary>
        /// <param name="center">The render center.</param>
        /// <param name="boardCircle">The board circle.</param>
        /// <param name="bullCircle">The bull circle.</param>
        /// <param name="tripleCircle">The triple circle.</param>
        /// <param name="doubleCircle">The double circle.</param>
        /// <returns>The geometry of the single shape.</returns>
        private Geometry GetSingleGeometry(Point center, Geometry boardCircle, Geometry bullCircle, Geometry tripleCircle, Geometry doubleCircle)
        {
            var transLeft = new RotateTransform(171.0, center.X, center.Y);
            var transRight = new RotateTransform(99.0, center.X, center.Y);

            Geometry rectRight = new RectangleGeometry(new Rect(new Point(center.X, center.Y), new Point(center.X - 1000.0, center.Y - 1000.0)), 0.0, 0.0, transRight);
            Geometry rectLeft = new RectangleGeometry(new Rect(new Point(center.X, center.Y), new Point(center.X + 1000.0, center.Y + 1000.0)), 0.0, 0.0, transLeft);
            Geometry rectButtom = new RectangleGeometry(new Rect(new Point(center.X - 1000.0, center.Y), new Point(center.X + 1000.0, center.Y + 1000.0)));

            var intermediateGeometry = new CombinedGeometry(GeometryCombineMode.Union, rectLeft, rectRight);
            var intermediateGeometry2 = new CombinedGeometry(GeometryCombineMode.Union, intermediateGeometry, bullCircle);
            var intermediateGeometry3 = new CombinedGeometry(GeometryCombineMode.Union, intermediateGeometry2, tripleCircle);
            var intermediateGeometry4 = new CombinedGeometry(GeometryCombineMode.Union, intermediateGeometry3, doubleCircle);

            var maskGeometry = new CombinedGeometry(GeometryCombineMode.Union, intermediateGeometry4, rectButtom);

            var showGeometry = new CombinedGeometry(GeometryCombineMode.Exclude, boardCircle, maskGeometry);

            if (points == 6)
            {
                // 6
                showGeometry.Transform = new RotateTransform(90.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 10)
            {
                // 10
                showGeometry.Transform = new RotateTransform(108.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 15)
            {
                // 15
                showGeometry.Transform = new RotateTransform(126.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 2)
            {
                // 2
                showGeometry.Transform = new RotateTransform(144.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 17)
            {
                // 17
                showGeometry.Transform = new RotateTransform(162.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 3)
            {
                // 3
                showGeometry.Transform = new RotateTransform(180.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 19)
            {
                // 19
                showGeometry.Transform = new RotateTransform(-162.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 7)
            {
                // 7
                showGeometry.Transform = new RotateTransform(-144.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 16)
            {
                // 16
                showGeometry.Transform = new RotateTransform(-126.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 8)
            {
                // 8
                showGeometry.Transform = new RotateTransform(-108.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 11)
            {
                // 11
                showGeometry.Transform = new RotateTransform(-90.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 14)
            {
                // 14
                showGeometry.Transform = new RotateTransform(-72.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 9)
            {
                // 9
                showGeometry.Transform = new RotateTransform(-54.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 12)
            {
                // 12
                showGeometry.Transform = new RotateTransform(-36.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 5)
            {
                // 5
                showGeometry.Transform = new RotateTransform(-18.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 20)
            {
                // 20
                showGeometry.Transform = new RotateTransform(0.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 1)
            {
                // 1
                showGeometry.Transform = new RotateTransform(18.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 18)
            {
                // 18
                showGeometry.Transform = new RotateTransform(36.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 4)
            {
                // 4
                showGeometry.Transform = new RotateTransform(54.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 13)
            {
                // 13
                showGeometry.Transform = new RotateTransform(72.0, center.X, center.Y);
                return showGeometry;
            }

            return null;
        }

        /// <summary>Gets the triple geometry.</summary>
        /// <param name="center">The render center.</param>
        /// <param name="tripleCircle">The triple circle.</param>
        /// <returns>The geometry of the triple circle.</returns>
        private Geometry GetTripleGeometry(Point center, Geometry tripleCircle)
        {
            var transLeft = new RotateTransform(171.0, center.X, center.Y);
            var transRight = new RotateTransform(99.0, center.X, center.Y);

            Geometry rectRight = new RectangleGeometry(new Rect(new Point(center.X, center.Y), new Point(center.X - 1000.0, center.Y - 1000.0)), 0.0, 0.0, transRight);
            Geometry rectLeft = new RectangleGeometry(new Rect(new Point(center.X, center.Y), new Point(center.X + 1000.0, center.Y + 1000.0)), 0.0, 0.0, transLeft);
            Geometry rectButtom = new RectangleGeometry(new Rect(new Point(center.X - 1000.0, center.Y), new Point(center.X + 1000.0, center.Y + 1000.0)));

            var intermediateGeometry = new CombinedGeometry(GeometryCombineMode.Union, rectLeft, rectRight);
            var maskGeometry = new CombinedGeometry(GeometryCombineMode.Union, intermediateGeometry, rectButtom);

            var showGeometry = new CombinedGeometry(GeometryCombineMode.Exclude, tripleCircle, maskGeometry);

            if (points == 18)
            {
                // 6
                showGeometry.Transform = new RotateTransform(90.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 30)
            {
                // 10
                showGeometry.Transform = new RotateTransform(108.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 45)
            {
                // 15
                showGeometry.Transform = new RotateTransform(126.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 6)
            {
                // 2
                showGeometry.Transform = new RotateTransform(144.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 51)
            {
                // 17
                showGeometry.Transform = new RotateTransform(162.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 9)
            {
                // 3
                showGeometry.Transform = new RotateTransform(180.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 57)
            {
                // 19
                showGeometry.Transform = new RotateTransform(-162.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 21)
            {
                // 7
                showGeometry.Transform = new RotateTransform(-144.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 48)
            {
                // 16
                showGeometry.Transform = new RotateTransform(-126.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 24)
            {
                // 8
                showGeometry.Transform = new RotateTransform(-108.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 33)
            {
                // 11
                showGeometry.Transform = new RotateTransform(-90.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 42)
            {
                // 14
                showGeometry.Transform = new RotateTransform(-72.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 27)
            {
                // 9
                showGeometry.Transform = new RotateTransform(-54.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 36)
            {
                // 12
                showGeometry.Transform = new RotateTransform(-36.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 15)
            {
                // 5
                showGeometry.Transform = new RotateTransform(-18.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 60)
            {
                // 20
                showGeometry.Transform = new RotateTransform(0.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 3)
            {
                // 1
                showGeometry.Transform = new RotateTransform(18.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 54)
            {
                // 18
                showGeometry.Transform = new RotateTransform(36.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 12)
            {
                // 4
                showGeometry.Transform = new RotateTransform(54.0, center.X, center.Y);
                return showGeometry;
            }

            if (points == 39)
            {
                // 13
                showGeometry.Transform = new RotateTransform(72.0, center.X, center.Y);
                return showGeometry;
            }

            return null;
        }

        #endregion Private Methods
    }
}