// -----------------------------------------------------------------------
// <copyright file="SvgToImageSourceConverter.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using Svg;

namespace Dart.Common.UserInterface.Converter
{
    /// <summary>The bitmap to image converter.</summary>
    /// <seealso cref="IValueConverter" />
    public class SvgToJpegConverter : IValueConverter
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
            var imageFile = value.ToString();

            if (!File.Exists(imageFile) || !imageFile.EndsWith(".svg"))
                return null;

            string filename = Path.Combine(Path.GetTempPath(), "dart", imageFile.Replace(".svg", ".jpeg"));
            if (File.Exists(filename))
                return filename;

            if (!Directory.Exists(Path.GetDirectoryName(filename)))
                Directory.CreateDirectory(Path.GetDirectoryName(filename));

            var convertedSvg = SvgDocument.Open(imageFile);
            var bitmap = convertedSvg.Draw();

            bitmap.Save(filename);
            return filename;
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
    }
}