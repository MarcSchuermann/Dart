// -----------------------------------------------------------------------
// <copyright file="IPlugIn.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Schuermann.Darts.Environment.Extensibility
{
   /// <summary>The plug in interface.</summary>
   public interface IPlugIn : IEquatable<IPlugIn>
   {
      #region Public Properties

      /// <summary>Gets the name.</summary>
      /// <value>The name.</value>
      string Name { get; }

      /// <summary>Gets the plug in command.</summary>
      /// <value>The plug in command.</value>
      IPlugInCommand PlugInCommand { get; }

      #endregion Public Properties
   }
}