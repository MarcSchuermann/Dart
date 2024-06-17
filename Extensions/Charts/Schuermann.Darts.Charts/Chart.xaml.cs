//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;
using LiveChartsCore;
using Schuermann.Darts.GameCore.EnvironmentProps;
using Schuermann.Darts.GameCore.Game;

namespace Schuermann.Darts.Charts
{
   /// <summary>Interaction logic for Chart.xaml</summary>
   public partial class Chart : UserControl
   {
      #region Public Constructors

      /// <summary>Initializes a new instance of the <see cref="Chart" /> class.</summary>
      /// <param name="gameOptions">The game options.</param>
      public Chart(IGameInstance gameInstance, IProperties properties)
      {
         Thread.CurrentThread.CurrentCulture = properties.Culture;
         Thread.CurrentThread.CurrentUICulture = properties.Culture;

         InitializeComponent();

         DataContext = new ChartDataContext(gameInstance, properties.Theme);
      }

      #endregion Public Constructors
   }
}