// -----------------------------------------------------------------------
// <copyright file="PlugInCommand.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Schuermann.Dart.Core.Extensibility
{
   /// <summary>The simpliest implementation of the IPlugInCommand.</summary>
   /// <seealso cref="IPlugInCommand" />
   public class PlugInCommand : IPlugInCommand
   {
      #region Public Constructors

      /// <summary>
      ///    Initializes a new instance of the <see cref="PlugInCommand" /> class.
      /// </summary>
      /// <param name="plugIn">The plug in.</param>
      /// <param name="onExecute">The on execute.</param>
      /// <param name="enabledInMainMenu">if set to <c>true</c> [enabled in main menu].</param>
      /// <param name="enabledInGame">if set to <c>true</c> [enabled in game].</param>
      public PlugInCommand(IPlugIn plugIn, Action onExecute, bool enabledInMainMenu, bool enabledInGame)
      {
         PlugIn = plugIn;
         OnExecute = onExecute;
         EnabledInMainMenu = enabledInMainMenu;
         EnabledInGame = enabledInGame;
      }

      #endregion Public Constructors

      #region Public Properties

      /// <inheritdoc />
      public string DisplayText => PlugIn.Name;

      /// <inheritdoc />
      public bool EnabledInGame { get; }

      /// <inheritdoc />
      public bool EnabledInMainMenu { get; }

      /// <inheritdoc />
      public Action OnExecute { get; }

      /// <inheritdoc />
      public IPlugIn PlugIn { get; }

      #endregion Public Properties
   }
}