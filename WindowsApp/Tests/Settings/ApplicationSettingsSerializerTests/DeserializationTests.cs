////// --------------------------------------------------------------------------------------------------------------------
////// <copyright>Marc Schürmann</copyright>
////// --------------------------------------------------------------------------------------------------------------------

//using Dart;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Diagnostics.CodeAnalysis;
//using System.IO;

//namespace UnitTests.Settings.ApplicationSettingsSerializerTests
//{
//    /// <summary>Tests the deserialization.</summary>
//    [TestClass]
//    [ExcludeFromCodeCoverage]
//    public class DeserializationTests
//    {
//        #region Public Methods

//        /// <summary>Deserializes the empty string.</summary>
//        [TestMethod]
//        [ExpectedException(typeof(ArgumentException))]
//        public void DeserializeEmptyString()
//        {
//            var applicationSettingsSerializer = new ApplicationSettingsSerializer(string.Empty);
//            var readedApplicationSettings = applicationSettingsSerializer.DeserializeApplicationSettings();
//        }

//        /// <summary>Deserializes the full configured settings succesfully.</summary>
//        [TestMethod]
//        public void DeserializeFullConfiguredSettingsSuccesfully()
//        {
//            using (var streamWriter = new StreamWriter("tempFile.xml"))
//            {
//                streamWriter.Write("<?xml version=\"1.0\"?>\r\n<ApplicationSettings xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <AllPlayTillZero>true</AllPlayTillZero>\r\n  <SelectedCultureInfo>Bert</SelectedCultureInfo>\r\n  <ShowUserInterfaceDartBoardData>false</ShowUserInterfaceDartBoardData>\r\n</ApplicationSettings>");
//            }

//            var applicationSettingsSerializer = new ApplicationSettingsSerializer("tempFile.xml");
//            var readedApplicationSettings = applicationSettingsSerializer.DeserializeApplicationSettings();

//            var referenceApplicationSettings = new ApplicationSettings() { AllPlayTillZero = true, SelectedCultureInfo = ApplicationSettingsSerializer, ShowUserInterfaceDartBoardData = false };

//            Assert.AreEqual(referenceApplicationSettings, readedApplicationSettings);
//        }

//        /// <summary>Deserializes the not existing file.</summary>
//        [TestMethod]
//        [ExpectedException(typeof(FileNotFoundException))]
//        public void DeserializeNotExistingFile()
//        {
//            var applicationSettingsSerializer = new ApplicationSettingsSerializer("NotExistingFile.xml");
//            var readedApplicationSettings = applicationSettingsSerializer.DeserializeApplicationSettings();
//        }

//        /// <summary>Deserializes the null.</summary>
//        [TestMethod]
//        [ExpectedException(typeof(ArgumentNullException))]
//        public void DeserializeNull()
//        {
//            var applicationSettingsSerializer = new ApplicationSettingsSerializer(null);
//            var readedApplicationSettings = applicationSettingsSerializer.DeserializeApplicationSettings();
//        }

//        /// <summary>Deserializes the settings succesfully with not serialized bool value.</summary>
//        [TestMethod]
//        public void DeserializeSettingsSuccesfullyWithNotSerializedBoolValue()
//        {
//            using (var streamWriter = new StreamWriter("tempFile.xml"))
//            {
//                streamWriter.Write("<?xml version=\"1.0\"?>\r\n<ApplicationSettings xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <SelectedCultureInfo>Bert</SelectedCultureInfo>\r\n  <ShowUserInterfaceDartBoardData>false</ShowUserInterfaceDartBoardData>\r\n</ApplicationSettings>");
//            }

//            var applicationSettingsSerializer = new ApplicationSettingsSerializer("tempFile.xml");
//            var readedApplicationSettings = applicationSettingsSerializer.DeserializeApplicationSettings();

//            var referenceApplicationSettings = new ApplicationSettings() { AllPlayTillZero = false, SelectedCultureInfo = "Bert", ShowUserInterfaceDartBoardData = false };

//            Assert.AreEqual(referenceApplicationSettings, readedApplicationSettings);
//        }

//        /// <summary>Deserializes the settings succesfully with not serialized object value.</summary>
//        [TestMethod]
//        public void DeserializeSettingsSuccesfullyWithNotSerializedObjectValue()
//        {
//            using (var streamWriter = new StreamWriter("tempFile.xml"))
//            {
//                streamWriter.Write("<?xml version=\"1.0\"?>\r\n<ApplicationSettings xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <ShowUserInterfaceDartBoardData>false</ShowUserInterfaceDartBoardData>\r\n</ApplicationSettings>");
//            }

//            var applicationSettingsSerializer = new ApplicationSettingsSerializer("tempFile.xml");
//            var readedApplicationSettings = applicationSettingsSerializer.DeserializeApplicationSettings();

//            var referenceApplicationSettings = new ApplicationSettings() { AllPlayTillZero = false, SelectedCultureInfo = null, ShowUserInterfaceDartBoardData = false };

//            Assert.AreEqual(referenceApplicationSettings, readedApplicationSettings);
//        }

//        /// <summary>Gets the invalide operation excpetion when conentent is crap.</summary>
//        [TestMethod]
//        [ExpectedException(typeof(InvalidOperationException))]
//        public void GetInvalideOperationExcpetionWhenConententIsCrap()
//        {
//            using (var streamWriter = new StreamWriter("tempFile.xml"))
//            {
//                streamWriter.Write("hallo");
//            }

//            var applicationSettingsSerializer = new ApplicationSettingsSerializer("tempFile.xml");
//            var readedApplicationSettings = applicationSettingsSerializer.DeserializeApplicationSettings();
//        }

//        #endregion Public Methods
//    }
//}