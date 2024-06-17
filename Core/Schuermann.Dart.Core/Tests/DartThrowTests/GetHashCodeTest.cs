// -----------------------------------------------------------------------
// <copyright file="GetHashCodeTest.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schuermann.Dart.Core.Thrown;

namespace GameLogicTests.DartThrowTests
{
   /// <summary>Tests the method GetHashCode.</summary>
   [TestClass]
    public class GetHashCodeTest
    {
        #region Public Methods

        /// <summary>
        ///    Gets the hash code should return not the same has for only equal points.
        /// </summary>
        [TestMethod]
        public void GetHashCodeShouldReturnNotTheSameHasForOnlyEqualPoints()
        {
            var dartThrow1 = new DartThrow(DartBoardField.Five, DartBoardQuantifier.Double);
            dartThrow1.GetHashCode().Should().Be(7);

            var dartThrow2 = new DartThrow(DartBoardField.Ten, DartBoardQuantifier.Single);
            dartThrow2.GetHashCode().Should().Be(11);
        }

        /// <summary>Gets the hash code should return.</summary>
        [TestMethod]
        public void GetHashCodeShouldReturnTenForTowInstances()
        {
            var dartThrow1 = new DartThrow(DartBoardField.Five, DartBoardQuantifier.Double);
            dartThrow1.GetHashCode().Should().Be(7);

            var dartThrow2 = new DartThrow(DartBoardField.Five, DartBoardQuantifier.Double);
            dartThrow2.GetHashCode().Should().Be(7);
        }

        #endregion Public Methods
    }
}