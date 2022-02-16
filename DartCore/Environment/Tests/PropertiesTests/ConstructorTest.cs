// -----------------------------------------------------------------------
// <copyright file="ConstructorTest.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Globalization;
using Environment;
using Environment.Themes;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnvironmentTests.PropertiesTests
{
    /// <summary>Constructor tests.</summary>
    [TestClass]
    public class ConstructorTest
    {
        #region Public Methods

        /// <summary>Initializes the correct.</summary>
        [TestMethod]
        public void InitCorrect()
        {
            var properties = new Properties("dark.lime", new CultureInfo("en-US"));
            properties.Theme.BaseTheme.Should().Be(BaseTheme.dark);
            properties.Theme.ColorSchema.Should().Be(ColorSchema.lime);
        }

        #endregion Public Methods
    }
}