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

      /// <summary>
      /// Restarts the current game, resetting all progress and returning to the initial state.
      /// </summary>
      /// <exception cref="System.NotImplementedException">Thrown if the method is not implemented.</exception>
      public void RestartGame()
      {
         throw new System.NotImplementedException();
      }


      /// <summary>
      /// Initializes and starts a new game session using the specified game options.
      /// </summary>
      /// <param name="gameOptions">The configuration settings to use for the new game session. Cannot be null.</param>
      public void StartGame(IGameOptions gameOptions)
      {
         gameProcedure = new GameProcedure(gameOptions);
      }

      #endregion
   }
}
