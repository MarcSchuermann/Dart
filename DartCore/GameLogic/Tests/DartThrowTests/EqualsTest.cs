// -----------------------------------------------------------------------
// <copyright file="EqualsTest.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using GameLogic.DartThrow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameLogicTests.DartThrowTests
{
    /// <summary>The Equals Test.</summary>
    [TestClass]
    public class EqualsTest
    {
        #region Public Methods

        /// <summary>Returns the false when field is unequal.</summary>
        [TestMethod]
        public void ReturnFalseWhenFieldIsUnequal()
        {
            var dartThrow1 = new DartThrow(DartBoardField.Twenty, DartBoardQuantifier.Triple);
            var dartThrow2 = new DartThrow(DartBoardField.Two, DartBoardQuantifier.Triple);

            Assert.AreNotEqual(dartThrow1, dartThrow2);
        }

        /// <summary>Returns the false when quantifier and field is unequal.</summary>
        [TestMethod]
        public void ReturnFalseWhenQuantifierAndFieldIsUnequal()
        {
            var dartThrow1 = new DartThrow(DartBoardField.Two, DartBoardQuantifier.Double);
            var dartThrow2 = new DartThrow(DartBoardField.One, DartBoardQuantifier.Triple);

            Assert.AreNotEqual(dartThrow1, dartThrow2);
        }

        /// <summary>Returns the false when quantifier is unequal.</summary>
        [TestMethod]
        public void ReturnFalseWhenQuantifierIsUnequal()
        {
            var dartThrow1 = new DartThrow(DartBoardField.Two, DartBoardQuantifier.Double);
            var dartThrow2 = new DartThrow(DartBoardField.Two, DartBoardQuantifier.Triple);

            Assert.AreNotEqual(dartThrow1, dartThrow2);
        }

        /// <summary>Returns the true when equal.</summary>
        [TestMethod]
        public void ReturnTrueWhenEqual()
        {
            var dartThrow1 = new DartThrow(DartBoardField.Twenty, DartBoardQuantifier.Triple);
            var dartThrow2 = new DartThrow(DartBoardField.Twenty, DartBoardQuantifier.Triple);

            Assert.AreEqual(dartThrow1, dartThrow2);
        }

        #endregion Public Methods
    }
}