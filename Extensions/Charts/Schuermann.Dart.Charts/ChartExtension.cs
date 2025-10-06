//-----------------------------------------------------------------------
// <copyright file="ChartExtension.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using Schuermann.Dart.Core.Extensibility;
using Schuermann.Dart.Core.Service;
using IServiceProvider = Schuermann.Dart.Core.Service.IServiceProvider;

namespace Schuermann.Dart.Charts
{
   /// <summary>
   ///
   /// </summary>
   /// <seealso cref="Environment.Extensibility.IPlugIn"/>
   [Export(typeof(IPlugIn))]
   public class ChartExtension : IPlugIn
   {
      #region Fields

      readonly IServiceProvider serviceProvider;

      #endregion

      #region Constructors

      /// <summary>
      /// Initializes a new instance of the <see cref="ChartExtension"/> class.
      /// </summary>
      /// <param name="gameOptions">The game options.</param>
      /// <param name="properties">The properties.</param>
      [ImportingConstructor]
      public ChartExtension(IServiceProvider serviceProvider)
      {
         this.serviceProvider = serviceProvider;
         PlugInCommand = new PlugInCommand(this, ShowChartExtension, false, true);
      }

      #endregion

      #region Private methods

      #region Private Methods

      void ShowChartExtension()
      {
         var window = new Window();
         var grid = new Grid();

         var throwGameService = ServiceProvider.Instance.Get<IThrowGameService>() as IThrowGameService;
         var environmentService = ServiceProvider.Instance.Get<IEnvironmentService>() as IEnvironmentService;
         grid.Children.Add(new Chart(throwGameService.GetGameProcedure().Instance, environmentService.GetProperties()));
         window.Content = grid;

         window.Show();
      }

      #endregion

      #endregion Private Methods


      #region Public Properties

      /// <summary>
      /// Gets the name.
      /// </summary>
      /// <value>The name.</value>
      public string Name => "Charts";

      /// <summary>
      /// Gets the plug in command.
      /// </summary>
      /// <value>The plug in command.</value>
      public IPlugInCommand PlugInCommand { get; }

      #endregion Public Properties

      #region Public Methods

      /// <summary>
      /// Indicates whether the current object is equal to another object of the same type.
      /// </summary>
      /// <param name="other">An object to compare with this object.</param>
      /// <returns>
      /// <see langword="true"/> if the current object is equal to the <paramref name="other"/> parameter; otherwise,
      /// <see langword="false"/>.
      /// </returns>
      public bool Equals(IPlugIn other)
      {
         return other?.Name == Name;
      }

      /// <summary>
      /// Determines whether the specified <see cref="object"/>, is equal to this instance.
      /// </summary>
      /// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
      /// <returns>
      /// <c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.
      /// </returns>
      public override bool Equals(object obj)
      {
         return obj is IPlugIn plugIn ? Equals(plugIn) : false;
      }

      /// <summary>
      /// Returns a hash code for this instance.
      /// </summary>
      /// <returns>
      /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
      /// </returns>
      public override int GetHashCode()
      {
         return Name.GetHashCode();
      }

      /// <summary>
      /// Converts to string.
      /// </summary>
      /// <returns>A <see cref="string"/> that represents this instance.</returns>
      public override string ToString()
      {
         return Name;
      }

      #endregion Public Methods
   }
}
