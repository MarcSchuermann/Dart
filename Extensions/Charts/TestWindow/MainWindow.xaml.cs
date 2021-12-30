//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using System.Windows;

namespace TestWindow
{
    /// <summary>Interaction logic for MainWindow.xaml</summary>
    public partial class MainWindow : Window
    {
        #region Public Constructors

        public MainWindow()
        {
            InitializeComponent();
            myGrid.Children.Add(new Charts.Chart(new TestData(), new Environment.Properties("DARK.Orange", new System.Globalization.CultureInfo("en-US"))));
        }

        #endregion Public Constructors
    }
}