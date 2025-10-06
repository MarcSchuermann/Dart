//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schuermann.Dart.App.Settings;

namespace UnitTests.Settings.ApplicationSettingsTests
{
    /// <summary>Test the equal of the class.</summary>
    [TestClass]
    public class EquatableTests
    {
        #region Public Methods

        /// <summary>Returns the false when compare one property.</summary>
        [TestMethod]
        public void ReturnFalseWhenCompareOneProperty()
        {
            var applicationSettings = new ApplicationSettings() { SelectedCultureInfo = new CultureInfo("de-DE") };
            var applicationSettingsToComplare = new ApplicationSettings() { SelectedCultureInfo = new CultureInfo("en-US") };

            Assert.IsFalse(applicationSettings.Equals(applicationSettingsToComplare));
        }

        /// <summary>Returns the false when compare three property.</summary>
        [TestMethod]
        public void ReturnFalseWhenCompareThreeProperty()
        {
            var applicationSettings = new ApplicationSettings() { SelectedCultureInfo = new CultureInfo("de-DE"), ShowUserInterfaceDartBoardData = true };
            var applicationSettingsToComplare = new ApplicationSettings() { SelectedCultureInfo = new CultureInfo("en-US"), ShowUserInterfaceDartBoardData = false };

            Assert.IsFalse(applicationSettings.Equals(applicationSettingsToComplare));
        }

        /// <summary>Returns the false when compare to only one set property.</summary>
        [TestMethod]
        public void ReturnFalseWhenCompareToOnlyOneSetProperty()
        {
            var applicationSettings = new ApplicationSettings();
            var applicationSettingsToComplare = new ApplicationSettings() { SelectedCultureInfo = new CultureInfo("de-DE") };

            Assert.IsFalse(applicationSettings.Equals(applicationSettingsToComplare));
        }

        /// <summary>Returns the false when compare with null.</summary>
        [TestMethod]
        public void ReturnFalseWhenCompareWithNull()
        {
            var applicationSettings = new ApplicationSettings();

            Assert.IsFalse(applicationSettings.Equals(null));
        }

        /// <summary>Returns the false when compare with only one set property.</summary>
        [TestMethod]
        public void ReturnFalseWhenCompareWithOnlyOneSetProperty()
        {
            var applicationSettings = new ApplicationSettings() { SelectedCultureInfo = new CultureInfo("de-DE") };
            var applicationSettingsToComplare = new ApplicationSettings();

            Assert.IsFalse(applicationSettings.Equals(applicationSettingsToComplare));
        }

        /// <summary>Returns the false when comparing equals operator.</summary>
        [TestMethod]
        public void ReturnFalseWhenComparingEqualsOperator()
        {
            var applicationSettings1 = new ApplicationSettings() { ShowUserInterfaceDartBoardData = true, SelectedCultureInfo = new CultureInfo("de-DE") };
            var applicationSettings2 = new ApplicationSettings();

            Assert.IsFalse(applicationSettings1 == applicationSettings2);
        }

        /// <summary>Returns the type of the false when comparing other.</summary>
        [TestMethod]
        public void ReturnFalseWhenComparingOtherType()
        {
            var applicationSettings = new ApplicationSettings();

            Assert.IsFalse(applicationSettings.Equals(7));
        }

        /// <summary>Returns the false when comparing unequals operator.</summary>
        [TestMethod]
        public void ReturnFalseWhenComparingUnequalsOperator()
        {
            var applicationSettings1 = new ApplicationSettings() { ShowUserInterfaceDartBoardData = true, SelectedCultureInfo = new CultureInfo("de-DE") };
            var applicationSettings2 = new ApplicationSettings();

            Assert.IsTrue(applicationSettings1 != applicationSettings2);
        }

        /// <summary>Returns the true when compare with no property.</summary>
        [TestMethod]
        public void ReturnTrueWhenCompareWithNoProperty()
        {
            var applicationSettings = new ApplicationSettings();
            var applicationSettingsToComplare = new ApplicationSettings();

            Assert.IsTrue(applicationSettings.Equals(applicationSettingsToComplare));
        }

        /// <summary>Returns the true when compare with one property.</summary>
        [TestMethod]
        public void ReturnTrueWhenCompareWithOneProperty()
        {
            var applicationSettings = new ApplicationSettings() { ShowUserInterfaceDartBoardData = true };
            var applicationSettingsToComplare = new ApplicationSettings() { ShowUserInterfaceDartBoardData = true };

            Assert.IsTrue(applicationSettings.Equals(applicationSettingsToComplare));
        }

        /// <summary>Returns the true when compare with three property.</summary>
        [TestMethod]
        public void ReturnTrueWhenCompareWithThreeProperty()
        {
            var applicationSettings = new ApplicationSettings() { ShowUserInterfaceDartBoardData = true, SelectedCultureInfo = new CultureInfo("de-DE") };
            var applicationSettingsToComplare = new ApplicationSettings() { ShowUserInterfaceDartBoardData = true, SelectedCultureInfo = new CultureInfo("de-DE") };

            Assert.IsTrue(applicationSettings.Equals(applicationSettingsToComplare));
        }

        /// <summary>Returns the true when comparing equals operator.</summary>
        [TestMethod]
        public void ReturnTrueWhenComparingEqualsOperator()
        {
            var applicationSettings1 = new ApplicationSettings() { ShowUserInterfaceDartBoardData = true, SelectedCultureInfo = new CultureInfo("de-DE") };
            var applicationSettings2 = new ApplicationSettings() { ShowUserInterfaceDartBoardData = true, SelectedCultureInfo = new CultureInfo("de-DE") };

            Assert.IsTrue(applicationSettings1 == applicationSettings2);
        }

        /// <summary>Returns the true when comparing unequals operator.</summary>
        [TestMethod]
        public void ReturnTrueWhenComparingUnequalsOperator()
        {
            var applicationSettings1 = new ApplicationSettings() { ShowUserInterfaceDartBoardData = true, SelectedCultureInfo = new CultureInfo("de-DE") };
            var applicationSettings2 = new ApplicationSettings() { ShowUserInterfaceDartBoardData = true, SelectedCultureInfo = new CultureInfo("de-DE") };

            Assert.IsFalse(applicationSettings1 != applicationSettings2);
        }

        #endregion Public Methods
    }
}