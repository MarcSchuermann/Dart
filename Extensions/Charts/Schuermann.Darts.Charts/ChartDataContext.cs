//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.Drawing;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Drawing;
using LiveChartsCore.SkiaSharpView.Painting;
using Schuermann.Darts.Charts.Themes;
using Schuermann.Darts.Charts.Utils;
using Schuermann.Darts.GameCore.Game;
using Schuermann.Darts.GameCore.Themes;
using Schuermann.Darts.GameCore.Thrown;

namespace Schuermann.Darts.Charts
{
   /// <summary>The context of the charts.</summary>
   /// <seealso cref="INotifyPropertyChanged" />
   public class ChartDataContext : INotifyPropertyChanged
   {
      #region Private Fields

      private IPlayer player;

      private ITheme theme;

      #endregion Private Fields

      #region Public Constructors

      /// <summary>
      ///    Initializes a new instance of the <see cref="ChartDataContext" /> class.
      /// </summary>
      /// <param name="gameOptions">The game options.</param>
      public ChartDataContext(IGameInstance gameInstance, ITheme theme)
      {
         GameInstance = gameInstance;
         this.theme = theme;

         Player = gameInstance?.CurrentPlayer;
         if (gameInstance != null)
            gameInstance.StandingsChanged += GameProcedure_StandingsChanged;
      }

      #endregion Public Constructors

      #region Public Events

      /// <summary>Occurs when a property value changes.</summary>
      public event PropertyChangedEventHandler PropertyChanged;

      #endregion Public Events

      #region Public Properties

      /// <summary>Gets the game instance.</summary>
      /// <value>The game instance.</value>
      public IGameInstance GameInstance { get; }

      /// <summary>Gets the legend text paint.</summary>
      /// <value>The legend text paint.</value>
      public IPaint<SkiaSharpDrawingContext> LegendTextPaint
      {
         get
         {
            if (theme.BaseTheme == BaseTheme.dark)
               return new SolidColorPaint(SkiaSharp.SKColor.Parse("#FFF"));

            return new SolidColorPaint(SkiaSharp.SKColor.Parse("#000"));
         }
      }

