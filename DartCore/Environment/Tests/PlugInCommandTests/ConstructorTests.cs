// -----------------------------------------------------------------------
// <copyright file="ConstructorTests.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using Environment.Extensibility;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EnvironmentTests.PlugInCommandTests
{
    /// <summary>The constructor test.</summary>
    [TestClass]
    public class ConstructorTests
    {
        #region Public Methods

        /// <summary>Initializes the correct.</summary>
        [TestMethod]
        public void InitCorrect()
        {
            var mockPlugIn = new Mock<IPlugIn>();
            mockPlugIn.Setup(p => p.Name).Returns("myPlugIn");

            var plugInCommand = new PlugInCommand(mockPlugIn.Object, () => { }, true, true);

            plugInCommand.PlugIn.Name.Should().Be("myPlugIn");
            plugInCommand.DisplayText.Should().Be("myPlugIn");
            plugInCommand.OnExecute.Should().NotBeNull();
            plugInCommand.EnabledInGame.Should().BeTrue();
            plugInCommand.EnabledInMainMenu.Should().BeTrue();
        }

        #endregion Public Methods
    }
}