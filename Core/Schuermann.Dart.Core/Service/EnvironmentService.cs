//-----------------------------------------------------------------------
// <copyright file="EnvironmentService.cs" company="Marc Schürmann">
//     Author: Marc Schürmann
//     Copyright (c) Marc Schürmann. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Schuermann.Dart.Core.EnvironmentProps;

namespace Schuermann.Dart.Core.Service
{
   public class EnvironmentService : IEnvironmentService
   {
      #region Private Fields

      IProperties properties;

      #endregion Private Fields

      #region Public Constructors

      public EnvironmentService(IProperties properties)
      {
         this.properties = properties;
      }

      #endregion Public Constructors

      #region Public Methods

      public IProperties GetProperties()
      {
         return properties;
      }

      #endregion Public Methods

      #region Public Properties

      public string Name => nameof(EnvironmentService);

      #endregion Public Properties

   }
}
