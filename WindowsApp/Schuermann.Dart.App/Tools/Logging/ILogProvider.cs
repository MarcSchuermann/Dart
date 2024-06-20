// -----------------------------------------------------------------------
// <copyright file="ILogProvider.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using Microsoft.Extensions.Logging;

namespace Schuermann.Dart.App.Tools.Logging
{
   /// <summary>The logger provider</summary>
   public interface ILogProvider
   {
      #region Public Properties

      /// <summary>Gets the log file.</summary>
      /// <value>The log file.</value>
      string LogFile { get; }

      #endregion Public Properties

      #region Public Methods

      /// <summary>Gets the logger.</summary>
      /// <typeparam name="T"></typeparam>
      /// <returns></returns>
      ILogger GetLogger<T>();

      /// <summary>Gets the logger.</summary>
      /// <param name="category">The category.</param>
      /// <returns></returns>
      ILogger GetLogger(string category);

      #endregion Public Methods
   }
}