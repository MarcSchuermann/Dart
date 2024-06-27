//-----------------------------------------------------------------------
// <copyright file="ThrowGameService.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Schuermann.Dart.Core.Game;

namespace Schuermann.Dart.Core.Service
{
   /// <summary>
   /// The dart service.
   /// </summary>
   /// <seealso cref="IThrowGameService"/>
   public class ThrowGameService : IThrowGameService
   {
      #region Fields

      private IGameProcedure gameProcedure;

      private readonly IGameOptions gameOptions;

      #endregion

      #region Public properties

      /// <summary>
      /// Gets the name.
      /// </summary>
      /// <value>The name.</value>
      public string Name => nameof(ThrowGameService);

      #endregion

      #region Public methods

      /// <summary>
      /// Gets the game instance.
      /// </summary>
      /// <returns></returns>
      public IGameProcedure GetGameProcedure()
      {
         return gameProcedure;
      }

      /// <summary>
      /// Gets the game options.
      /// </summary>
      /// <returns></returns>
      public IGameOptions GetGameOptions()
      {
         return gameOptions;
      }

      public void RestartGame()
      {
         throw new System.NotImplementedException();
      }

      public void StartGame(IGameOptions gameOptions)
      {
         gameProcedure = new GameProcedure(gameOptions);
      }

      #endregion
   }
}
