// -----------------------------------------------------------------------
// <copyright file="MainWindowView.xaml.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Threading;
using ControlzEx.Theming;
using Dart.Tools;
using MahApps.Metro.Controls;

namespace Dart
{
    /// <summary>The MainWindow.</summary>
    /// <seealso cref="System.Windows.Window" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    [ExcludeFromCodeCoverage]
    public partial class MainWindowView : MetroWindow
    {
        #region Public Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="MainWindowView" /> class.
        /// </summary>
        public MainWindowView()
        {
            Dart.Common.Splashscreen.SplashScreen.ShowSplashScreen();

            InitializeComponent();
            IconSetter.SetProgramsIcon();
            LoadUserSettings();

            SubscribeToLanguageChangedEvent();
            SubscribeToThemeChangedEvent();

            Thread.Sleep(1500);

            Dart.Common.Splashscreen.SplashScreen.HideSplashScreen();
        }

        #endregion Public Constructors

        #region Protected Methods

        /// <summary>Raises the <see cref="E:System.Windows.Window.Closing" /> event.</summary>
        /// <param name="e">
        ///    A <see cref="T:System.ComponentModel.CancelEventArgs" /> that contains the event
        ///    data.
        /// </param>
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Properties.Settings.Default.WindowHeight = Height;
            Properties.Settings.Default.WindowWidth = Width;
            Properties.Settings.Default.WindowState = WindowState;
            Properties.Settings.Default.WindowTop = Top;
            Properties.Settings.Default.WindowLeft = Left;

            Properties.Settings.Default.Save();
        }

        #endregion Protected Methods

        #region Private Methods

        private void LoadUserSettings()
        {
            Height = Properties.Settings.Default.WindowHeight;
            Width = Properties.Settings.Default.WindowWidth;
            WindowState = Properties.Settings.Default.WindowState;
            Top = Properties.Settings.Default.WindowTop;
            Left = Properties.Settings.Default.WindowLeft;

            CultureInfo.CurrentCulture = Properties.Settings.Default.CurrentCulture;
            CultureInfo.CurrentUICulture = Properties.Settings.Default.CurrentCulture;

            ThemeManager.Current.ChangeTheme(this, $"{Properties.Settings.Default.BaseColorScheme}.{Properties.Settings.Default.ColorScheme}");
        }

        private void SetTheme(object sender)
        {
            if (sender is ApplicationSettingsViewModel applicationSettingsViewModel)
            {
                ThemeManager.Current.ChangeTheme(this, applicationSettingsViewModel.CurrentTheme.OriginalTheme);
            }
        }

        private void SettingsViewModel_LanguageChangedEvent(object sender, EventArgs args)
        {
            if (DataContext is ICloneable mainWindowViewModel)
            {
                var clone = mainWindowViewModel.Clone();
                DataContext = null;
                UpdateLayout();
                InvalidateVisual();
                DataContext = clone;
            }
        }

        private void SettingsViewModel_ThemeChangedEvent(object sender, EventArgs args)
        {
            SetTheme(sender);
        }

        private void SubscribeToLanguageChangedEvent()
        {
            if (DataContext is IMainWindowViewModel mainWindowViewModel)
            {
                mainWindowViewModel.SettingsViewModel.LanguageChangedEvent += SettingsViewModel_LanguageChangedEvent;
            }
        }

        private void SubscribeToThemeChangedEvent()
        {
            if (DataContext is IMainWindowViewModel mainWindowViewModel)
            {
                mainWindowViewModel.SettingsViewModel.ThemeChangedEvent += SettingsViewModel_ThemeChangedEvent;
            }
        }

        #endregion Private Methods
    }
}