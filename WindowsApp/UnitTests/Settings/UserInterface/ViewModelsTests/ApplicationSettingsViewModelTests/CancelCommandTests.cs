//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics.CodeAnalysis;
using Dart;
using Dart.Settings.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests.Settings.UserInterface.ViewModelsTests.ApplicationSettingsViewModelTests
{
    /// <summary>Tests the cancel command.</summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class CancelCommandTests
    {
        #region Public Methods

        /// <summary>Does the not crash when cancel settings command executed.</summary>
        [STAThread]
        [TestMethod]
        public void DoNotCrashWhenCancelSettingsCommandExecuted()
        {
            ViewTestExecuter.Instance.Run(() =>
            {
                var mainViewModelMock = new Mock<IApplicationSettings>();
                var applicationSettingsViewModel = new ApplicationSettingsViewModel(mainViewModelMock.Object);

                //var cancelCommand = applicationSettingsViewModel.CancelSettings;

                //cancelCommand.Execute(new Window());
            });
        }

        #endregion Public Methods
    }
}