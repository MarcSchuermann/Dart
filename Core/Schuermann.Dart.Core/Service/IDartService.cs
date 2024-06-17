// -----------------------------------------------------------------------
// <copyright file="IDartService.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using Schuermann.Dart.Core.EnvironmentProps;
using Schuermann.Darts.GameCore.Game;

namespace Schuermann.Darts.GameCore.Service
{
   /// <summary>The dart serivce.</summary>
   public interface IDartService
   {
      #region Public Methods

      /// <summary>Gets the game instance.</summary>
      /// <returns></returns>
      IGameInstance GetGameInstance();

      /// <summary>Gets the game options.</summary>
      /// <returns></returns>
      IGameOptions GetGameOptions();

      /// <summary>Gets the properties.</summary>
      /// <returns></returns>
      IProperties GetProperties();

      #endregion Public Methods
   }
}