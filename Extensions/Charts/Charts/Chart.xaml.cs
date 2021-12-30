//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using System.Threading;
using System.Windows.Controls;
using Environment;
using GameLogic.GameOptions;

namespace Charts
{
    /// <summary>Interaction logic for Chart.xaml</summary>
    public partial class Chart : UserControl
    {
        #region Public Constructors

        /// <summary>Initializes a new instance of the <see cref="Chart"/> class.</summary>
        /// <param name="gameOptions">The game options.</param>
        public Chart(IGameOptions gameOptions, IProperties properties)
        {
            Thread.CurrentThread.CurrentCulture = properties.Culture;
            Thread.CurrentThread.CurrentUICulture = properties.Culture;

            InitializeComponent();

            DataContext = new ChartDataContext(gameOptions, properties);
        }

        #endregion Public Constructors
    }
}