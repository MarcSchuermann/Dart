// -----------------------------------------------------------------------
// <copyright file="Game.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace GrpcService
{
    internal class Game
    {
        #region Private Fields

        private static GameLogic.GameProcedure.GameProcedure instance;

        #endregion Private Fields

        #region Public Properties

        public static GameLogic.GameProcedure.GameProcedure Instance
        {
            get
            {
                if (instance == null)
                    instance = new GameLogic.GameProcedure.GameProcedure(new GameLogic.GameOptions.GameOptions());

                return instance;
            }
            set { instance = value; }
        }

        #endregion Public Properties
    }
}