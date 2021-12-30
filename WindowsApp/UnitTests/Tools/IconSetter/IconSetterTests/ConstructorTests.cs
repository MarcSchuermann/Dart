//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace UnitTests.Tools.IconSetter.IconSetterTests
{
    /// <summary>The constructor test.</summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ConstructorTests
    {
        #region Public Methods

        /// <summary>Initializeds the correct.</summary>
        [TestMethod]
        public void InitializedWithNoError()
        {
            Dart.Tools.IconSetter.SetProgramsIcon();
        }

        /////// <summary>Initializeds the complete with no error.</summary>
        ////[TestMethod]
        ////public void InitializedCompleteWithNoError()
        ////{
        ////    var targetFilePath = Path.Combine(Application.StartupPath, "darts.ico");
        ////    File.Copy("darts.ico", targetFilePath, true);
        ////    CreateUninstalSubKeyEntryIfNotExist();

        ////    Dart.Tools.IconSetter.SetProgramsIcon();

        ////    File.Delete(targetFilePath);
        ////}

        ////[TestMethod]
        ////public void InitializedWithError()
        ////{
        ////    var targetFilePath = Path.Combine(Application.StartupPath, "darts.ico");
        ////    File.Copy("darts.ico", targetFilePath, true);
        ////    DeleteUninstalSubKeyEntryIfExist();

        ////    Dart.Tools.IconSetter.SetProgramsIcon();

        ////    File.Delete(targetFilePath);
        ////}

        ////private void DeleteUninstalSubKeyEntryIfExist()
        ////{
        ////    var iconSourcePath = Path.Combine(Application.StartupPath, "darts.ico");
        ////    var executingAssembly = Assembly.GetExecutingAssembly();

        ////    var uninstallRootKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
        ////    var uninstallSubKeys = uninstallRootKey.GetSubKeyNames();

        ////    for (int i = 0; i < uninstallSubKeys.Length; i++)
        ////    {
        ////        var uninstallKey = uninstallRootKey.OpenSubKey(uninstallSubKeys[i], true);
        ////        var valueDisplayName = uninstallKey.GetValue("DisplayName");
        ////        if (valueDisplayName != null && valueDisplayName.ToString() == "Darts")
        ////        {
        ////            uninstallKey.DeleteValue("DisplayIcon");
        ////            uninstallRootKey.DeleteSubKey(uninstallKey.Name);
        ////            break;
        ////        }
        ////    }
        ////}

        ////private void CreateUninstalSubKeyEntryIfNotExist()
        ////{
        ////    var iconSourcePath = Path.Combine(Application.StartupPath, "darts.ico");
        ////    var executingAssembly = Assembly.GetExecutingAssembly();

        ////    var uninstallRootKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
        ////    var uninstallSubKeys = uninstallRootKey.GetSubKeyNames();

        ////    var uninstalEntryExits = false;
        ////    for (int i = 0; i < uninstallSubKeys.Length; i++)
        ////    {
        ////        var uninstallKey = uninstallRootKey.OpenSubKey(uninstallSubKeys[i], true);
        ////        var valueDisplayName = uninstallKey.GetValue("DisplayName");
        ////        if (valueDisplayName != null && valueDisplayName.ToString() == "Darts")
        ////        {
        ////            uninstalEntryExits = true;
        ////            break;
        ////        }
        ////    }

        ////    if (!uninstalEntryExits)
        ////    {
        ////        uninstallRootKey.CreateSubKey("dartTestEntry", true);
        ////        var testEntry = uninstallRootKey.OpenSubKey("dartTestEntry");
        ////        testEntry.SetValue("DisplayName", "Darts");
        ////    }
        ////}

        #endregion Public Methods
    }
}