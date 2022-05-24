// -----------------------------------------------------------------------
// <copyright file="SvgToImageSourceConverter.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Svg;

namespace Dart.Tools.BitmapToImageSourceConverter
{
    /// <summary>The bitmap to image converter.</summary>
    /// <seealso cref="System.Windows.Data.IValueConverter" />
    public class SvgToImageSourceConverter : IValueConverter
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
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var svgContentNode = Encoding.Default.GetString((byte[])value);

            var convertedSvg = SvgDocument.FromSvg<SvgDocument>(svgContentNode);
            var bitmap = convertedSvg.Draw(32, 32);

            return ImageSourceForBitmap(bitmap);
        }

        /// <summary>Converts a value.</summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        ///    A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods

        #region Private Methods

        private static ImageSource ImageSourceForBitmap(Bitmap bmp)
        {
            var handle = bmp.GetHbitmap();
            ImageSource retVal = null;
            try
            {
                retVal = Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
            catch (Exception)
            {
            }

            return retVal;
        }

        #endregion Private Methods
    }
}