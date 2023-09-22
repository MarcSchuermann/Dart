// -----------------------------------------------------------------------
// <copyright file="LoggerUtils.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using Autofac;
using Dart.Tools.Logging;
using Microsoft.Extensions.Logging;

namespace Dart.Common.Logger
{
   internal class LoggerUtils
   {
      #region Public Methods

      public static ILogger GetLogger<T>()
      {
         var container = ServiceContainer.GetContainer();
         var logProvider = container.Resolve<ILogProvider>();
         var logger = logProvider.GetLogger<T>();
         return logger;
      }

      public static ILogger GetLogger(string name)
      {
         var container = ServiceContainer.GetContainer();
         var logProvider = container.Resolve<ILogProvider>();
         var logger = logProvider.GetLogger(name);
         return logger;
      }

      #endregion Public Methods
   }
}