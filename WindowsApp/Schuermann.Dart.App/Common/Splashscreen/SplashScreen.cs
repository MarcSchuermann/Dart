// -----------------------------------------------------------------------
// <copyright file="SplashScreen.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Threading;

namespace Dart.Common.Splashscreen
{
    /// <summary>The splash screen.</summary>
    public class SplashScreen
    {
        #region Private Fields

        private static SplashScreenWindow splashScreenWindow;

        #endregion Private Fields

        #region Public Methods

        /// <summary>Hides the splash screen.</summary>
        /// <param name="immediately">if set to <c>true</c> [immediately].</param>
        public static void HideSplashScreen(bool immediately = false)
        {
            splashScreenWindow?.StartClose(immediately);
        }

        /// <summary>Shows the splash screen.</summary>
        public static void ShowSplashScreen()
        {
            if (splashScreenWindow != null)
                return;

            var thread = new Thread(StartShowSplashScreen);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        #endregion Public Methods

        #region Internal Methods

        /// <summary>Updates the progress information.</summary>
        /// <param name="progressInfoText">The progress information text.</param>
        internal static void UpdateProgress(string progressInfoText)
        {
            splashScreenWindow?.UpdateProgress(progressInfoText);
        }

        #endregion Internal Methods

        #region Private Methods

        private static void StartShowSplashScreen()
        {
            splashScreenWindow = new SplashScreenWindow { Opacity = 0 };
            splashScreenWindow.ShowDialog();
        }

        #endregion Private Methods
    }
}