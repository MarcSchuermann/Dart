// -----------------------------------------------------------------------
// <copyright file="DartServiceImpl.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using GameLogic.Player;
using Google.Protobuf.Collections;
using Grpc.Core;

namespace GrpcService.Services
{
    /// <summary>The implementation of the dart serivce.</summary>
    /// <seealso cref="GrpcService.DartService.DartServiceBase" />
    public class DartServiceImpl : DartService.DartServiceBase
    {
        #region Private Fields

        private readonly ILogger<DartServiceImpl> logger;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="DartServiceImpl" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public DartServiceImpl(ILogger<DartServiceImpl> logger)
        {
            this.logger = logger;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>Sends a greeting.</summary>
        /// <param name="request">The request received from the client.</param>
        /// <param name="context">
        ///    The context of the server-side call handler being invoked.
        /// </param>
        /// <returns>The response to send back to the client (wrapped by a task).</returns>
        public override Task<CurrentStanding> InitGame(GameOptions request, ServerCallContext context)
        {
            var gameOptions = new GameLogic.GameOptions.GameOptions
            {
                StartPoints = (int)request.StartPoints,
                DoubleIn = request.DoubleIn,
                DoubleOut = request.DoubleOut,
                AllPlayTillZero = request.AllPlayTillZero,
                PlayerList = Convert(request.Players).ToList(),
            };

            Game.Instance = new GameLogic.GameProcedure.GameProcedure(gameOptions);

            return Task.FromResult(GetCurrentStanding());
        }

        /// <summary>Throwns the specified request.</summary>
        /// <param name="request">The request.</param>
        /// <param name="context">The context.</param>
        /// <returns>The response to send back to the client (wrapped by a task).</returns>
        /// <exception cref="System.ArgumentNullException">gameProcedure.</exception>
        public override Task<CurrentStanding> Thrown(Throw request, ServerCallContext context)
        {
            if (Game.Instance == null)
                throw new ArgumentNullException(nameof(Game.Instance));

            var thrown = new GameLogic.DartThrow.DartThrow((GameLogic.DartThrow.DartBoardField)request.Field, (GameLogic.DartThrow.DartBoardQuantifier)request.Multipier);

            Game.Instance.PlayerThrown(thrown);

            return Task.FromResult(GetCurrentStanding());
        }

        #endregion Public Methods

        #region Private Methods

        private static IEnumerable<IPlayer> Convert(RepeatedField<Player> players)
        {
            foreach (var player in players)
            {
                yield return new GameLogic.Player.Player() { Name = player.Name, CurrentScore = (int)player.CurrentPoints };
            }
        }

        private static IEnumerable<Player> Convert(IList<IPlayer> playerList)
        {
            foreach (var player in playerList)
            {
                yield return new Player() { Name = player.Name, CurrentPoints = (uint)player.CurrentScore };
            }
        }

        private static CurrentStanding GetCurrentStanding()
        {
            var currentStanding = new CurrentStanding();
            currentStanding.Players.AddRange(Convert(Game.Instance.GameOptions.PlayerList));
            return currentStanding;
        }

        #endregion Private Methods
    }
}