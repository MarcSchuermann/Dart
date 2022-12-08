using System.Collections.Generic;
using System.IO;
using Dart.Save;
using Dart.Save.Xml;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schuermann.Darts.GameCore.Game;

namespace UnitTests.Save
{
    [TestClass]
    public class SaveTests
    {
        #region Public Methods

        [TestMethod]
        public void JsonSaver()
        {
            var tmp = Path.GetTempFileName();
            var gameOptions = new GameOptions(new List<IPlayer> { new Player() { Name = "Hansi" }, new Player() { Name = "Waldi" } })
            {
                DoubleOut = true,
                AllPlayTillZero = true,
                DoubleIn = false,
                StartPoints = 666,
            };
            var myGame = new GameProcedure(gameOptions);

            var stream = GameSaver.AsJson(myGame);
            stream.Position = 0;

            using var fs = new FileStream(tmp,FileMode.OpenOrCreate, FileAccess.ReadWrite);
            
            stream.CopyTo(fs);
            fs.Flush();
            fs.Close();
        }

        #endregion Public Methods
    }
}