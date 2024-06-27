// -----------------------------------------------------------------------
// <copyright file="IServiceProvider.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Schuermann.Dart.Core.Service
{
   /// <summary>The service provider.</summary>
   public interface IServiceProvider
   {
      #region Public Properties

      /// <summary>Gets the instance.</summary>
      /// <value>The instance.</value>
      public static IServiceProvider Instance { get; }

      #endregion Public Properties

      #region Public Methods

      /// <summary>Gets this instance.</summary>
      /// <typeparam name="T">The type of the service.</typeparam>
      /// <returns></returns>
      IService Get<T>();

      #endregion Public Methods
   }
}
