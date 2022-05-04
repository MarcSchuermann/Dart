// -----------------------------------------------------------------------
// <copyright file="Player.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel;
using Schuermann.Darts.GameCore.Thrown;

namespace Schuermann.Darts.GameCore.Game
{
    /// <summary>The Player.</summary>
    public class Player : IPlayer, INotifyPropertyChanged
    {
        #region Private Fields

        /// <summary>The current score.</summary>
        private int currentScore;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>Initializes a new instance of the <see cref="Player" /> class.</summary>
        public Player() : this(new List<IDartThrow>())
        {
        }

        #endregion Public Constructors

        #region Internal Constructors

        /// <summary>Initializes a new instance of the <see cref="Player" /> class.</summary>
        /// <param name="throwHistory">The throw history.</param>
        internal Player(List<IDartThrow> throwHistory)
        {
            ThrowHistory = throwHistory;
        }

        #endregion Internal Constructors

        #region Public Events

        /// <summary>Occurs when a property value changes.</summary>
        /// <returns></returns>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Public Events

        #region Public Properties

        /// <summary>Gets or sets the current score.</summary>
        /// <value>The current score.</value>
        public int CurrentScore
        {
            get
            {
                return currentScore;
            }
            set
            {
                currentScore = value;
                RaisePropertyChanged(nameof(CurrentScore));
            }
        }

        /// <summary>Gets or sets the dart count per round.</summary>
        /// <value>The dart count per round.</value>
        public int DartCountThisRound { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>Gets or sets the points this round.</summary>
        /// <value>The points this round.</value>
        public int PointsThisRound { get; set; }

        /// <summary>Gets or sets the round.</summary>
        /// <value>The round.</value>
        public int Round { get; set; }

        /// <summary>Gets or sets the throw history.</summary>
        /// <value>The throw history.</value>
        public IList<IDartThrow> ThrowHistory { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>Returns a <see cref="string" /> that represents this instance.</summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString()
        {
            return Name;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>Raises the property changed.</summary>
        /// <param name="propertyName">Name of the property.</param>
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion Private Methods
    }
}