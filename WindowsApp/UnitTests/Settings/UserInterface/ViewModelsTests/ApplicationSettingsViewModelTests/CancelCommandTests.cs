//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using Dart;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Diagnostics.CodeAnalysis;
using System.Windows;

namespace UnitTests.Settings.UserInterface.ViewModelsTests.ApplicationSettingsViewModelTests
{
    /// <summary>Tests the cancel command.</summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class CancelCommandTests
    {
        #region Public Methods

        /// <summary>Does the not crash when cancel settings command executed.</summary>
        [TestMethod]
        public void DoNotCrashWhenCancelSettingsCommandExecuted()
        {
            var mainViewModelMock = new Mock<IViewModelBase>();
            var applicationSettingsViewModel = new ApplicationSettingsViewModel(mainViewModelMock.Object);

            var cancelCommand = applicationSettingsViewModel.CancelSettings;

            cancelCommand.Execute(new Window());
        }

        #endregion Public Methods
    }
}