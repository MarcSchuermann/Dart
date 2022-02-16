// -----------------------------------------------------------------------
// <copyright file="ConstructorTests.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using Environment;
using Environment.Extensibility;
using FluentAssertions;
using GameLogic.GameOptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            var myPlugIn = new MyPlugIn("myPlugIn");

            var plugInCommand = new PlugInCommand(myPlugIn, () => { }, true, true);

            plugInCommand.PlugIn.Name.Should().Be("myPlugIn");
            plugInCommand.OnExecute.Should().NotBeNull();
            plugInCommand.EnabledInGame.Should().BeTrue();
            plugInCommand.EnabledInMainMenu.Should().BeTrue();
        }

        #endregion Public Methods

        #region Private Classes

        private class MyPlugIn : IPlugIn
        {
            #region Public Constructors

            public MyPlugIn(string name)
            {
                Name = name;
            }

            #endregion Public Constructors

            #region Public Properties

            public IGameOptions GameOptions { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
            public string Name { get; set; }
            public IPlugInCommand PlugInCommand => throw new System.NotImplementedException();

            public IProperties Properties { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

            #endregion Public Properties

            #region Public Methods

            public bool Equals([AllowNull] IPlugIn other)
            {
                throw new System.NotImplementedException();
            }

            #endregion Public Methods
        }

        #endregion Private Classes
    }
}