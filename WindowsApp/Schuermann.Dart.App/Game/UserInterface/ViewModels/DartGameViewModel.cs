// -----------------------------------------------------------------------
// <copyright file="DartGameViewModel.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Input;
using Schuermann.Dart.App.Common.Commands;
using Schuermann.Dart.App.Common.UserInterface.Interfaces;
using Schuermann.Dart.App.Common.UserInterface.ViewModels;
using Schuermann.Dart.App.Game.Interfaces;
using Schuermann.Dart.Core.Game;
using Schuermann.Dart.Core.Thrown;

namespace Schuermann.Dart.App.Game.UserInterface.ViewModels
{
   /// <summary>The DartGameViewModel.</summary>
   /// <seealso cref="ViewModelBase" />
   public class DartGameViewModel : ViewModelBase, IGameProvider
   {
      #region Public Constructors

      public DartGameViewModel()
      {

      }

      /// <summary>
      ///    Initializes a new instance of the <see cref="DartGameViewModel" /> class.
      /// </summary>
      /// <param name="owner">The owner.</param>
      public DartGameViewModel(IViewModelBase owner)
      {
         MainWindowViewModel = owner as IMainWindowViewModel;

         Game = new GameProcedure(MainWindowViewModel.ConfiguredGameOptions);

         SetPlayers();
      }

      #endregion Public Constructors

      #region Public Properties

      /// <summary>Gets the label.</summary>
      /// <value>The label.</value>
      public static string Label => Properties.Resources.Throwgame;

      /// <summary>Gets or sets the current points under mouse.</summary>
      /// <value>The current points under mouse.</value>
      public IDartThrow CurrentPointsUnderMouse { get; set; }

      /// <summary>Gets the dart thrown.</summary>
      /// <value>The dart thrown.</value>
      public ICommand DartThrown => new RelayCommand(x => Thrown());

      /// <summary>Gets the game.</summary>
      /// <value>The game.</value>
      [Export(typeof(IGameProcedure))]
      public IGameProcedure Game { get; }

      /// <summary>Gets or sets the main window view model.</summary>
      /// <value>The main window view model.</value>
      public IMainWindowViewModel MainWindowViewModel { get; set; }

      /// <summary>Gets the players.</summary>
      /// <value>The players.</value>
      public IEnumerable<IPlayerViewModel> Players { get; private set; }

      #endregion Public Properties

      #region Public Methods

      /// <summary>Thrown this instance.</summary>
      public void Thrown()
      {
         //LoggerUtils.GetLogger<DartGameViewModel>().LogInformation($"{Game.Instance.CurrentPlayer.Name} throws {CurrentPointsUnderMouse}");

         Game.PlayerThrown(CurrentPointsUnderMouse);

         UpdatePlayers();
      }

      /// <summary>Updates this instance.</summary>
      public void UpdatePlayers()
      {
         foreach (var player in Players)
         {
            var org = Game.Instance.GameOptions.PlayerList.First(x => x.Name.Equals(player.Name));
            if (org.CurrentScore != player.CurrentScore)
               player.CurrentScore = org.CurrentScore;
         }
      }

      #endregion Public Methods

      #region Private Methods

      /// <summary>Sets the players.</summary>
      private void SetPlayers()
      {
         var players = new ObservableCollection<IPlayerViewModel>();
         foreach (var player in Game.Instance.GameOptions.PlayerList)
         {
            players.Add(new PlayerViewModel(player));
         }
         Players = players;
      }

      #endregion Private Methods
   }
}