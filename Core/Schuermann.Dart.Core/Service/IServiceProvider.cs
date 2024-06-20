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
      #region Public Methods

      /// <summary>Gets this instance.</summary>
      /// <typeparam name="T">The type of the servic.</typeparam>
      /// <returns></returns>
      IService Get<T>();

      #endregion Public Methods
   }
}