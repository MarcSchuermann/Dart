// -----------------------------------------------------------------------
// <copyright file="SplashScreenWindow.xaml.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Reflection;
using System.Windows;
using System.Windows.Media.Animation;

namespace Schuermann.Dart.App.Common.Splashscreen
{
   /// <summary>Interaction logic for SplashScreenWindow.xaml.</summary>
   public partial class SplashScreenWindow : Window
   {
      #region Public Constructors

      /// <summary>
      ///    Initializes a new instance of the <see cref="SplashScreenWindow" /> class.
      /// </summary>
      public SplashScreenWindow()
      {
         InitializeComponent();
         DataContext = this;
         versionText.Text = GetAssemblyVersion();
      }

      #endregion Public Constructors

      #region Internal Methods

      /// <summary>Starts the close.</summary>
      /// <param name="immediate">if set to <c>true</c> [immediate].</param>
      internal void StartClose(bool immediate)
      {
         if (!CheckAccess())
         {
            Dispatcher.BeginInvoke(new Action(() => StartClose(immediate)));
            return;
         }

         var storyboard = TryFindResource("fadeOut") as Storyboard;
         if (immediate || storyboard == null)
         {
            Close();
         }
         else
         {
            storyboard.Completed += (o, args) => Close();
            storyboard.Begin();
         }
      }

      /// <summary>Updates the progress.</summary>
      /// <param name="progressText">The progress text.</param>
      internal void UpdateProgress(string progressText)
      {
         if (!CheckAccess())
         {
            Dispatcher.BeginInvoke(new Action(() => UpdateProgress(progressText)));
            return;
         }

         //// progressTextBlock.Text = progressText;
      }

      #endregion Internal Methods

      #region Private Methods

      private string GetAssemblyVersion()
      {
         string version = Assembly.GetExecutingAssembly()?.GetName()?.Version?.ToString();

         if (string.IsNullOrEmpty(version))
            return string.Empty;

         return $"{Properties.Resources.Version}: {version}";
      }

      private void OnWindowMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
      {
         StartClose(false);
      }

      #endregion Private Methods
   }
}