// -----------------------------------------------------------------------
// <copyright file="ScreenCapture.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Drawing;
using System.Drawing.Imaging;
using System.Windows;

namespace Dart.Tools.ScreenShot
{
    internal class ScreenCapture
    {
        #region Public Methods

        public static void TakeScreenshot(string file)
        {
            using var bitmap = new Bitmap((int)SystemParameters.VirtualScreenWidth, (int)SystemParameters.VirtualScreenHeight);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen((int)SystemParameters.VirtualScreenLeft, (int)SystemParameters.VirtualScreenTop, 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);
            }

            bitmap.Save(file, ImageFormat.Jpeg);
        }

        #endregion Public Methods
    }
}