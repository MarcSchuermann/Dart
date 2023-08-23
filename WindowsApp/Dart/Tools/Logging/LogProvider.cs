// -----------------------------------------------------------------------
// <copyright file="LogProvider.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using Serilog;
using Serilog.Exceptions;
using Serilog.Extensions.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Dart.Tools.Logging
{
   /// <summary>The logger provider.</summary>
   /// <seealso cref="Dart.Tools.Logging.ILogProvider" />
   public class LogProvider : ILogProvider
   {
      #region Private Fields

      private readonly IDictionary<string, ILogger> loggers = new Dictionary<string, ILogger>();

      #endregion Private Fields

      #region Public Constructors

      /// <summary>Initializes a new instance of the <see cref="LogProvider" /> class.</summary>
      public LogProvider()
      {
         LogFile = GetLogFile("dart.log");

         Log.Logger = new LoggerConfiguration().ReadFrom.AppSettings().Enrich.WithExceptionDetails()
        .WriteTo.File(LogFile, outputTemplate: "[{Timestamp:dd:MM:yyyy HH:mm:ss}] [{Level}] {SourceContext} {Message}{NewLine}{Exception}")
        .CreateLogger();
      }

      #endregion Public Constructors

      #region Public Properties

      /// <summary>Gets the log file.</summary>
      /// <value>The log file.</value>
      public string LogFile { get; }

      #endregion Public Properties

      #region Public Methods

      /// <summary>Gets the logger.</summary>
      /// <typeparam name="T"></typeparam>
      /// <returns></returns>
      public ILogger GetLogger<T>()
      {
         return GetLogger(typeof(T).Name);
      }

      /// <summary>Gets the logger.</summary>
      /// <param name="category">The category.</param>
      /// <returns></returns>
      public ILogger GetLogger(string category)
      {
         if (!loggers.ContainsKey(category))
            loggers[category] = new SerilogLoggerFactory().CreateLogger(category);

         return loggers[category];
      }

      #endregion Public Methods

      #region Private Methods

      private static string GetLogFile(string logFileName)
      {
         // App directory
         try
         {
            string path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, logFileName);
            path = path.Replace("\\", "/");
            var sw = new StreamWriter(path);
            sw.Close();
            return path;
         }
         catch (Exception)
         {
         }

         // AppData directory
         try
         {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), logFileName);
            var sw = new StreamWriter(path);
            sw.Close();
            return path;
         }
         catch (Exception)
         {
         }

         // LocalAppData directory
         try
         {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), logFileName);
            var sw = new StreamWriter(path);
            sw.Close();
            return path;
         }
         catch (Exception)
         {
         }

         // Temp directory
         try
         {
            string path = Path.Combine(Path.GetTempPath(), logFileName);
            var sw = new StreamWriter(path);
            sw.Close();
            return path;
         }
         catch (Exception)
         {
         }

         return logFileName;
      }

      #endregion Private Methods
   }
}