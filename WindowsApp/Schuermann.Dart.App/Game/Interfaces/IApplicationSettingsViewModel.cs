// -----------------------------------------------------------------------
// <copyright file="IApplicationSettingsViewModel.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using Schuermann.Dart.App.Common.UserInterface.Interfaces;
using Schuermann.Dart.App.Settings.Interfaces;
using static Schuermann.Dart.App.Settings.UserInterface.ViewModels.ApplicationSettingsViewModel;

namespace Schuermann.Dart.App.Game.Interfaces
{
   /// <summary>The application settings view model interface.</summary>
   public interface IApplicationSettingsViewModel : IViewModelBase
   {
      #region Public Events

      /// <summary>Occurs when [language changed event].</summary>
      event LanguageChangedEventHaendler LanguageChangedEvent;

      /// <summary>Occurs when [theme changed event].</summary>
      event ThemeChangedEventHaendler ThemeChangedEvent;

      #endregion Public Events

      #region Public Properties

      /// <summary>Gets or sets the current application settings.</summary>
      /// <value>The current application settings.</value>
      IApplicationSettings CurrentApplicationSettings { get; set; }

      #endregion Public Properties
   }
}