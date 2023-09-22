// -----------------------------------------------------------------------
// <copyright file="PlugInsDialog.xaml.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Windows;
using MahApps.Metro.Controls;
using Schuermann.Darts.Environment.Extensibility;

namespace Dart.Common.UserInterface.PlugInsDialog
{
   /// <summary>Interaction logic for PlugInsDialog.xaml</summary>
   public partial class PlugInsDialog : MetroWindow
   {
      #region Public Constructors

      /// <summary>Initializes a new instance of the <see cref="PlugInsDialog" /> class.</summary>
      /// <param name="plugIns">The plug ins.</param>
      public PlugInsDialog(IEnumerable<IPlugIn> plugIns)
      {
         InitializeComponent();

         foreach (var plugIn in plugIns)
         {
            PlugIns.Items.Add($"Strg + e + {plugIns.ToList().IndexOf(plugIn)} {plugIn.Name}");
         }
      }

      #endregion Public Constructors

      #region Private Methods

      private void Ok_Click(object sender, RoutedEventArgs e)
      {
         Close();
      }

      #endregion Private Methods
   }
}