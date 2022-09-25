// -----------------------------------------------------------------------
// <copyright file="ServiceContainer.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;

namespace Dart.Common
{
    /// <summary>The container to get public services.</summary>
    public class ServiceContainer
    {
        #region Private Fields

        private static IContainer serviceContainer;

        #endregion Private Fields

        #region Public Methods

        /// <summary>Gets the container.</summary>
        /// <returns>The build container instance.</returns>
        public static IContainer GetContainer()
        {
            if (serviceContainer == null)
                serviceContainer = Init();

            return serviceContainer;
        }

        #endregion Public Methods

        #region Private Methods

        private static IContainer Init()
        {
            var config = new ConfigurationBuilder();
            config.AddJsonFile("autofac.json");

            var module = new ConfigurationModule(config.Build());
            var builder = new ContainerBuilder();
            builder.RegisterModule(module);

            var serviceContainer = builder.Build();
            serviceContainer.BeginLifetimeScope();
            return serviceContainer;
        }

        #endregion Private Methods
    }
}