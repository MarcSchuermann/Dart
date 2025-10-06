// -----------------------------------------------------------------------
// <copyright file="BitmapToImageSourceConverter.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Schuermann.Dart.App.Common.UserInterface.Converter
{
   /// <summary>The bitmap to image converter.</summary>
   /// <seealso cref="IValueConverter" />
   public class BitmapToImageSourceConverter : IValueConverter
   {
      #region Public Methods

      /// <summary>Converts a value.</summary>
      /// <param name="value">The value produced by the binding source.</param>
      /// <param name="targetType">The type of the binding target property.</param>
      /// <param name="parameter">The converter parameter to use.</param>
      /// <param name="culture">The culture to use in the converter.</param>
      /// <returns>
      ///    A converted value. If the method returns null, the valid null value is used.
      /// </returns>
      public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
         MemoryStream ms = new MemoryStream();
         ((System.Drawing.Bitmap)value).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
         BitmapImage image = new BitmapImage();
         image.BeginInit();
         ms.Seek(0, SeekOrigin.Begin);
         image.StreamSource = ms;
         image.EndInit();

         return image;
      }

      /// <summary>Converts a value.</summary>
      /// <param name="value">The value that is produced by the binding target.</param>
      /// <param name="targetType">The type to convert to.</param>
      /// <param name="parameter">The converter parameter to use.</param>
      /// <param name="culture">The culture to use in the converter.</param>
      /// <returns>
      ///    A converted value. If the method returns null, the valid null value is used.
      /// </returns>
      public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
         throw new NotImplementedException();
      }

      #endregion Public Methods
   }
}