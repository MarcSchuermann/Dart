// -----------------------------------------------------------------------
// <copyright file="IGameInstance.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Schuermann.Darts.GameCore.Game
{
   /// <summary>The instance of a game.</summary>
   public interface IGameInstance : IDisposable
   {
      #region Public Events

      /// <summary>Occurs when [standings changed].</summary>
      event EventHandler StandingsChanged;

      #endregion Public Events

      #region Public Properties

      /// <summary>Gets the current player.</summary>
      /// <returns>The current player.</returns>
      IPlayer CurrentPlayer { get; }

      /// <summary>Gets the game options.</summary>
      /// <value>The game options.</value>
      IGameOptions GameOptions { get; }

      #endregion Public Properties

      #region Public Methods

      /// <summary>Invokes the standings changed.</summary>
      void InvokeStandingsChanged(IGameProcedure gameProcedure);

      #endregion Public Methods
   }
}