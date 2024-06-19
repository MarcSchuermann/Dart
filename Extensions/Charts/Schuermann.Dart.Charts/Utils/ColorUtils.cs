//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using LiveChartsCore.Drawing;
using LiveChartsCore.SkiaSharpView.Drawing;
using LiveChartsCore.SkiaSharpView.Painting;
using Schuermann.Dart.Core.Thrown;

namespace Schuermann.Darts.Charts.Utils
{
   internal static class ColorUtils
   {
      #region Public Methods

      public static IPaint<SkiaSharpDrawingContext> GetFillFromField(IDartThrow key)
      {
         switch (key.DartBoardField)
         {
            case DartBoardField.Zero:
               return new SolidColorPaint(SkiaSharp.SKColor.Parse("#000"));
            case DartBoardField.One:
               // Light Yellow
               if (key.DartBoardQuantifier == DartBoardQuantifier.Single)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#CFF0"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Double)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#AFF0"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Triple)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#8FF0"));
               break;
               // Dark Yellow
            case DartBoardField.Two:
               if (key.DartBoardQuantifier == DartBoardQuantifier.Single)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#CCFFD700"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Double)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#AAFFD700"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Triple)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#88FFD700"));
               break;
            case DartBoardField.Three:
               // Orange
               if (key.DartBoardQuantifier == DartBoardQuantifier.Single)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#CF80"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Double)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#AF80"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Triple)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#8F80"));
               break;
            case DartBoardField.Four:
               // Orange Red
               if (key.DartBoardQuantifier == DartBoardQuantifier.Single)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#CF40"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Double)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#AF40"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Triple)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#8F40"));
               break;
            case DartBoardField.Five:
               // Red
               if (key.DartBoardQuantifier == DartBoardQuantifier.Single)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#CF00"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Double)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#AF00"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Triple)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#8F00"));
               break;
            case DartBoardField.Six:
               // Dark Red
               if (key.DartBoardQuantifier == DartBoardQuantifier.Single)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#C800"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Double)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#A800"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Triple)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#8800"));
               break;
            case DartBoardField.Seven:
               // Rosa
               if (key.DartBoardQuantifier == DartBoardQuantifier.Single)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#CF7F"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Double)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#AF7F"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Triple)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#8F7F"));
               break;
            case DartBoardField.Eight:
               // Light Pink
               if (key.DartBoardQuantifier == DartBoardQuantifier.Single)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#CF0F"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Double)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#AF0F"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Triple)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#8F0F"));
               break;
            case DartBoardField.Nine:
               // Dark Pink
               if (key.DartBoardQuantifier == DartBoardQuantifier.Single)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#C808"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Double)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#A808"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Triple)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#8808"));
               break;
            case DartBoardField.Ten:
               // Light Purple
               if (key.DartBoardQuantifier == DartBoardQuantifier.Single)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#C77F"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Double)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#A77F"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Triple)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#877F"));
               break;
            case DartBoardField.Eleven:
               // Dark Purple
               if (key.DartBoardQuantifier == DartBoardQuantifier.Single)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#C80F"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Double)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#A80F"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Triple)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#880F"));
               break;
            case DartBoardField.Twelve:
               // Light Green
               if (key.DartBoardQuantifier == DartBoardQuantifier.Single)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#C0F8"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Double)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#A0F8"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Triple)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#80F8"));
               break;
            case DartBoardField.Thirteen:
               // Green
               if (key.DartBoardQuantifier == DartBoardQuantifier.Single)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#C0F0"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Double)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#A0F0"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Triple)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#80F0"));
               break;
            case DartBoardField.Fourteen:
               // Dark Green
               if (key.DartBoardQuantifier == DartBoardQuantifier.Single)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#C080"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Double)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#A080"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Triple)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#8080"));
               break;
            case DartBoardField.Fiveteen:
               // Cyan
               if (key.DartBoardQuantifier == DartBoardQuantifier.Single)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#C0FF"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Double)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#A0FF"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Triple)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#80FF"));
               break;
            case DartBoardField.Sixteen:
               // Dark Cyan
               if (key.DartBoardQuantifier == DartBoardQuantifier.Single)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#C088"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Double)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#A088"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Triple)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#8088"));
               break;
            case DartBoardField.Seventeen:
               // Blue
               if (key.DartBoardQuantifier == DartBoardQuantifier.Single)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#C00F"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Double)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#A00F"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Triple)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#800F"));
               break;
            case DartBoardField.Eighteen:
               // Dark Blue
               if (key.DartBoardQuantifier == DartBoardQuantifier.Single)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#C008"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Double)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#A008"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Triple)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#8008"));
               break;
            case DartBoardField.Nineteen:
               // Light Brown
               if (key.DartBoardQuantifier == DartBoardQuantifier.Single)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#CCCD853F"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Double)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#AACD853F"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Triple)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#88CD853F"));
               break;
            case DartBoardField.Twenty:
               // Brown
               if (key.DartBoardQuantifier == DartBoardQuantifier.Single)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#CCA0522D"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Double)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#AAA0522D"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Triple)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#88A0522D"));
               break;
            case DartBoardField.Bullseye:
               // Brown
               if (key.DartBoardQuantifier == DartBoardQuantifier.Single)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#CC8B4513"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Double)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#AA8B4513"));
               if (key.DartBoardQuantifier == DartBoardQuantifier.Triple)
                  return new SolidColorPaint(SkiaSharp.SKColor.Parse("#888B4513"));
               break;
         }

         return new SolidColorPaint(SkiaSharp.SKColor.Parse("#000"));
      }

