// -----------------------------------------------------------------------
// <copyright file="ExceptionCatchWindow.xaml.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Navigation;
using Autofac;
using Dart.Common;
using Dart.Tools.Logging;
using Dart.Tools.ScreenShot;
using Dart.Tools.Zip;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Dart.Tools.ExceptionHandling
{
   /// <summary>Interaction logic for ExceptionCatchWindow.xaml</summary>
   public partial class ExceptionCatchWindow : Window
   {
      #region Private Fields

      private string zipFile;

      #endregion Private Fields

      #region Public Constructors

      /// <summary>
      ///    Initializes a new instance of the <see cref="ExceptionCatchWindow" /> class.
      /// </summary>
      /// <param name="e">
      ///    The <see cref="UnhandledExceptionEventArgs" /> instance containing the event data.
      /// </param>
      public ExceptionCatchWindow(UnhandledExceptionEventArgs e)
      {
         var path = Path.GetTempPath();

         var screenshotPath = Path.Combine(path, $"dart_error_{DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")}.jpeg");
         ScreenCapture.TakeScreenshot(screenshotPath);

         InitializeComponent();

         header.Content = Properties.Resources.ExceptionCatchWindowHeader;

         var logProvider = ServiceContainer.GetContainer().Resolve<ILogProvider>();

         if (e.ExceptionObject is Exception exception)
         {
            message.Content = exception.Message;
            callStack.Text = exception.StackTrace;

            var logger = logProvider.GetLogger(exception.Source);
            logger.LogError(exception, exception.Message, exception.StackTrace);
         }

         var logFile = GetLogFile(logProvider);

         Log.CloseAndFlush();

         zipFile = Archiver.Create(path, new[] { screenshotPath, logFile });

         zipPathHyperlinkText.Text = zipFile;

         if (File.Exists(screenshotPath))
            File.Delete(screenshotPath);
      }

      #endregion Public Constructors

      #region Private Methods

      private static string GetLogFile(ILogProvider logProvider)
      {
         return logProvider != null ? logProvider.LogFile : string.Empty;
      }

      private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
      {
         var startInfo = new ProcessStartInfo();
         startInfo.FileName = "explorer.exe";
         startInfo.Arguments = "/select,\"" + zipFile + "\"";

         Process.Start(startInfo);
         e.Handled = true;
      }

      #endregion Private Methods
   }
}