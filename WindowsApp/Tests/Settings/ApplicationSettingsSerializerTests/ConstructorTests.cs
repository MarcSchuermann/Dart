//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Settings.ApplicationSettingsSerializerTests
{
    /// <summary>Tests the constructor.</summary>
    [TestClass]
    public class ConstructorTests
    {
        #region Public Methods

        /// <summary>Initializes the default constructor.</summary>
        [TestMethod]
        public void InitializeDefaultConstructor()
        {
            //var applicationSettingsSerializer = new ApplicationSettingsSerializer();
            //var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DartApplicationSettings.xml");

            //Assert.AreEqual(filePath, applicationSettingsSerializer.SettingsFileLocation);
        }

        /// <summary>Initializes the parameter constructor.</summary>
        [TestMethod]
        public void InitializeParameterConstructor()
        {
            //var applicationSettingsSerializer = new ApplicationSettingsSerializer("HansWurscht");

            //Assert.AreEqual("HansWurscht", applicationSettingsSerializer.SettingsFileLocation);
        }

        #endregion Public Methods
    }
}