      public static IPaint<SkiaSharpDrawingContext> GetLightFillFromIndex(int index)
      {
         index += 1;

         if (index % 8 == 0)
            return new SolidColorPaint(SkiaSharp.SKColor.Parse("#1AFF00E0")) { StrokeThickness = 4 };
         if (index % 7 == 0)
            return new SolidColorPaint(SkiaSharp.SKColor.Parse("#1A8F00FF")) { StrokeThickness = 4 };
         if (index % 6 == 0)
            return new SolidColorPaint(SkiaSharp.SKColor.Parse("#1A00E0FF")) { StrokeThickness = 4 };
         if (index % 5 == 0)
            return new SolidColorPaint(SkiaSharp.SKColor.Parse("#1AFF8000")) { StrokeThickness = 4 };
         if (index % 4 == 0)
            return new SolidColorPaint(SkiaSharp.SKColor.Parse("#1A00FF00")) { StrokeThickness = 4 };
         if (index % 3 == 0)
            return new SolidColorPaint(SkiaSharp.SKColor.Parse("#1AFFF000")) { StrokeThickness = 4 };
         if (index % 2 == 0)
            return new SolidColorPaint(SkiaSharp.SKColor.Parse("#1A000FFF")) { StrokeThickness = 4 };

         return new SolidColorPaint(SkiaSharp.SKColor.Parse("#1AFFFF00")) { StrokeThickness = 4 };
      }

      public static IPaint<SkiaSharpDrawingContext> GetMiddleFillFromIndex(int index)
      {
         index += 1;

         if (index % 8 == 0)
            return new SolidColorPaint(SkiaSharp.SKColor.Parse("#CCFF00E0")) { StrokeThickness = 4 };
         if (index % 7 == 0)
            return new SolidColorPaint(SkiaSharp.SKColor.Parse("#CC8F00FF")) { StrokeThickness = 4 };
         if (index % 6 == 0)
            return new SolidColorPaint(SkiaSharp.SKColor.Parse("#CC00E0FF")) { StrokeThickness = 4 };
         if (index % 5 == 0)
            return new SolidColorPaint(SkiaSharp.SKColor.Parse("#CCFF8000")) { StrokeThickness = 4 };
         if (index % 4 == 0)
            return new SolidColorPaint(SkiaSharp.SKColor.Parse("#CC00FF00")) { StrokeThickness = 4 };
         if (index % 3 == 0)
            return new SolidColorPaint(SkiaSharp.SKColor.Parse("#CCFF0000")) { StrokeThickness = 4 };
         if (index % 2 == 0)
            return new SolidColorPaint(SkiaSharp.SKColor.Parse("#CC000FFF")) { StrokeThickness = 4 };

         return new SolidColorPaint(SkiaSharp.SKColor.Parse("#CCFFFF00")) { StrokeThickness = 4 };
      }

      #endregion Public Methods

      #region Private Methods

      public static  IPaint<SkiaSharpDrawingContext> GetFillFromIndex(int index)
      {
         index += 1;

         if (index % 8 == 0)
            return new SolidColorPaint(SkiaSharp.SKColor.Parse("#FF00E0")) { StrokeThickness = 4 };
         if (index % 7 == 0)
            return new SolidColorPaint(SkiaSharp.SKColor.Parse("#8F00FF")) { StrokeThickness = 4 };
         if (index % 6 == 0)
            return new SolidColorPaint(SkiaSharp.SKColor.Parse("#00E0FF")) { StrokeThickness = 4 };
         if (index % 5 == 0)
            return new SolidColorPaint(SkiaSharp.SKColor.Parse("#FF8000")) { StrokeThickness = 4 };
         if (index % 4 == 0)
            return new SolidColorPaint(SkiaSharp.SKColor.Parse("#00FF00")) { StrokeThickness = 4 };
         if (index % 3 == 0)
            return new SolidColorPaint(SkiaSharp.SKColor.Parse("#FF0000")) { StrokeThickness = 4 };
         if (index % 2 == 0)
            return new SolidColorPaint(SkiaSharp.SKColor.Parse("#000FFF")) { StrokeThickness = 4 };

         return new SolidColorPaint(SkiaSharp.SKColor.Parse("#FFFF00")) { StrokeThickness = 4 };
      }

      #endregion Private Methods
   }
}