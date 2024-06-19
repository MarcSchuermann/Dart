//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Windows;

namespace TestApp
{
   /// <summary>Interaction logic for MainWindow.xaml</summary>
   public partial class MainWindow : Window
   {
      #region Public Constructors

      public MainWindow()
      {
         InitializeComponent();
         myGrid.Children.Add(new Schuermann.Dart.Charts.Chart(new TestInstance(), new Schuermann.Dart.Core.EnvironmentProps.Properties("DARK.Orange", new System.Globalization.CultureInfo("en-US"))));
      }

      #endregion Public Constructors
   }
}