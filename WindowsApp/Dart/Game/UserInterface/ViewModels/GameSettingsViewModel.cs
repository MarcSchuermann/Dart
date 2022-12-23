// -----------------------------------------------------------------------
// <copyright file="GameSettingsViewModel.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
using System.Collections.Generic;
using System.Linq;

namespace Dart
{
    /// <summary>The GameSettingsViewModel.</summary>
    public class GameSettingsViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameSettingsViewModel"/> class.
        /// </summary>
        public GameSettingsViewModel()
        {
            SelectedPlayerCount = SelectablePlayerCount.First().ToString();
            SelectedStartPoints = SelectableStartPoints.First().ToString();
        }
        #region Private Fields

        private string selectedPlayerCount;

        private string selectedStartPoints;

        #endregion Private Fields

        #region Public Properties

        /// <summary>Gets the selectable player count.</summary>
        /// <value>The selectable player count.</value>
        public static IList<int> SelectablePlayerCount => new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };

        /// <summary>Gets the selectable start points.</summary>
        /// <value>The selectable start points.</value>
        public static IList<int> SelectableStartPoints => new List<int> { 301, 501, 701 };

        /// <summary>Gets or sets the selected player count.</summary>
        /// <value>The selected player count.</value>
        public string SelectedPlayerCount
        {
            get => selectedPlayerCount;
            set
            {
                selectedPlayerCount = value;
                RaisePropertyChanged(nameof(SelectedPlayerCount));
            }
        }

        /// <summary>Gets or sets the selected start points.</summary>
        /// <value>The selected start points.</value>
        public string SelectedStartPoints
        {
            get => selectedStartPoints;
            set
            {
                selectedStartPoints = value;
                RaisePropertyChanged(nameof(SelectedStartPoints));
            }
        }

        #endregion Public Properties
    }
}