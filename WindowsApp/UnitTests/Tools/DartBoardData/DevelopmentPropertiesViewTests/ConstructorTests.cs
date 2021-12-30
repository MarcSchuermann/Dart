//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using Dart.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace UnitTests.Tools.DartBoardData.DevelopmentPropertiesViewTests
{
    /// <summary>
    /// The constructor test.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ConstructorTests
    {
        #region Public Methods

        /// <summary>Initializeds the correct.</summary>
        [TestMethod]
        public void InitializedCorrect()
        {
            var developmentPropertiesView = new DevelopmentPropertiesView();
        }

        #endregion Public Methods
    }
}