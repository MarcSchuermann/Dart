// -----------------------------------------------------------------------
// <copyright file="IGameProvider.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Schuermann.Darts.GameCore.Game
{
   /// <summary>The game instance provider.</summary>
   public interface IGameProvider
   {
      #region Public Properties

      /// <summary>Gets the game.</summary>
      /// <value>The game.</value>
      IGameProcedure Game { get; }

      #endregion Public Properties
   }
}