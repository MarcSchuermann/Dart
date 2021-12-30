// -----------------------------------------------------------------------
// <copyright file="ApplicationSettingsView.xaml.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using ControlzEx.Theming;

namespace Dart
{
    /// <summary>Interaction logic for SettingsView.</summary>
    public partial class ApplicationSettingsView
    {
        #region Public Constructors

        /// <summary>Initializes a new instance of the <see cref="ApplicationSettingsView"/> class.</summary>
        public ApplicationSettingsView()
        {
            InitializeComponent();
            ThemeManager.Current.ChangeTheme(this, $"{Properties.Settings.Default.BaseColorScheme}.{Properties.Settings.Default.ColorScheme}");
        }

        #endregion Public Constructors

        #region Private Methods

        private void ApplicationSettingsViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            SetTheme(sender);
        }

        private void SelectedThemeChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ApplicationSettingsViewModel applicationSettingsViewModel = DataContext as ApplicationSettingsViewModel;
            applicationSettingsViewModel.PropertyChanged += ApplicationSettingsViewModel_PropertyChanged;

            SetTheme(sender);
        }

        private void SetTheme(object sender)
        {
            if (sender is ApplicationSettingsViewModel applicationSettingsViewModel)
            {
                ThemeManager.Current.ChangeTheme(this, applicationSettingsViewModel.CurrentTheme.OriginalTheme);
            }
        }

        #endregion Private Methods
    }
}