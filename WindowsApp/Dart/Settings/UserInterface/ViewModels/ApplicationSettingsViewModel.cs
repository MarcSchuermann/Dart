// -----------------------------------------------------------------------
// <copyright file="ApplicationSettingsViewModel.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using Autofac;
using ControlzEx.Theming;
using Core;
using Dart.Common;
using Dart.Common.Theme;

namespace Dart
{
    /// <summary>The SettingsViewModel.</summary>
    /// <seealso cref="Dart.ViewModelBase"/>
    public class ApplicationSettingsViewModel : ViewModelBase, IApplicationSettingsViewModel
    {
        #region Private Fields

        private IApplicationSettings currentApplicationSettings;

        private IViewModelBase mainWindowViewModel;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>Initializes a new instance of the <see cref="ApplicationSettingsViewModel"/> class.</summary>
        /// <param name="ownerViewModel">The main window view model.</param>
        public ApplicationSettingsViewModel(IViewModelBase ownerViewModel)
        {
            mainWindowViewModel = ownerViewModel;

            CurrentApplicationSettings = GetSettings();

            CurrentTheme = GetCurrentTheme();
        }

        #endregion Public Constructors

        #region Public Delegates

        /// <summary>The language changed event heandler.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="EventArgs"/> instance containing the event data.</param>
        public delegate void LanguageChangedEventHaendler(object sender, EventArgs args);

        /// <summary>The theme changed event heandler.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="EventArgs"/> instance containing the event data.</param>
        public delegate void ThemeChangedEventHaendler(object sender, EventArgs args);

        #endregion Public Delegates

        #region Public Events

        /// <summary>Occurs when [language changed event].</summary>
        public event LanguageChangedEventHaendler LanguageChangedEvent;

        /// <summary>Occurs when [theme changed event].</summary>
        public event ThemeChangedEventHaendler ThemeChangedEvent;

        #endregion Public Events

        #region Public Properties

        /// <summary>Gets the accept settings.</summary>
        /// <value>The accept settings.</value>
        public GenericRelayCommand<Window> AcceptSettings => new GenericRelayCommand<Window>(param => AcceptApplicationSettings(param));

        /// <summary>Gets or sets a value indicating whether [all play till zero].</summary>
        /// <value><c>true</c> if [all play till zero]; otherwise, <c>false</c>.</value>
        public bool AllPlayTillZero
        {
            get => CurrentApplicationSettings.AllPlayTillZero;
            set
            {
                CurrentApplicationSettings.AllPlayTillZero = value;
                RaisePropertyChanged(nameof(CanAccept));
            }
        }

        /// <summary>Gets all themes.</summary>
        /// <value>All themes.</value>
        public IEnumerable<INamedTheme> AllThemes
        {
            get
            {
                var tmp = new List<INamedTheme>();

                foreach (var theme in ThemeManager.Current.Themes)
                {
                    var myTheme = new NamedTheme(theme);
                    tmp.Add(myTheme);
                }

                return tmp.OrderBy(x => x.OriginalTheme.ColorScheme).ThenBy(x => x.OriginalTheme.BaseColorScheme);
            }
        }

        /// <summary>Gets a value indicating whether this instance can accept.</summary>
        /// <value><c>true</c> if this instance can accept; otherwise, <c>false</c>.</value>
        public bool CanAccept => !CurrentApplicationSettings.Equals(GetSettings());

        /// <summary>Gets the cancel settings.</summary>
        /// <value>The cancel settings.</value>
        public GenericRelayCommand<Window> CancelSettings => new GenericRelayCommand<Window>(param => CancelApplicationSettings(param));

        /// <summary>Gets or sets the current application settings.</summary>
        /// <value>The current application settings.</value>
        public IApplicationSettings CurrentApplicationSettings
        {
            get
            {
                return currentApplicationSettings;
            }
            set
            {
                currentApplicationSettings = value;
                RaisePropertyChanged(nameof(CurrentApplicationSettings));
            }
        }

