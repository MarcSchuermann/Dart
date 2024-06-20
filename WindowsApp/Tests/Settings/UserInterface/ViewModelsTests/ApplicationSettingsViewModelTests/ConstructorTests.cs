//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Schuermann.Dart.App.Settings.UserInterface.ViewModels;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;

namespace UnitTests.Settings.UserInterface.ViewModelsTests.ApplicationSettingsViewModelTests
{
   /// <summary>The constructor test.</summary>
   [TestClass]
   [ExcludeFromCodeCoverage]
   public class ConstructorTests
   {
      #region Public Methods

      /// <summary>
      ///    Checks the creation of default application settings when file already exist.
      /// </summary>
      [TestMethod]
      public void CallWithNull()
      {
         var applicationSettingsViewModel = new ApplicationSettingsViewModel(null);
      }

      /// <summary>Checks the creation of default application settings.</summary>
      [TestMethod]
      public void CheckCreationOfDefaultAppSettings()
      {
         //var expectedApplication = new ApplicationSettings() { AllPlayTillZero = false, ShowUserInterfaceDartBoardData = false, SelectedCultureInfo = new CultureInfo("en-US") };

         ////if (File.Exists(new ApplicationSettingsSerializer().SettingsFileLocation))
         ////    File.Delete(new ApplicationSettingsSerializer().SettingsFileLocation);

         //var mainViewModelMock = new Mock<IViewModelBase>();
         //var applicationSettingsViewModel = new ApplicationSettingsViewModel(mainViewModelMock.Object);

         //Assert.AreEqual(expectedApplication, applicationSettingsViewModel.CurrentApplicationSettings);
      }

      /// <summary>
      ///    Checks the creation of default application settings when file already exist.
      /// </summary>
      [TestMethod]
      public void CheckCreationOfDefaultAppSettingsWhenFileAlreadyExist()
      {
         ////if (!File.Exists(new ApplicationSettingsSerializer().SettingsFileLocation))
         ////    File.Create(new ApplicationSettingsSerializer().SettingsFileLocation);

         //var mainViewModelMock = new Mock<IViewModelBase>();
         //var applicationSettingsViewModel = new ApplicationSettingsViewModel(mainViewModelMock.Object);
      }

      #endregion Public Methods
   }
}