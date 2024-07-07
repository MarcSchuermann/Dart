//-----------------------------------------------------------------------
// <copyright file="PlayerView.xaml.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Schuermann.Dart.App.Game.UserInterface.Views
{
   /// <summary>The PlayerView.</summary>
   /// <seealso cref="UserControl" />
   /// <seealso cref="System.Windows.Markup.IComponentConnector" />
   [ExcludeFromCodeCoverage]
   public partial class PlayerView : UserControl
   {
      #region Constructors
      /// <summary>Initializes a new instance of the <see cref="PlayerView" /> class.</summary>
      public PlayerView()
      {
         InitializeComponent();
         MouseDown += PlayerView_MouseDown;
      }
      #endregion

      #region Private methods
      private void PlayerView_MouseDown(object sender, MouseButtonEventArgs e)
      {
         if (sender is PlayerView playerView)
         {
            Action focusAction = () => playerView.PlayerviewTextBox.Focus();
            Dispatcher.BeginInvoke(focusAction, DispatcherPriority.ApplicationIdle);
         }
      }


      private void PlayerviewTextBox_GotFocus(object sender, RoutedEventArgs e)
      {
         if (sender is TextBox textBox)
         {
            textBox.SelectAll();
         }
      }
      #endregion
   }
}
