// -----------------------------------------------------------------------
// <copyright file="ViewModelBase.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Globalization;
using Schuermann.Dart.App.Common.UserInterface.Helper;
using Schuermann.Dart.App.Common.UserInterface.Interfaces;

namespace Schuermann.Dart.App.Common.UserInterface.ViewModels
{
   /// <summary>The NotifyPropertyChanged.</summary>
   /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
   public class ViewModelBase : NotifyPropertyChanged, IViewModelBase
   {
      #region Public Properties

      /// <summary>Gets the available languages.</summary>
      /// <value>The available languages.</value>
      public Dictionary<CultureInfo, string> AvailableLanguages
      {
         get
         {
            var availableLanguages = new Dictionary<CultureInfo, string>();

            availableLanguages.Add(new CultureInfo("de-DE"), "Deutsch");
            availableLanguages.Add(new CultureInfo("en-US"), "English");

            return availableLanguages;
         }
      }

      #endregion Public Properties
   }
}