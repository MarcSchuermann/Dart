// -----------------------------------------------------------------------
// <copyright file="ExceptionCatchWindow.xaml.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.IO;
using System.Windows;
using Dart.Tools.ScreenShot;
using Dart.Tools.Zip;
using NLog.Targets;
using NLog;

namespace Dart.Tools.ExceptionHandling
{
   /// <summary>Interaction logic for ExceptionCatchWindow.xaml</summary>
   public partial class ExceptionCatchWindow : Window
   {
      #region Public Constructors

      /// <summary>
      ///    Initializes a new instance of the <see cref="ExceptionCatchWindow" /> class.
      /// </summary>
      /// <param name="e">
      ///    The <see cref="UnhandledExceptionEventArgs" /> instance containing the event data.
      /// </param>
      public ExceptionCatchWindow(UnhandledExceptionEventArgs e)
      {
         var path = "D:/tmp";
         
         var screenshotPath = Path.Combine(path, $"dart_error_{DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")}.jpeg");
         ScreenCapture.TakeScreenshot(screenshotPath);

         InitializeComponent();

         header.Content = Properties.Resources.ExceptionCatchWindowHeader;

         if (e.ExceptionObject is Exception exception)
         {
            message.Content = exception.Message;
            callStack.Text = exception.StackTrace;
         }

         var logFile = GetLogFile();

         Archiver.Create(path, new[] { screenshotPath, logFile });
      }

      private string GetLogFile()
      {
         if (LogManager.Configuration == null)
            return string.Empty;
         
         var fileTarget = (FileTarget)LogManager.Configuration.FindTargetByName("dart.log");
         // Need to set timestamp here if filename uses date. 
         // For example - filename="${basedir}/logs/${shortdate}/trace.log"
         var logEventInfo = new LogEventInfo { TimeStamp = DateTime.Now };
         string fileName = fileTarget.FileName.Render(logEventInfo);
         if (File.Exists(fileName))
            return fileName;

         return string.Empty;
      }

      #endregion Public Constructors
   }
}