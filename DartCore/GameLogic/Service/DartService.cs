// -----------------------------------------------------------------------
// <copyright file="DartService.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using Schuermann.Darts.GameCore.EnvironmentProps;
using Schuermann.Darts.GameCore.Game;

namespace Schuermann.Darts.GameCore.Service
{
   /// <summary>The dart service.</summary>
   /// <seealso cref="Schuermann.Darts.GameCore.Service.IDartService" />
   public class DartService : IDartService
   {
      #region Private Fields

      private readonly IGameInstance gameInstance;
      private readonly IGameOptions gameOptions;
      private readonly IProperties properties;

      #endregion Private Fields

      #region Public Constructors

      /// <summary>Initializes a new instance of the <see cref="DartService" /> class.</summary>
      /// <param name="gameInstance">The game instance.</param>
      /// <param name="gameOptions">The game options.</param>
      /// <param name="properties">The properties.</param>
      public DartService(IGameInstance gameInstance, IGameOptions gameOptions, IProperties properties)
      {
         this.gameInstance = gameInstance;
         this.gameOptions = gameOptions;
         this.properties = properties;
      }

      #endregion Public Constructors

      #region Public Methods

      /// <summary>Gets the game instance.</summary>
      /// <returns></returns>
      public IGameInstance GetGameInstance()
      {
         return gameInstance;
      }

      /// <summary>Gets the game options.</summary>
      /// <returns></returns>
      public IGameOptions GetGameOptions()
      {
         return gameOptions;
      }

      /// <summary>Gets the properties.</summary>
      /// <returns></returns>
      public IProperties GetProperties()
      {
         return properties;
      }

      #endregion Public Methods
   }
}