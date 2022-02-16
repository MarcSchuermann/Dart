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
            var plugIn = new Mock<IPlugIn>();
            plugIn.SetupGet(x => x.Name).Returns("myPlugIn");

            var plugInCommand = new PlugInCommand(plugIn.Object, () => { }, true, true);

            plugInCommand.PlugIn.Name.Should().Be("myPlugIn");
            plugInCommand.OnExecute.Should().NotBeNull();
            plugInCommand.EnabledInGame.Should().BeTrue();
            plugInCommand.EnabledInMainMenu.Should().BeTrue();
        }

        #endregion Public Methods
    }
}