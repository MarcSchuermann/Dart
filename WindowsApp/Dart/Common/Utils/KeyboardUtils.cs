// -----------------------------------------------------------------------
// <copyright file="KeyboardUtils.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows.Input;

namespace Dart.Common.Utils
{
   internal class KeyboardUtils
   {
      #region Public Methods

      /// <summary>Determines whether [is control pressed].</summary>
      /// <returns><c>true</c> if [is control pressed]; otherwise, <c>false</c>.</returns>
      public static bool IsCtrlPressed()
      {
         return (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl));
      }

      public static bool IsNumberPressed()
      {
         return Keyboard.IsKeyDown(Key.D0) ||
            Keyboard.IsKeyDown(Key.D1) ||
            Keyboard.IsKeyDown(Key.D2) ||
            Keyboard.IsKeyDown(Key.D3) ||
            Keyboard.IsKeyDown(Key.D4) ||
            Keyboard.IsKeyDown(Key.D5) ||
            Keyboard.IsKeyDown(Key.D6) ||
            Keyboard.IsKeyDown(Key.D7) ||
            Keyboard.IsKeyDown(Key.D8) ||
            Keyboard.IsKeyDown(Key.D9);
      }

      /// <summary>Determines whether [is number pressed] [the specified number].</summary>
      /// <param name="number">The number.</param>
      /// <returns>
      ///    <c>true</c> if [is number pressed] [the specified number]; otherwise, <c>false</c>.
      /// </returns>
      public static bool IsNumberPressed(int number)
      {
         if (number == 0)
            return Keyboard.IsKeyDown(Key.D0);

         if (number == 1)
            return Keyboard.IsKeyDown(Key.D1);

         if (number == 2)
            return Keyboard.IsKeyDown(Key.D2);

         if (number == 3)
            return Keyboard.IsKeyDown(Key.D3);

         if (number == 4)
            return Keyboard.IsKeyDown(Key.D4);

         if (number == 5)
            return Keyboard.IsKeyDown(Key.D5);

         if (number == 6)
            return Keyboard.IsKeyDown(Key.D6);

         if (number == 7)
            return Keyboard.IsKeyDown(Key.D7);

         if (number == 8)
            return Keyboard.IsKeyDown(Key.D8);

         if (number == 9)
            return Keyboard.IsKeyDown(Key.D9);

         return false;
      }

      /// <summary>Determines whether [is shift pressed].</summary>
      /// <returns><c>true</c> if [is shift pressed]; otherwise, <c>false</c>.</returns>
      public static bool IsShiftPressed()
      {
         return Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift);
      }

      #endregion Public Methods
   }
}