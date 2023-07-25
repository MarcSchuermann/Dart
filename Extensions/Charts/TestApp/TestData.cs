//// --------------------------------------------------------------------------------------------------------------------
//// <copyright>Marc Schürmann</copyright>
//// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Schuermann.Darts.GameCore.Game;
using Schuermann.Darts.GameCore.Thrown;

namespace TestApp
{
    public class MyPlayer : IPlayer
    {
        #region Public Properties

        public uint CurrentScore { get; set; }
        public int DartCountThisRound { get; set; }
        public Guid Id => new();
        public string Name { get; set; }
        public int PointsThisRound { get; set; }
        public int Round { get; set; }
        public uint StartPoints => 301;
        public IList<IDartThrow> ThrowHistory { get; set; }

        #endregion Public Properties

        #region Public Methods

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public void Thrown(IDartThrow dartThrow)
        {
            throw new NotImplementedException();
        }

        public override string ToString() => Name;

        #endregion Public Methods
    }

    public class TestData : IGameOptions
    {
        #region Public Properties

        public bool AllPlayTillZero { get; set; }
        public bool DoubleIn { get; set; }
        public bool DoubleOut { get; set; }
        public IEnumerable<IPlayer> PlayerList
        { get => CreatePlayerList(); set { } }

        public int StartPoints
        { get => 301; set { } }

        #endregion Public Properties

        #region Private Methods

        private IEnumerable<IDartThrow> CreateHistory1()
        {
            yield return new DartThrow(DartBoardField.Five, DartBoardQuantifier.Single);
            yield return new DartThrow(DartBoardField.Eighteen, DartBoardQuantifier.Double);
            yield return new DartThrow(DartBoardField.Nine, DartBoardQuantifier.Triple);
            yield return new DartThrow(DartBoardField.Two, DartBoardQuantifier.Single);
            yield return new DartThrow(DartBoardField.Three, DartBoardQuantifier.Double);
        }

        private IEnumerable<IDartThrow> CreateHistory2()
        {
            yield return new DartThrow(DartBoardField.Three, DartBoardQuantifier.Single);
            yield return new DartThrow(DartBoardField.Twelve, DartBoardQuantifier.Single);
            yield return new DartThrow(DartBoardField.Zero, DartBoardQuantifier.Single);
            yield return new DartThrow(DartBoardField.Two, DartBoardQuantifier.Double);
            yield return new DartThrow(DartBoardField.Four, DartBoardQuantifier.Single);
        }

        private IEnumerable<IDartThrow> CreateHistory3()
        {
            yield return new DartThrow(DartBoardField.Eighteen, DartBoardQuantifier.Single);
            yield return new DartThrow(DartBoardField.Bullseye, DartBoardQuantifier.Triple);
            yield return new DartThrow(DartBoardField.Eleven, DartBoardQuantifier.Single);
            yield return new DartThrow(DartBoardField.Fourteen, DartBoardQuantifier.Single);
            yield return new DartThrow(DartBoardField.Two, DartBoardQuantifier.Triple);
        }

        private IEnumerable<IDartThrow> CreateHistory4()
        {
            yield return new DartThrow(DartBoardField.Three, DartBoardQuantifier.Double);
            yield return new DartThrow(DartBoardField.Ten, DartBoardQuantifier.Triple);
            yield return new DartThrow(DartBoardField.Seven, DartBoardQuantifier.Double);
            yield return new DartThrow(DartBoardField.One, DartBoardQuantifier.Triple);
            yield return new DartThrow(DartBoardField.Seventeen, DartBoardQuantifier.Triple);
        }

        private IEnumerable<IDartThrow> CreateHistory5()
        {
            yield return new DartThrow(DartBoardField.Three, DartBoardQuantifier.Double);
            yield return new DartThrow(DartBoardField.Ten, DartBoardQuantifier.Single);
            yield return new DartThrow(DartBoardField.One, DartBoardQuantifier.Single);
            yield return new DartThrow(DartBoardField.Zero, DartBoardQuantifier.Triple);
            yield return new DartThrow(DartBoardField.Five, DartBoardQuantifier.Triple);
            yield return new DartThrow(DartBoardField.Ten, DartBoardQuantifier.Single);
        }

        private IEnumerable<IDartThrow> CreateHistory6()
        {
            yield return new DartThrow(DartBoardField.Three, DartBoardQuantifier.Double);
            yield return new DartThrow(DartBoardField.Three, DartBoardQuantifier.Single);
            yield return new DartThrow(DartBoardField.Three, DartBoardQuantifier.Single);
            yield return new DartThrow(DartBoardField.Three, DartBoardQuantifier.Double);
            yield return new DartThrow(DartBoardField.Five, DartBoardQuantifier.Triple);
            yield return new DartThrow(DartBoardField.Ten, DartBoardQuantifier.Single);
        }

        private IEnumerable<IDartThrow> CreateHistory7()
        {
            yield return new DartThrow(DartBoardField.Bullseye, DartBoardQuantifier.Double);
            yield return new DartThrow(DartBoardField.Bullseye, DartBoardQuantifier.Double);
            yield return new DartThrow(DartBoardField.Bullseye, DartBoardQuantifier.Double);
            yield return new DartThrow(DartBoardField.Bullseye, DartBoardQuantifier.Double);
            yield return new DartThrow(DartBoardField.Bullseye, DartBoardQuantifier.Double);
            yield return new DartThrow(DartBoardField.Bullseye, DartBoardQuantifier.Double);
            yield return new DartThrow(DartBoardField.Bullseye, DartBoardQuantifier.Double);
        }

        private IEnumerable<IDartThrow> CreateHistory8()
        {
            yield return new DartThrow(DartBoardField.One, DartBoardQuantifier.Single);
            yield return new DartThrow(DartBoardField.Two, DartBoardQuantifier.Single);
            yield return new DartThrow(DartBoardField.Three, DartBoardQuantifier.Single);
            yield return new DartThrow(DartBoardField.Four, DartBoardQuantifier.Single);
            yield return new DartThrow(DartBoardField.Five, DartBoardQuantifier.Single);
            yield return new DartThrow(DartBoardField.Six, DartBoardQuantifier.Single);
            yield return new DartThrow(DartBoardField.Seven, DartBoardQuantifier.Single);
        }

        private IList<IPlayer> CreatePlayerList()
        {
            var retVal = new List<IPlayer>();

            retVal.Add(new MyPlayer() { Name = "Homer", ThrowHistory = CreateHistory1().ToList() });
            retVal.Add(new MyPlayer() { Name = "Marge", ThrowHistory = CreateHistory2().ToList() });
            retVal.Add(new MyPlayer() { Name = "Bart", ThrowHistory = CreateHistory3().ToList() });
            retVal.Add(new MyPlayer() { Name = "Lisa", ThrowHistory = CreateHistory4().ToList() });
            retVal.Add(new MyPlayer() { Name = "Maggy", ThrowHistory = CreateHistory5().ToList() });
            retVal.Add(new MyPlayer() { Name = "Snowball II", ThrowHistory = CreateHistory6().ToList() });
            retVal.Add(new MyPlayer() { Name = "Moe", ThrowHistory = CreateHistory7().ToList() });
            retVal.Add(new MyPlayer() { Name = "Mr. Burns", ThrowHistory = CreateHistory8().ToList() });

            return retVal;
        }

        #endregion Private Methods
    }
}