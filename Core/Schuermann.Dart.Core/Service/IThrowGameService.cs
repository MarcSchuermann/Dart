//-----------------------------------------------------------------------
// <copyright file="IThrowGameService.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Schuermann.Dart.Core.Game;

namespace Schuermann.Dart.Core.Service
{
   /// <summary>
   /// The dart service.
   /// </summary>
   public interface IThrowGameService : IService
   {
      #region Public Methods

      /// <summary>
      /// Gets the game instance.
      /// </summary>
      /// <returns></returns>
      IGameProcedure GetGameProcedure();

      /// <summary>
      /// Gets the game options.
      /// </summary>
      /// <returns></returns>
      IGameOptions GetGameOptions();

      /// <summary>
      /// Start game
      /// </summary>
      /// <param name="gameOptions"></param>
      void StartGame(IGameOptions gameOptions);

      /// <summary>
      /// Restarts the game.
      /// </summary>
      void RestartGame();

      #endregion Public Methods
   }
}
