// -----------------------------------------------------------------------
// <copyright file="PlayerlistUtils.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using Schuermann.Darts.GameCore.Game;

namespace Schuermann.Darts.GameCore.Util
{
    internal static class PlayerlistUtils
    {
        #region Public Methods

        /// <summary>Gets the privious player.</summary>
        /// <param name="players">The players.</param>
        /// <param name="player">The player.</param>
        /// <returns></returns>
        public static IPlayer GetPriviousPlayer(this IEnumerable<IPlayer> players, IPlayer player)
        {
            var playerList = players.ToList();
            var index = playerList.IndexOf(player);

            if (index == -1)
                return player;

            if (index - 1 >= 0)
                return playerList[index - 1];

            return playerList.Last();
        }

        #endregion Public Methods
    }
}