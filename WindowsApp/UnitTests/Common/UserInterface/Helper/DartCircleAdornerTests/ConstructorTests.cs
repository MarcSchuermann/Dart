//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Dart;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Common.UserInterface.Helper.DartCirleAdornerTests
{
    /// <summary>The constructor test.</summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ConstructorTests
    {
        #region Public Methods

        /// <summary>Draws all doubles.</summary>
        [TestMethod]
        public void DrawAllDoubles()
        {
            ViewTestExecuter.Instance.Run(() =>
            {
                for (int i = 0; i <= 40; i = i + 2)
                {
                    var window = new Window() { RenderSize = new Size(1424, 720) };
                    var canvas = new Canvas() { RenderSize = new Size(9, 9) };
                    var button = new Button() { RenderSize = new Size(8, 8) };

                    canvas.Children.Add(button);
                    window.Content = canvas;
                    window.Show();

                    var adornerLayer = AdornerLayer.GetAdornerLayer(button);

                    var dartCircleAdorner = new DartCircleAdorner(adornerLayer, new Point(921, 356), i);

                    adornerLayer.Add(dartCircleAdorner);
                    dartCircleAdorner.UpdateLayout();
                }
            });
        }

        /// <summary>Draws all inner singles.</summary>
        [TestMethod]
        public void DrawAllInnerSingles()
        {
            ViewTestExecuter.Instance.Run(() =>
            {
                for (int i = 0; i <= 20; i++)
                {
                    var window = new Window() { RenderSize = new Size(1424, 720) };
                    var canvas = new Canvas() { RenderSize = new Size(9, 9) };
                    var button = new Button() { RenderSize = new Size(8, 8) };

                    canvas.Children.Add(button);
                    window.Content = canvas;
                    window.Show();

                    var adornerLayer = AdornerLayer.GetAdornerLayer(button);

                    var dartCircleAdorner = new DartCircleAdorner(adornerLayer, new Point(800, 356), i);

                    adornerLayer.Add(dartCircleAdorner);
                    dartCircleAdorner.UpdateLayout();
                }
            });
        }

        /// <summary>Draws all outer singles.</summary>
        [TestMethod]
        public void DrawAllOuterSingles()
        {
            ViewTestExecuter.Instance.Run(() =>
            {
                for (int i = 0; i <= 20; i++)
                {
                    var window = new Window() { RenderSize = new Size(1424, 720) };
                    var canvas = new Canvas() { RenderSize = new Size(9, 9) };
                    var button = new Button() { RenderSize = new Size(8, 8) };

                    canvas.Children.Add(button);
                    window.Content = canvas;
                    window.Show();

                    var adornerLayer = AdornerLayer.GetAdornerLayer(button);

                    var dartCircleAdorner = new DartCircleAdorner(adornerLayer, new Point(900, 356), i);

                    adornerLayer.Add(dartCircleAdorner);
                    dartCircleAdorner.UpdateLayout();
                }
            });
        }

        /// <summary>Draws all triples.</summary>
        [TestMethod]
        public void DrawAllTriples()
        {
            ViewTestExecuter.Instance.Run(() =>
            {
                for (int i = 0; i <= 60; i = i + 3)
                {
                    var window = new Window() { RenderSize = new Size(1424, 720) };
                    var canvas = new Canvas() { RenderSize = new Size(9, 9) };
                    var button = new Button() { RenderSize = new Size(8, 8) };

                    canvas.Children.Add(button);
                    window.Content = canvas;
                    window.Show();

                    var adornerLayer = AdornerLayer.GetAdornerLayer(button);

                    var dartCircleAdorner = new DartCircleAdorner(adornerLayer, new Point(842, 356), i);

                    adornerLayer.Add(dartCircleAdorner);
                    dartCircleAdorner.UpdateLayout();
                }
            });
        }

        /// <summary>Draws the inner bulls eye.</summary>
        [TestMethod]
        public void DrawInnerBullsEye()
        {
            ViewTestExecuter.Instance.Run(() =>
            {
                var window = new Window() { RenderSize = new Size(1424, 720) };
                var canvas = new Canvas() { RenderSize = new Size(9, 9) };
                var button = new Button() { RenderSize = new Size(8, 8) };

                canvas.Children.Add(button);
                window.Content = canvas;
                window.Show();

                var adornerLayer = AdornerLayer.GetAdornerLayer(button);

                var dartCircleAdorner = new DartCircleAdorner(adornerLayer, new Point(711, 356), 50);

                adornerLayer.Add(dartCircleAdorner);
                dartCircleAdorner.UpdateLayout();
            });
        }

        /// <summary>Draws the outer bulls eye.</summary>
        [TestMethod]
        public void DrawOuterBullsEye()
        {
            ViewTestExecuter.Instance.Run(() =>
            {
                var window = new Window() { RenderSize = new Size(1424, 720) };
                var canvas = new Canvas() { RenderSize = new Size(9, 9) };
                var button = new Button() { RenderSize = new Size(8, 8) };

                canvas.Children.Add(button);
                window.Content = canvas;
                window.Show();

                var adornerLayer = AdornerLayer.GetAdornerLayer(button);

                var dartCircleAdorner = new DartCircleAdorner(adornerLayer, new Point(721, 356), 50);

                adornerLayer.Add(dartCircleAdorner);
                dartCircleAdorner.UpdateLayout();
            });
        }

        /// <summary>Draws the zero.</summary>
        [TestMethod]
        public void DrawZero()
        {
            ViewTestExecuter.Instance.Run(() =>
            {
                var window = new Window() { RenderSize = new Size(1424, 720) };
                var canvas = new Canvas() { RenderSize = new Size(9, 9) };
                var button = new Button() { RenderSize = new Size(8, 8) };

                canvas.Children.Add(button);
                window.Content = canvas;
                window.Show();

                var adornerLayer = AdornerLayer.GetAdornerLayer(button);

                var dartCircleAdorner = new DartCircleAdorner(adornerLayer, new Point(2000, 356), 0);

                adornerLayer.Add(dartCircleAdorner);
                dartCircleAdorner.UpdateLayout();
            });
        }

        /// <summary>Initializeds the correct.</summary>
        [TestMethod]
        public void InitializedCorrect()
        {
            ViewTestExecuter.Instance.Run(() =>
            {
                var uielement = new UIElement() { RenderSize = new Size(100, 100) };
                var mousePosition = new Point(5, 6);
                var actuallyPoints = 20;

                var dartCircleAdorner = new DartCircleAdorner(uielement, mousePosition, actuallyPoints);

                Assert.IsFalse(dartCircleAdorner.IsHitTestVisible);
                Assert.AreEqual(50, dartCircleAdorner.Center.X);
                Assert.AreEqual(50, dartCircleAdorner.Center.Y);
            });
        }

        #endregion Public Methods
    }
}