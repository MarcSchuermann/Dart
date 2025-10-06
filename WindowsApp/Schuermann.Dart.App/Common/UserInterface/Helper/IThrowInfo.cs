using Schuermann.Darts.GameCore.Thrown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dart.Common.UserInterface.Helper
{
   public interface IThrowInfo
   {
      double GetCurrentAngle { get; }

      double GetCurrentDistanceBetweenMouseAndCenter { get; }

      Point GetCurrentMousePosition { get; }

      Point GetDartBoardCenter { get; }

      IDartThrow GetPointsAtMousePosition { get; }

      bool IsDouble { get; }

      bool IsSingle { get; }

      bool IsTriple
      {
         get;
      }

   }
}
