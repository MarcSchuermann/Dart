// -----------------------------------------------------------------------
// <copyright file="PlayerView.xaml.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using System.Windows.Controls;

namespace Schuermann.Dart.App.Game.UserInterface.Views
{
   /// <summary>The PlayerView.</summary>
   /// <seealso cref="UserControl" />
   /// <seealso cref="System.Windows.Markup.IComponentConnector" />
   [ExcludeFromCodeCoverage]
   public partial class PlayerView : UserControl
   {
      #region Public Constructors

      /// <summary>Initializes a new instance of the <see cref="PlayerView" /> class.</summary>
      public PlayerView()
      {
         InitializeComponent();
      }

      #endregion Public Constructors
   }
}