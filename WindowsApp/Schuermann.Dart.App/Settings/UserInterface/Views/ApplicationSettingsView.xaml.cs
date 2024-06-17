// -----------------------------------------------------------------------
// <copyright file="ApplicationSettingsView.xaml.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel;
using System.Windows.Controls;
using ControlzEx.Theming;

namespace Dart
{
    /// <summary>Interaction logic for SettingsView.</summary>
    public partial class ApplicationSettingsView
    {
        #region Public Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="ApplicationSettingsView" /> class.
        /// </summary>
        public ApplicationSettingsView()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Private Methods

        private void ApplicationSettingsViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SetTheme(sender);
        }

        private void SelectedThemeChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is not ApplicationSettingsViewModel applicationSettingsViewModel)
                return;

            applicationSettingsViewModel.PropertyChanged += ApplicationSettingsViewModel_PropertyChanged;

            SetTheme(sender);
        }

        private void SetTheme(object sender)
        {
            if (sender is ApplicationSettingsViewModel applicationSettingsViewModel)
            {
                ThemeManager.Current.ChangeTheme(this, applicationSettingsViewModel.CurrentTheme.OriginalTheme);
                applicationSettingsViewModel.Accept();
            }
        }

        #endregion Private Methods
    }
}