      /// <summary>Gets my styles.</summary>
      /// <value>My styles.</value>
      public Styles MyStyles => new Styles(theme);

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
            OnPropertyChanged(nameof(PointHistorySeriesCollection));
            OnPropertyChanged(nameof(SingleFieldSeriesCollection));
            OnPropertyChanged(nameof(ThrowHistorySeriesCollection));
         }
      }

      /// <summary>Gets the point history series collection.</summary>
      /// <value>The point history series collection.</value>
      public ISeries[] PointHistorySeriesCollection => GetPointHistorySeries();

      /// <summary>Gets the single field series collection.</summary>
      /// <value>The single field series collection.</value>
      public ISeries[] SingleFieldSeriesCollection => GetSingleFieldSeries();

      /// <summary>Gets the throw history series collection.</summary>
      /// <value>The throw history series collection.</value>
      public ISeries[] ThrowHistorySeriesCollection => GetThrowHistorySeries();

      /// <summary>Gets the x axis0.</summary>
      /// <value>The x axis0.</value>
      public IEnumerable<ICartesianAxis> XAxisPointHistory
      {
         get
         {
            yield return new Axis() { MinStep = 1, Name = Resource.Throw };
         }
      }

      /// <summary>Gets the x axis.</summary>
      /// <value>The x axis.</value>
      public IEnumerable<ICartesianAxis> XAxisThrowHistory
      {
         get
         {
            yield return new Axis() { MinStep = 1, Name = Resource.Throw, Labels = CreateThrowHistoryXLables() };
         }
      }

      /// <summary>Gets the y axis.</summary>
      /// <value>The y axis.</value>
      public IEnumerable<ICartesianAxis> YAxisPointHistory
      {
         get
         {
            yield return new Axis() { Name = Resource.Points };
         }
      }

      /// <summary>Gets the y axis throw history.</summary>
      /// <value>The y axis throw history.</value>
      public IEnumerable<ICartesianAxis> YAxisThrowHistory
      {
         get
         {
            yield return new Axis() { Name = Resource.Points, MinLimit = 0 };
         }
      }

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

         return new Dictionary<IDartThrow, int>(retVal.OrderBy(x => x.Key.DartBoardField).ThenBy(y => y.Key.DartBoardQuantifier));
      }

      private IEnumerable<int> CalculatePointValues(int startPoints, IList<int> throwHistory)
      {
         var retVal = new List<int>
            {
                startPoints
            };
         var currentPoints = startPoints;

         foreach (var thrown in throwHistory)
         {
            if (currentPoints - thrown < 0)
               retVal.Add(currentPoints);
            else
               retVal.Add(currentPoints -= thrown);
         }

         return new List<int>(retVal);
      }

      private IList<string> CreateThrowHistoryXLables()
      {
         if (GameInstance?.GameOptions?.PlayerList == null)
            return Array.Empty<string>();

         var maxThrows = GameInstance.GameOptions.PlayerList.Max(x => x.ThrowHistory.Count);
         var retVal = new List<string>();

         for (int i = 1; i <= maxThrows; i++)
         {
            retVal.Add(i.ToString());
         }

         return retVal;
      }

      private void GameProcedure_StandingsChanged(object? sender, EventArgs e)
      {
         if (sender is IGameProcedure game)
         {
            Player = game.Instance.CurrentPlayer;
         }
      }

      private ISeries[] GetPointHistorySeries()
      {
         var retVal = new List<LineSeries<int>>();

         if (GameInstance?.GameOptions == null)
            return retVal.ToArray();

         foreach (var player in GameInstance.GameOptions.PlayerList)
         {
            retVal.Add(new LineSeries<int>()
            {
               Name = player.Name,
               Values = CalculatePointValues(GameInstance.GameOptions.StartPoints, GetPointValues(player.ThrowHistory)),
               Stroke = ColorUtils.GetFillFromIndex(GameInstance.GameOptions.PlayerList.ToList().IndexOf(player)),
               GeometryStroke = ColorUtils.GetFillFromIndex(GameInstance.GameOptions.PlayerList.ToList().IndexOf(player)),
               GeometryFill = ColorUtils.GetLightFillFromIndex(GameInstance.GameOptions.PlayerList.ToList().IndexOf(player)),
               Fill = ColorUtils.GetLightFillFromIndex(GameInstance.GameOptions.PlayerList.ToList().IndexOf(player)),
            });
         }

         return retVal.ToArray();
      }

      private IList<int> GetPointValues(IList<IDartThrow> dartThrows)
      {
         return dartThrows.Select(x => x.Points).ToList();
      }

      private ISeries[] GetSingleFieldSeries()
      {
         var retVal = new List<PieSeries<int>>();

         if (GameInstance?.GameOptions == null)
            return retVal.ToArray();

         if (Player == null)
            Player = GameInstance.GameOptions.PlayerList.First();

         var fieldCount = CalcuateFieldCount(Player.ThrowHistory);

         foreach (var field in fieldCount)
         {
            retVal.Add(new PieSeries<int>
            {
               Name = field.Key.DartBoardField == DartBoardField.Zero ? field.Key.DartBoardField.ToString() : $"{field.Key.DartBoardQuantifier} {field.Key.DartBoardField}",
               Values = new List<int> { field.Value },
               MaxRadialColumnWidth = 50,
               Fill = ColorUtils.GetFillFromField(field.Key),
            });
         }

         return retVal.ToArray();
      }

      private ISeries[] GetThrowHistorySeries()
      {
         var retVal = new List<ColumnSeries<int>>();

         if (GameInstance?.GameOptions == null)
            return retVal.ToArray();

         foreach (var player in GameInstance.GameOptions.PlayerList)
         {
            retVal.Add(new ColumnSeries<int>
            {
               Name = player.Name,
               Values = GetPointValues(player.ThrowHistory),
               Stroke = ColorUtils.GetFillFromIndex(GameInstance.GameOptions.PlayerList.ToList().IndexOf(player)),
               Fill = ColorUtils.GetMiddleFillFromIndex(GameInstance.GameOptions.PlayerList.ToList().IndexOf(player)),
               GroupPadding = 20,
            });
         }

         return retVal.ToArray();
      }

      private void OnPropertyChanged(string propertyName)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }

      #endregion Private Methods
   }
}