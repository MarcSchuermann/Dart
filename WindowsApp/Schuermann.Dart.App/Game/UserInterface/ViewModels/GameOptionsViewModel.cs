//-----------------------------------------------------------------------
// <copyright file="GameOptionsViewModel.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Drawing.Printing;
using Schuermann.Dart.App.Common.UserInterface.Helper;
using Schuermann.Dart.App.Common.UserInterface.ViewModels;
using Schuermann.Dart.App.Properties;

namespace Schuermann.Dart.App.Game.UserInterface.ViewModels
{
   /// <summary>
   /// The GameOptionsViewModel.
   /// </summary>
   public class GameOptionsViewModel : ViewModelBase
   {
      #region Fields

      private GameSettingsViewModel gameSettings;

      #endregion

      #region Constructors

      /// <summary>
      /// Initializes a new instance of the <see cref="GameOptionsViewModel"/> class.
      /// </summary>
      public GameOptionsViewModel()
      {
         GameSettings = new GameSettingsViewModel();

         GameSettings.PropertyChanged += GameSettingsViewModel_PropertyChanged;

         SetupPlayerlist(Convert.ToInt32(GameSettings.SelectedPlayerCount));
      }

      #endregion

      #region Public properties

      /// <summary>
      /// Gets or sets the player list.
      /// </summary>
      /// <value>The player list.</value>
      public ItemsChangeObservableCollection<PlayerViewModel> Playerlist { get; set; }

      #endregion

      #region Private methods

      /// <summary>
      /// Handles the PropertyChanged event of the GameSettingsViewModel control.
      /// </summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
      private void GameSettingsViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
      {
         if (sender is GameSettingsViewModel gameSettingsViewModel)
         {
            var playerCount = Convert.ToInt32(gameSettingsViewModel.SelectedPlayerCount);
            SetupPlayerlist(playerCount);
         }

         RaisePropertyChanged(nameof(Playerlist));
      }

      /// <summary>
      /// Creates the player list.
      /// </summary>
      /// <param name="playerCount">The player count.</param>
      /// <returns>The Player list.</returns>
      private ItemsChangeObservableCollection<PlayerViewModel> SetupPlayerlist(int playerCount)
      {
         Playerlist ??= new ItemsChangeObservableCollection<PlayerViewModel>();

         while (Playerlist.Count < playerCount)
            Playerlist.Add(new PlayerViewModel($"Player {Playerlist.Count + 1}"));

         while (Playerlist.Count > playerCount)
            Playerlist.RemoveAt(playerCount);

         return Playerlist;
      }

      #endregion

      #region Public Properties

      /// <summary>
      /// Gets or sets the game settings.
      /// </summary>
      /// <value>The game settings.</value>
      public GameSettingsViewModel GameSettings
      {
         get => gameSettings;

         set
         {
            if (gameSettings == value)
               return;

            gameSettings = value;
            RaisePropertyChanged(nameof(GameSettings));
         }
      }

      /// <summary>
      /// Gets the label.
      /// </summary>
      /// <value>The label.</value>
      public string Label => Resources.Throwgame;

      #endregion Public Properties
   }
}
