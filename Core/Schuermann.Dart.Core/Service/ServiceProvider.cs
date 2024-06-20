// -----------------------------------------------------------------------
// <copyright file="ServiceProvider.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Schuermann.Dart.Core.Service
{
   /// <summary>The service provider.</summary>
   /// <seealso cref="Schuermann.Dart.Core.Service.IServiceProvider" />
   public class ServiceProvider : IServiceProvider
   {
      #region Private Fields

      private readonly IList<IService> services;

      #endregion Private Fields

      #region Public Methods

      /// <summary>Adds the specified service.</summary>
      /// <param name="service">The service.</param>
      public void Add(IService service)
      {
         services.Add(service);
      }

      /// <summary>Gets this instance.</summary>
      /// <typeparam name="T">The type of the servic.</typeparam>
      /// <returns></returns>
      public IService Get<T>()
      {
         return services.OfType<T>().FirstOrDefault() as IService;
      }

      #endregion Public Methods
   }
}