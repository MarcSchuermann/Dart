//-----------------------------------------------------------------------
// <copyright file="PlugInLoader.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

using System.ComponentModel.Composition.Hosting;
using Microsoft.Extensions.Logging;
using Schuermann.Dart.App.Common.Logger;
using Schuermann.Dart.App.Game.UserInterface.ViewModels;
using Schuermann.Dart.Core.Extensibility;
using IServiceProvider = Schuermann.Dart.Core.Service.IServiceProvider;

namespace Schuermann.Dart.App.Common.PlugIns
{
   public class PlugInLoader
   {
      #region Fields

      private readonly string plugInDirectory;

      #endregion

      #region Constructors

      public PlugInLoader(string plugInDirectory) => this.plugInDirectory = plugInDirectory;

      #endregion

      #region Public methods

      #region Public Methods

      public IEnumerable<IPlugIn> LoadPlugIns()
      {
         try
         {
            var catalog = new AggregateCatalog();

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

      #endregion

      #endregion Public Methods


      #region Public Properties

      /// <summary>
      /// Gets or sets the plug ins.
      /// </summary>
      /// <value>The plug ins.</value>
      [ImportMany(AllowRecomposition = true)]
      public IEnumerable<IPlugIn> PlugIns { get; set; }

      [Export(typeof(IServiceProvider))]
      public IServiceProvider ServiceProvider => Core.Service.ServiceProvider.Instance;

      #endregion Public Properties
   }
}
