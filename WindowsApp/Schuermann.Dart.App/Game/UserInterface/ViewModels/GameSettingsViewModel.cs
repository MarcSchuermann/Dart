// -----------------------------------------------------------------------
// <copyright file="GameSettingsViewModel.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
using System.Collections.Generic;
using System.Linq;
using Dart.Game.Interfaces;

namespace Dart
{
    /// <summary>The GameSettingsViewModel.</summary>
    public class GameSettingsViewModel : ViewModelBase, IGameSettingsViewModel
    {
        #region Private Fields

        private string selectedPlayerCount;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="GameSettingsViewModel" /> class.
        /// </summary>
        public GameSettingsViewModel()
        {
            SelectedPlayerCount = "1";
            SelectedStartPoints = SelectableStartPoints.First().ToString();
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>Gets or sets a value indicating whether [double in].</summary>
        /// <value><c>true</c> if [double in]; otherwise, <c>false</c>.</value>
        public bool DoubleIn { get; set; }

        /// <summary>Gets or sets a value indicating whether [double out].</summary>
        /// <value><c>true</c> if [double out]; otherwise, <c>false</c>.</value>
        public bool DoubleOut { get; set; }

        /// <summary>Gets the selectable start points.</summary>
        /// <value>The selectable start points.</value>
        public IList<int> SelectableStartPoints => new List<int> { 301, 501, 701 };

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
        public string SelectedStartPoints { get; set; }

        #endregion Public Properties
    }
}