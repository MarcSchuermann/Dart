// -----------------------------------------------------------------------
// <copyright file="ToStringTest.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using GameLogic.Player;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameLogicTests.PlayerTests
{
    /// <summary>Tests the to string method.</summary>
    [TestClass]
    public class ToStringTest
    {
        #region Public Methods

        /// <summary>To the name of the string returns.</summary>
        [TestMethod]
        public void ToStringReturnsName()
        {
            var player = new Player();
            player.Name = "Willy";

            Assert.AreEqual("Willy", player.ToString());
        }

        #endregion Public Methods
    }
}