// -----------------------------------------------------------------------
// <copyright file="PlayerlistViewModel.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.ComponentModel;
using Schuermann.Dart.App.Common.UserInterface.Helper;
using Schuermann.Dart.App.Common.UserInterface.ViewModels;

namespace Schuermann.Dart.App.Game.UserInterface.ViewModels
{
   /// <summary>The Player list ViewModel.</summary>
   public class PlayerlistViewModel : ViewModelBase
   {
      #region Public Constructors

      /// <summary>Initializes a new instance of the <see cref="PlayerlistViewModel"/> class.</summary>
      /// <param name="gameSettingsViewModel">The game settings view model.</param>
      public PlayerlistViewModel(GameSettingsViewModel gameSettingsViewModel)
      {
         gameSettingsViewModel.PropertyChanged += GameSettingsViewModel_PropertyChanged;

         SetupPlayerlist(Convert.ToInt32(gameSettingsViewModel.SelectedPlayerCount));
      }

      #endregion Public Constructors

      #region Public Properties

      /// <summary>Gets or sets the player list.</summary>
      /// <value>The player list.</value>
      public ItemsChangeObservableCollection<PlayerViewModel> Playerlist { get; set; }

      #endregion Public Properties

      #region Private Methods

      /// <summary>Handles the PropertyChanged event of the GameSettingsViewModel control.</summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
      private void GameSettingsViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
      {
         SetupPlayerlist(Convert.ToInt32((sender as GameSettingsViewModel).SelectedPlayerCount));
         RaisePropertyChanged(nameof(Playerlist));
      }

      /// <summary>Creates the player list.</summary>
      /// <param name="playerCount">The player count.</param>
      /// <returns>The Player list.</returns>
      private ItemsChangeObservableCollection<PlayerViewModel> SetupPlayerlist(int playerCount)
      {
         if (Playerlist == null)
            Playerlist = new ItemsChangeObservableCollection<PlayerViewModel>();

         while (Playerlist.Count < playerCount)
            Playerlist.Add(new PlayerViewModel($"Player {Playerlist.Count + 1}"));

         while (Playerlist.Count > playerCount)
            Playerlist.RemoveAt(playerCount);

         return Playerlist;
      }

      #endregion Private Methods
   }
}