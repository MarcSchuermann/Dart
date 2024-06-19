// -----------------------------------------------------------------------
// <copyright file="GameInstance.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Linq;

namespace Schuermann.Dart.Core.Game
{
   /// <summary>The instance.</summary>
   /// <seealso cref="IGameInstance" />
   public class GameInstance : IGameInstance
   {
      #region Public Constructors

      /// <summary>Initializes a new instance of the <see cref="GameInstance" /> class.</summary>
      /// <param name="gameOptions">The game options.</param>
      public GameInstance(IGameOptions gameOptions)
      {
         GameOptions = gameOptions;
      }

      #endregion Public Constructors

      #region Public Events

      /// <summary>Occurs when [player thrown].</summary>
      public event EventHandler StandingsChanged;

      #endregion Public Events

      #region Public Properties

      /// <summary>Gets the current player.</summary>
      public IPlayer CurrentPlayer
      {
         get
         {
            var minRound = GameOptions.PlayerList.Select(x => x.Round).Min();
            return GameOptions.PlayerList.FirstOrDefault(x => x.Round.Equals(minRound));
         }
      }

      /// <summary>Gets the game options.</summary>
      /// <value>The game options.</value>
      public IGameOptions GameOptions { get; private set; }

      #endregion Public Properties

      #region Public Methods

      /// <summary>
      ///    Performs application-defined tasks associated with freeing, releasing, or resetting
      ///    unmanaged resources.
      /// </summary>
      public void Dispose()
      {
         Dispose(true);
         GC.SuppressFinalize(this);
      }

      /// <summary>Invokes the standings changed.</summary>
      /// <param name="gameProcedure">The game procedure.</param>
      public void InvokeStandingsChanged(IGameProcedure gameProcedure)
      {
         StandingsChanged?.Invoke(gameProcedure, EventArgs.Empty);
      }

      #endregion Public Methods

      #region Protected Methods

      /// <summary>Releases unmanaged and - optionally - managed resources.</summary>
      /// <param name="disposing">
      ///    <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release
      ///    only unmanaged resources.
      /// </param>
      protected virtual void Dispose(bool disposing)
      {
         if (disposing)
            GameOptions = null;
      }

      #endregion Protected Methods
   }
}