// -----------------------------------------------------------------------
// <copyright file="DartService.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using Schuermann.Dart.Core.EnvironmentProps;
using Schuermann.Dart.Core.Game;

namespace Schuermann.Dart.Core.Service
{
   /// <summary>The dart service.</summary>
   /// <seealso cref="IThrowGameService" />
   public class ThrowGameService : IThrowGameService
   {
      #region Private Fields

      private readonly IGameInstance gameInstance;
      private readonly IGameOptions gameOptions;
      private readonly IProperties properties;

      #endregion Private Fields

      #region Public Constructors

      /// <summary>
      ///    Initializes a new instance of the <see cref="ThrowGameService" /> class.
      /// </summary>
      /// <param name="gameInstance">The game instance.</param>
      /// <param name="gameOptions">The game options.</param>
      /// <param name="properties">The properties.</param>
      public ThrowGameService(IGameInstance gameInstance, IGameOptions gameOptions, IProperties properties)
      {
         this.gameInstance = gameInstance;
         this.gameOptions = gameOptions;
         this.properties = properties;
      }

      #endregion Public Constructors

      #region Public Properties

      /// <summary>Gets the name.</summary>
      /// <value>The name.</value>
      public string Name => nameof(ThrowGameService);

      #endregion Public Properties

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