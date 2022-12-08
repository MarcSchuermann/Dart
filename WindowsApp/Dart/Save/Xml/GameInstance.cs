// -----------------------------------------------------------------------
// <copyright file="GameInstance.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Xml.Serialization;
using Schuermann.Darts.GameCore.Game;

namespace Dart.Save.Xml
{
    /// <summary>The game instance that should be serialized.</summary>
    [XmlRoot]
    public class GameInstance
    {
        #region Public Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="GameInstance" /> class.
        /// </summary>
        public GameInstance() : this(new GameProcedure())
        {
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="GameInstance" /> class.
        /// </summary>
        /// <param name="currentGame">The current game.</param>
        public GameInstance(IGameProcedure currentGame)
        {
            if (currentGame == null)
                throw new ArgumentNullException(nameof(currentGame));

            if (currentGame.CurrentPlayer == null)
                throw new ArgumentNullException(nameof(currentGame.CurrentPlayer));

            if (currentGame.GameOptions == null)
                throw new ArgumentNullException(nameof(currentGame.GameOptions));

            CurrentPlayer = currentGame.CurrentPlayer.Name;
            AllPlayTillZero = currentGame.GameOptions.AllPlayTillZero;
            DoubleIn = currentGame.GameOptions.DoubleIn;
            DoubleOut = currentGame.GameOptions.DoubleOut;
            StartPoints = currentGame.GameOptions.StartPoints;

            PlayerList = Convert(currentGame);
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>Gets or sets a value indicating whether [all play till zero].</summary>
        /// <value><c>true</c> if [all play till zero]; otherwise, <c>false</c>.</value>
        [XmlAttribute]
        public bool AllPlayTillZero { get; set; }

        /// <summary>Gets or sets the curren player.</summary>
        /// <value>The curren player.</value>
        [XmlAttribute]
        public string CurrentPlayer { get; set; }

        /// <summary>Gets or sets a value indicating whether [double in].</summary>
        /// <value><c>true</c> if [double in]; otherwise, <c>false</c>.</value>
        [XmlAttribute]
        public bool DoubleIn { get; set; }

        /// <summary>Gets or sets a value indicating whether [double out].</summary>
        /// <value><c>true</c> if [double out]; otherwise, <c>false</c>.</value>
        [XmlAttribute]
        public bool DoubleOut { get; set; }

        /// <summary>Gets or sets the player list.</summary>
        /// <value>The player list.</value>
        [XmlArray("Playerlist")]
        [XmlArrayItem("Player", typeof(Player))]
        public Player[] PlayerList { get; set; }

        /// <summary>Gets or sets the start points.</summary>
        /// <value>The start points.</value>
        [XmlAttribute]
        public int StartPoints { get; set; }

        #endregion Public Properties

        #region Private Methods

        private static Player[] Convert(IGameProcedure currentGame)
        {
            var x = new Player[currentGame.GameOptions.PlayerList.Count];
            int i = 0;
            foreach (IPlayer player in currentGame.GameOptions.PlayerList)
            {
                x[i] = (Player)player;
                i++;
            }

            return x;
        }

        #endregion Private Methods
    }
}