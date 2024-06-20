//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using System.Windows.Media;
using Schuermann.Dart.Core.Themes;

namespace Schuermann.Dart.Charts.Themes
{
   public class Styles
   {
      #region Private Fields

      private readonly ITheme theme;

      #endregion Private Fields

      #region Public Constructors

      public Styles(ITheme theme)
      {
         this.theme = theme;
      }

      #endregion Public Constructors

      #region Public Properties

      public SolidColorBrush BaseThemeColor
      {
         get
         {
            switch (theme.BaseTheme)
            {
               case BaseTheme.dark:
                  return Brushes.Black;

               case BaseTheme.light:
                  return Brushes.White;

               default:
                  throw new ArgumentException($"{nameof(theme.BaseTheme)} value {theme.BaseTheme} is not supported.");
            }
         }
      }

      public SolidColorBrush ColorSchemaColor
      {
         get
         {
            switch (theme.ColorSchema)
            {
               case ColorSchema.red:
                  return Brushes.Red;

               case ColorSchema.green:
                  return Brushes.Green;

               case ColorSchema.blue:
                  return Brushes.Blue;

               case ColorSchema.purple:
                  return Brushes.Purple;

               case ColorSchema.orange:
                  return Brushes.Orange;

               case ColorSchema.lime:
                  return Brushes.Lime;

               case ColorSchema.emerald:
                  return Brushes.LightSeaGreen;

               case ColorSchema.teal:
                  return Brushes.Teal;

               case ColorSchema.cyan:
                  return Brushes.Cyan;

               case ColorSchema.cobalt:
                  return Brushes.MediumTurquoise;

               case ColorSchema.indigo:
                  return Brushes.Indigo;

               case ColorSchema.violet:
                  return Brushes.Violet;

               case ColorSchema.pink:
                  return Brushes.Pink;

               case ColorSchema.magenta:
                  return Brushes.Magenta;

               case ColorSchema.crimson:
                  return Brushes.Crimson;

               case ColorSchema.amber:
                  return Brushes.Goldenrod;

               case ColorSchema.yellow:
                  return Brushes.Yellow;

               case ColorSchema.brown:
                  return Brushes.Brown;

               case ColorSchema.olive:
                  return Brushes.Olive;

               case ColorSchema.steel:
                  return Brushes.SteelBlue;

               case ColorSchema.mauve:
                  return Brushes.MediumOrchid;

               case ColorSchema.taupe:
                  return Brushes.RosyBrown;

               case ColorSchema.sienna:
                  return Brushes.Sienna;

               default:
                  throw new ArgumentException($"{nameof(theme.ColorSchema)} value {theme.ColorSchema} is not supported.");
            }
         }
      }

      #endregion Public Properties
   }
}