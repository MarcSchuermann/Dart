//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using Dart.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Tools.DartBoardData.DevelopmentPropertiesViewTests
{
    /// <summary>The constructor test.</summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ConstructorTests
    {
        #region Public Methods

        /// <summary>Initializeds the correct.</summary>
        [TestMethod]
        public void InitializedCorrect()
        {
            ViewTestExecuter.Instance.Run(() =>
            {
                var developmentPropertiesView = new DevelopmentPropertiesView();
            });
        }

        #endregion Public Methods
    }
}