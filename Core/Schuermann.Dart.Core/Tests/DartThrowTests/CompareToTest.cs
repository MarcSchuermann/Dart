// -----------------------------------------------------------------------
// <copyright file="CompareToTest.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schuermann.Dart.Core.Thrown;

namespace GameLogicTests.DartThrowTests
{
   /// <summary>Tests the method CompareTo.</summary>
   [TestClass]
    public class CompareToTest
    {
        #region Public Methods

        /// <summary>
        ///    Compares to should return minus one when compare to lower multiplier.
        /// </summary>
        [TestMethod]
        public void CompareToShouldReturnMinusOneWhenCompareToLowerMultiplier()
        {
            var twelve = new DartThrow(DartBoardField.Six, DartBoardQuantifier.Double);
            var eleven = new DartThrow(DartBoardField.Eleven, DartBoardQuantifier.Single);
            eleven.CompareTo(twelve).Should().Be(-1);
        }

        /// <summary>Compares to should return minus one when compare to lower points.</summary>
        [TestMethod]
        public void CompareToShouldReturnMinusOneWhenCompareToLowerPoints()
        {
            var seventeen = new DartThrow(DartBoardField.Seventeen, DartBoardQuantifier.Single);
            var eighteen = new DartThrow(DartBoardField.Eighteen, DartBoardQuantifier.Single);
            seventeen.CompareTo(eighteen).Should().Be(-1);
        }

        /// <summary>Compares to should return one when compare to lower multiplier.</summary>
        [TestMethod]
        public void CompareToShouldReturnOneWhenCompareToLowerMultiplier()
        {
            var twelve = new DartThrow(DartBoardField.Six, DartBoardQuantifier.Double);
            var eleven = new DartThrow(DartBoardField.Eleven, DartBoardQuantifier.Single);
            twelve.CompareTo(eleven).Should().Be(1);
        }

        /// <summary>Compares to should return one when compare to lower points.</summary>
        [TestMethod]
        public void CompareToShouldReturnOneWhenCompareToLowerPoints()
        {
            var seventeen = new DartThrow(DartBoardField.Seventeen, DartBoardQuantifier.Single);
            var eighteen = new DartThrow(DartBoardField.Eighteen, DartBoardQuantifier.Single);
            eighteen.CompareTo(seventeen).Should().Be(1);
        }

        /// <summary>Compares to should return one when compare to null.</summary>
        [TestMethod]
        public void CompareToShouldReturnOneWhenCompareToNull()
        {
            var tripleEight1 = new DartThrow(DartBoardField.Eight, DartBoardQuantifier.Triple);
            tripleEight1.CompareTo(null).Should().Be(1);
        }

        /// <summary>Compares to should return zero when points are equal.</summary>
        [TestMethod]
        public void CompareToShouldReturnZeroWhenPointsAreEqual()
        {
            var single12 = new DartThrow(DartBoardField.Twelve, DartBoardQuantifier.Single);
            var double6 = new DartThrow(DartBoardField.Six, DartBoardQuantifier.Double);
            single12.CompareTo(double6).Should().Be(0);
        }

        /// <summary>Compares to should return zero when points are same.</summary>
        [TestMethod]
        public void CompareToShouldReturnZeroWhenPointsAreSame()
        {
            var tripleEight1 = new DartThrow(DartBoardField.Eight, DartBoardQuantifier.Triple);
            var tripleEight2 = new DartThrow(DartBoardField.Eight, DartBoardQuantifier.Triple);
            tripleEight1.CompareTo(tripleEight2).Should().Be(0);
        }

        #endregion Public Methods
    }
}