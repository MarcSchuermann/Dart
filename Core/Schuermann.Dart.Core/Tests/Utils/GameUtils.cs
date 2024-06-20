// -----------------------------------------------------------------------
// <copyright file="GameUtils.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using Schuermann.Dart.Core.Game;

namespace Schuermann.Dart.Core.Tests.Utils
{
   /// <summary>Utils for the game.</summary>
   internal static class GameUtils
   {
      #region Public Methods

      /// <summary>Setups the game.</summary>
      /// <param name="players">The players.</param>
      /// <returns></returns>
      public static IGameProcedure SetupGame(IList<IPlayer> players)
      {
         var gameOptions = new GameOptions(players);
         var game = new GameProcedure(gameOptions);

         return game;
      }

      #endregion Public Methods
   }
}