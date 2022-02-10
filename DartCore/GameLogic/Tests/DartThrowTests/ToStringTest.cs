// -----------------------------------------------------------------------
// <copyright file="ToStringTest.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using FluentAssertions;
using GameLogic.DartThrow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameLogicTests.DartThrowTests
{
    /// <summary>Tests the ToString method.</summary>
    [TestClass]
    public class ToStringTest
    {
        #region Public Methods

        /// <summary>Converts to stringdoubletwo.</summary>
        [TestMethod]
        public void ToStringDoubleTwo()
        {
            var dartThrow = new DartThrow(DartBoardField.Two, DartBoardQuantifier.Double);
            dartThrow.ToString().Should().Be("Double Two");
        }

        /// <summary>Blas this instance.</summary>
        [TestMethod]
        public void ToStringTripleBullseye()
        {
            var dartThrow = new DartThrow(DartBoardField.Bullseye, DartBoardQuantifier.Triple);
            dartThrow.ToString().Should().Be("Triple Bullseye");
        }

        #endregion Public Methods
    }
}