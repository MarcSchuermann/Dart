// -----------------------------------------------------------------------
// <copyright file="CurrentScoreTest.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schuermann.Darts.GameCore.Game;

namespace GameLogicTests.PlayerTests
{
    /// <summary>Tests that the current score property changed event was raised.</summary>
    [TestClass]
    public class CurrentScoreTest
    {
        #region Public Methods

        /// <summary>Raises the property changed setting current score.</summary>
        [TestMethod]
        public void RaisePropertyChangedSettingCurrentScore()
        {
            var receivedEvents = new List<string>();
            var player = new Player();

            player.PropertyChanged += (sender, e) =>
            {
                receivedEvents.Add(e.PropertyName);
            };

            player.CurrentScore = 5;

            Assert.AreEqual(1, receivedEvents.Count);
            Assert.AreEqual("CurrentScore", receivedEvents.First());
        }

        #endregion Public Methods
    }
}