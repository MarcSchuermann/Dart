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
using ControlzEx.Theming;
using Schuermann.Dart.App.Common.Theme;
using Schuermann.Dart.App.Common.UserInterface.ViewModels;
using Schuermann.Dart.App.Game.Interfaces;
using Schuermann.Dart.App.Settings.Interfaces;

namespace Schuermann.Dart.App.Settings.UserInterface.ViewModels
{
   /// <summary>The app settings view model</summary>
   /// <seealso cref="Schuermann.Dart.App.Common.UserInterface.ViewModels.ViewModelBase" />
   /// <seealso cref="Schuermann.Dart.App.Game.Interfaces.IApplicationSettingsViewModel" />
   public class ApplicationSettingsViewModel : ViewModelBase, IApplicationSettingsViewModel
   {
      #region Private Fields

      private IApplicationSettings currentApplicationSettings;

      #endregion Private Fields

      #region Public Constructors

      /// <summary>
      ///    Initializes a new instance of the <see cref="ApplicationSettingsViewModel" /> class.
      /// </summary>
      /// <param name="applicationSettings">The application settings.</param>
      public ApplicationSettingsViewModel(IApplicationSettings applicationSettings)
      {
         CurrentApplicationSettings = applicationSettings;

         if (applicationSettings != null)
            CurrentTheme = applicationSettings.CurrentTheme;
      }

      #endregion Public Constructors

      #region Public Delegates

      /// <summary>The language changed event heandler.</summary>
      /// <param name="sender">The sender.</param>
      /// <param name="args">
      ///    The <see cref="EventArgs" /> instance containing the event data.
      /// </param>
      public delegate void LanguageChangedEventHaendler(object sender, EventArgs args);

      /// <summary>The theme changed event heandler.</summary>
      /// <param name="sender">The sender.</param>
      /// <param name="args">
      ///    The <see cref="EventArgs" /> instance containing the event data.
      /// </param>
      public delegate void ThemeChangedEventHaendler(object sender, EventArgs args);

      #endregion Public Delegates

      #region Public Events

      /// <summary>Occurs when [language changed event].</summary>
      public event LanguageChangedEventHaendler LanguageChangedEvent;

      /// <summary>Occurs when [theme changed event].</summary>
      public event ThemeChangedEventHaendler ThemeChangedEvent;

      #endregion Public Events

      #region Public Properties

      /// <summary>Gets the label.</summary>
      /// <value>The label.</value>
      public static string Label => Properties.Resources.Settings;

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
            RaisePropertyChanged(nameof(CurrentTheme));
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
            RaisePropertyChanged(nameof(SelectedCultureInfo));
         }
      }

      /// <summary>
      ///    Gets or sets a value indicating whether [show user interface dart board data].
      /// </summary>
      /// <value>
      ///    <c>true</c> if [show user interface dart board data]; otherwise, <c>false</c>.
      /// </value>
      public bool ShowUserInterfaceDartBoardData
      {
         get => CurrentApplicationSettings.ShowUserInterfaceDartBoardData;
         set
         {
            CurrentApplicationSettings.ShowUserInterfaceDartBoardData = value;
         }
      }

      #endregion Public Properties

      #region Public Methods

      /// <summary>Accepts this instance.</summary>
      public void Accept()
      {
         SaveSettings(CurrentApplicationSettings);

         if (HasLanguageChanged())
            LanguageChangedEvent?.Invoke(this, new EventArgs());

         if (HasThemeChanged())
            ThemeChangedEvent?.Invoke(this, new EventArgs());
      }

      #endregion Public Methods

      #region Private Methods

      /// <summary>Cancels the application settings.</summary>
      /// <param name="window">The window.</param>
      private static void CancelApplicationSettings(Window window)
      {
         window.Close();
      }

      private bool HasLanguageChanged()
      {
         return CurrentApplicationSettings.SelectedCultureInfo != Properties.Settings.Default.CurrentCulture;
      }

      private bool HasThemeChanged()
      {
         return CurrentTheme.ToString() != $"{Properties.Settings.Default.BaseColorScheme} {Properties.Settings.Default.ColorScheme}";
      }

      private void SaveSettings(IApplicationSettings applicationSettings)
      {
         Properties.Settings.Default.ShowUserInterfaceDartBoardData = applicationSettings.ShowUserInterfaceDartBoardData;
         Properties.Settings.Default.CurrentCulture = applicationSettings.SelectedCultureInfo;

         Properties.Settings.Default.BaseColorScheme = CurrentTheme.OriginalTheme.BaseColorScheme;
         Properties.Settings.Default.ColorScheme = CurrentTheme.OriginalTheme.ColorScheme;
         Properties.Settings.Default.PrimaryAccentColor = CurrentTheme.OriginalTheme.PrimaryAccentColor;

         Properties.Settings.Default.Save();
      }

      #endregion Private Methods
   }
}