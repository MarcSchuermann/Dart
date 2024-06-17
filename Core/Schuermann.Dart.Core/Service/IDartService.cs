// -----------------------------------------------------------------------
// <copyright file="IDartService.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using Schuermann.Dart.Core.EnvironmentProps;
using Schuermann.Darts.GameCore.Game;

namespace Schuermann.Darts.GameCore.Service
{
   public interface IDartService
   {
      #region Public Methods

      IGameInstance GetGameInstance();

      IGameOptions GetGameOptions();

      IProperties GetProperties();

      #endregion Public Methods
   }
}