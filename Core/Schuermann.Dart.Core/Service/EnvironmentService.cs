//-----------------------------------------------------------------------
// <copyright file="EnvironmentService.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Schuermann.Dart.Core.EnvironmentProps;

namespace Schuermann.Dart.Core.Service
{
   /// <summary>
   /// The environment service.
   /// </summary>
   /// <seealso cref="Schuermann.Dart.Core.Service.IEnvironmentService"/>
   public class EnvironmentService : IEnvironmentService
   {
      #region Fields

      private readonly IProperties properties;

      #endregion

      #region Constructors

      /// <summary>
      /// Initializes a new instance of the <see cref="EnvironmentService"/> class.
      /// </summary>
      /// <param name="properties">The properties.</param>
      public EnvironmentService(IProperties properties)
      {
         this.properties = properties;
      }

      #endregion

      #region Public properties

      /// <summary>
      /// Gets the name.
      /// </summary>
      /// <value>The name.</value>
      public string Name => nameof(EnvironmentService);

      #endregion

      #region Public methods

      /// <summary>
      /// Gets the properties.
      /// </summary>
      /// <returns></returns>
      public IProperties GetProperties()
      {
         return properties;
      }

      #endregion
   }
}