        /// <summary>Gets or sets the current theme.</summary>
        /// <value>The current theme.</value>
        public INamedTheme CurrentTheme
        {
            get => CurrentApplicationSettings.CurrentTheme;
            set
            {
                CurrentApplicationSettings.CurrentTheme = value;
                if (Application.Current != null)
                    ThemeManager.Current.ChangeTheme(Application.Current, $"{Properties.Settings.Default.BaseColorScheme}.{Properties.Settings.Default.ColorScheme}");
                RaisePropertyChanged(nameof(CanAccept));
            }
        }

        /// <summary>Gets or sets the selected culture information.</summary>
        /// <value>The selected culture information.</value>
        public CultureInfo SelectedCultureInfo
        {
            get => CurrentApplicationSettings.SelectedCultureInfo;
            set
            {
                CurrentApplicationSettings.SelectedCultureInfo = value;
                RaisePropertyChanged(nameof(CanAccept));
            }
        }

        /// <summary>Gets or sets a value indicating whether [show user interface dart board data].</summary>
        /// <value><c>true</c> if [show user interface dart board data]; otherwise, <c>false</c>.</value>
        public bool ShowUserInterfaceDartBoardData
        {
            get => CurrentApplicationSettings.ShowUserInterfaceDartBoardData;
            set
            {
                CurrentApplicationSettings.ShowUserInterfaceDartBoardData = value;
                RaisePropertyChanged(nameof(CanAccept));
            }
        }

        #endregion Public Properties

        #region Private Methods

        /// <summary>Accepts the application settings.</summary>
        /// <param name="window">The window.</param>
        private void AcceptApplicationSettings(Window window)
        {
            var languageChanged = HasLanguageChanged();
            var themeChanged = HasThemeChanged();

            SaveSettings(CurrentApplicationSettings);

            if (languageChanged)
                LanguageChangedEvent?.Invoke(this, new EventArgs());

            if (themeChanged)
                ThemeChangedEvent?.Invoke(this, new EventArgs());

            window.Close();
        }

        /// <summary>Cancels the application settings.</summary>
        /// <param name="window">The window.</param>
        private void CancelApplicationSettings(Window window)
        {
            window.Close();
        }

        private INamedTheme GetCurrentTheme()
        {
            foreach (var myTheme in AllThemes)
            {
                if (myTheme.OriginalTheme.BaseColorScheme == Properties.Settings.Default.BaseColorScheme
                    && myTheme.OriginalTheme.ColorScheme == Properties.Settings.Default.ColorScheme)
                {
                    return myTheme;
                }
            }

            return null;
        }

        /// <summary>Gets the current settings.</summary>
        /// <returns>The current applications settings.</returns>
        private IApplicationSettings GetSettings()
        {
            var container = ServiceContainer.GetContainer();
            var applicationSettings = container.Resolve<IApplicationSettings>();
            applicationSettings.ShowUserInterfaceDartBoardData = Properties.Settings.Default.ShowUserInterfaceDartBoardData;
            applicationSettings.SelectedCultureInfo = Properties.Settings.Default.CurrentCulture;
            applicationSettings.AllPlayTillZero = Properties.Settings.Default.AllPlayTillZero;
            applicationSettings.CurrentTheme = GetCurrentTheme();
            return applicationSettings;
        }

        private bool HasLanguageChanged()
        {
            return CurrentApplicationSettings.SelectedCultureInfo != Properties.Settings.Default.CurrentCulture;
        }

        private bool HasThemeChanged()
        {
            return CurrentTheme.ToString() != $"{Properties.Settings.Default.BaseColorScheme}.{Properties.Settings.Default.ColorScheme}";
        }

        private void SaveSettings(IApplicationSettings applicationSettings)
        {
            Properties.Settings.Default.ShowUserInterfaceDartBoardData = applicationSettings.ShowUserInterfaceDartBoardData;
            Properties.Settings.Default.CurrentCulture = applicationSettings.SelectedCultureInfo;
            Properties.Settings.Default.AllPlayTillZero = applicationSettings.AllPlayTillZero;

            Properties.Settings.Default.BaseColorScheme = CurrentTheme.OriginalTheme.BaseColorScheme;
            Properties.Settings.Default.ColorScheme = CurrentTheme.OriginalTheme.ColorScheme;
            Properties.Settings.Default.PrimaryAccentColor = CurrentTheme.OriginalTheme.PrimaryAccentColor;

            Properties.Settings.Default.Save();
        }

        #endregion Private Methods
    }
}