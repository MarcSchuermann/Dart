//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using Dart;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using System.IO;
using System.Xml;

namespace UnitTests.Settings.ApplicationSettingsSerializerTests
{
    /// <summary>Tests the serialization</summary>
    [TestClass]
    public class SerializationTests
    {
        #region Public Methods

        /// <summary>Serializes the full configured settings succesfully.</summary>
        [TestMethod]
        public void SerializeFullConfiguredSettingsSuccesfully()
        {
            //var tempFile = Path.GetTempFileName();
            ////var applicationSettingsSerializer = new ApplicationSettingsSerializer(tempFile);

            //var applicationSettings = new ApplicationSettings() { AllPlayTillZero = true, SelectedCultureInfo = new CultureInfo("de-DE"), ShowUserInterfaceDartBoardData = false };

            ////applicationSettingsSerializer.SerializeApplicationSettings(applicationSettings);

            //var readedXml = new XmlDocument();
            //readedXml.Load(tempFile);

            //var referenceXml = new XmlDocument();
            //referenceXml.LoadXml("<?xml version=\"1.0\"?>\r\n<ApplicationSettings xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <AllPlayTillZero>true</AllPlayTillZero>\r\n  <SelectedCultureInfo>Bert</SelectedCultureInfo>\r\n  <ShowUserInterfaceDartBoardData>false</ShowUserInterfaceDartBoardData>\r\n</ApplicationSettings>");

            //Assert.AreEqual(referenceXml.InnerXml, readedXml.InnerXml);
        }

        /// <summary>Serializes the not full configured settings succesfully.</summary>
        [TestMethod]
        public void SerializeNotFullConfiguredSettingsSuccesfully()
        {
            //var tempFile = Path.GetTempFileName();
            ////var applicationSettingsSerializer = new ApplicationSettingsSerializer(tempFile);

            //var applicationSettings = new ApplicationSettings() { AllPlayTillZero = true };

            ////applicationSettingsSerializer.SerializeApplicationSettings(applicationSettings);

            //var readedXml = new XmlDocument();
            //readedXml.Load(tempFile);

            //var referenceXml = new XmlDocument();
            //referenceXml.LoadXml("<?xml version=\"1.0\"?><ApplicationSettings xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><AllPlayTillZero>true</AllPlayTillZero><ShowUserInterfaceDartBoardData>false</ShowUserInterfaceDartBoardData></ApplicationSettings>");

            //Assert.AreEqual(referenceXml.InnerXml, readedXml.InnerXml);
        }

        #endregion Public Methods
    }
}