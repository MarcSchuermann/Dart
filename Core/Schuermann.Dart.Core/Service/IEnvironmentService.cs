// -----------------------------------------------------------------------
// <copyright file="IEnvironmentService.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using Schuermann.Dart.Core.EnvironmentProps;

namespace Schuermann.Dart.Core.Service
{
   /// <summary>The environment service.</summary>
   /// <seealso cref="Schuermann.Dart.Core.Service.IService" />
   public interface IEnvironmentService : IService
   {
      #region Public Methods

      /// <summary>Gets the properties.</summary>
      /// <returns></returns>
      IProperties GetProperties();

      #endregion Public Methods
   }
}