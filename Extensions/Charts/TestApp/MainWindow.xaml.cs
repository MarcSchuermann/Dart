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
            myGrid.Children.Add(new Schuermann.Darts.Charts.Chart(new TestData(), new Schuermann.Darts.Environment.EnvironmentProps.Properties("DARK.Orange", new System.Globalization.CultureInfo("en-US")), null));
        }

        #endregion Public Constructors
    }
}