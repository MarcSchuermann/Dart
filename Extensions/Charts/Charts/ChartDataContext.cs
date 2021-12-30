//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Environment;
using GameLogic.DartThrow;
using GameLogic.GameOptions;
using GameLogic.Player;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace Charts
{
    /// <summary>The context of the charts.</summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged"/>
    public class ChartDataContext : INotifyPropertyChanged
    {
        #region Private Fields

        private IPlayer player;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>Initializes a new instance of the <see cref="ChartDataContext"/> class.</summary>
        /// <param name="gameOptions">The game options.</param>
        public ChartDataContext(IGameOptions gameOptions, IProperties properties)
        {
            GameOptions = gameOptions;
            Player = GameOptions.PlayerList?.FirstOrDefault();
            Properties = properties;
        }

        #endregion Public Constructors

        #region Public Events

        /// <summary>Occurs when a property value changes.</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Public Events

        #region Public Properties

        /// <summary>Gets or sets the game options.</summary>
        /// <value>The game options.</value>
        public IGameOptions GameOptions { get; }

        /// <summary>Gets my styles.</summary>
        /// <value>My styles.</value>
        public Styles MyStyles => new Styles(Properties.Theme);

        /// <summary>Gets or sets the player.</summary>
        /// <value>The player.</value>
        public IPlayer Player
        {
            get
            {
                return player;
            }
            set
            {
                player = value;
                OnPropertyChanged(nameof(Player));
                OnPropertyChanged(nameof(SingleFieldSeriesCollection));
            }
        }

        /// <summary>Gets the point history series collection.</summary>
        /// <value>The point history series collection.</value>
        public SeriesCollection PointHistorySeriesCollection => GetPointHistorySeries();

        /// <summary>Gets the properties.</summary>
        /// <value>The properties.</value>
        public IProperties Properties { get; }

        /// <summary>Gets the single field series collection.</summary>
        /// <value>The single field series collection.</value>
        public SeriesCollection SingleFieldSeriesCollection => GetSingleFieldSeries();

        /// <summary>Gets the throw history series collection.</summary>
        /// <value>The throw history series collection.</value>
        public SeriesCollection ThrowHistorySeriesCollection => GetThrowHistorySeries();

        #endregion Public Properties

        #region Private Methods

        private IDictionary<IDartThrow, int> CalcuateFieldCount(IList<IDartThrow> throwHistory)
        {
            var retVal = new Dictionary<IDartThrow, int>();

            foreach (var thrownDart in throwHistory)
            {
                if (!retVal.Keys.Contains(thrownDart))
                    retVal.Add(thrownDart, 1);
                else
                {
                    retVal[thrownDart] += 1;
                }
            }

            return retVal;
        }

        private IChartValues CalculatePointValues(int startPoints, IList<int> throwHistory)
        {
            var retVal = new List<int>
            {
                startPoints
            };
            var currentPoints = startPoints;

            foreach (var thrown in throwHistory)
            {
                retVal.Add(currentPoints -= thrown);
            }

            return new ChartValues<int>(retVal);
        }

        private SeriesCollection GetPointHistorySeries()
        {
            var retVal = new SeriesCollection();

            if (GameOptions == null)
                return retVal;

            foreach (var player in GameOptions.PlayerList)
            {
                retVal.Add(new LineSeries
                {
                    Title = player.Name,
                    Values = CalculatePointValues(GameOptions.StartPoints, GetPointValues(player.ThrowHistory)),
                    PointGeometry = DefaultGeometries.Diamond
                });
            }

            return retVal;
        }

        private IList<int> GetPointValues(IList<IDartThrow> dartThrows)
        {
            return dartThrows.Select(x => x.Points).ToList();
        }

        private SeriesCollection GetSingleFieldSeries()
        {
            var retVal = new SeriesCollection();

            if (GameOptions == null)
                return retVal;

            if (Player == null)
                Player = GameOptions.PlayerList.First();

            IDictionary<IDartThrow, int> fieldCount = CalcuateFieldCount(Player.ThrowHistory);

            foreach (var field in fieldCount)
            {
                retVal.Add(new PieSeries
                {
                    Title = $"{field.Key.DartBoardQuantifier} {field.Key.DartBoardField}",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(field.Value) },
                    DataLabels = true
                });
            }

            return retVal;
        }

        private SeriesCollection GetThrowHistorySeries()
        {
            var retVal = new SeriesCollection();

            if (GameOptions == null)
                return retVal;

            foreach (var player in GameOptions.PlayerList)
            {
                retVal.Add(new ColumnSeries
                {
                    Title = player.Name,
                    Values = new ChartValues<int>(GetPointValues(player.ThrowHistory)),
                    PointGeometry = DefaultGeometries.Diamond,
                    MaxColumnWidth = double.PositiveInfinity
                });
            }

            return retVal;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion Private Methods
    }
}