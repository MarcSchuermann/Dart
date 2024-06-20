// -----------------------------------------------------------------------
// <copyright file="PlugInLoader.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Schuermann.Dart.Core.Game;

using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Schuermann.Dart.Core.Extensibility;
using Schuermann.Dart.Core.EnvironmentProps;
using Schuermann.Dart.Core.Service;
using Schuermann.Dart.App.Game.UserInterface.ViewModels;
using Schuermann.Dart.App.Common.Logger;

namespace Schuermann.Dart.App.Common.PlugIns
{
   internal class PlugInLoader
   {
      #region Private Fields

      private readonly string plugInDirectory;

      #endregion Private Fields

      #region Public Constructors

      public PlugInLoader(string plugInDirectory)
      {
         this.plugInDirectory = plugInDirectory;
      }

      #endregion Public Constructors

      #region Public Properties

      [Export(typeof(IDartService))]
      public IDartService DartService { get; set; }

      /// <summary>Gets or sets the plug ins.</summary>
      /// <value>The plug ins.</value>
      [ImportMany(AllowRecomposition = true)]
      public IEnumerable<IPlugIn> PlugIns { get; set; }

      #endregion Public Properties

      #region Public Methods

      public IEnumerable<IPlugIn> LoadPlugIns(IGameInstance gameInstance, IGameOptions gameOptions, IProperties properties)
      {
         try
         {
            var catalog = new AggregateCatalog();

            DartService = new DartService(gameInstance, gameOptions, properties);

            var dirCatalog = new DirectoryCatalog(plugInDirectory);
            catalog.Catalogs.Add(dirCatalog);

            var container = new CompositionContainer(catalog);

            container.ComposeParts(this);

            var plugins = container.GetExports<IPlugIn>();

            return PlugIns;
         }
         catch (Exception e)
         {
            LoggerUtils.GetLogger<MainWindowViewModel>().LogError(e, "Error when loading plugins");
            return Array.Empty<IPlugIn>();
         }
      }

      #endregion Public Methods
   }
}