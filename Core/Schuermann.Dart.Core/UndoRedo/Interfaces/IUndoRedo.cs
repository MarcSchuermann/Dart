// -----------------------------------------------------------------------
// <copyright file="IUndoRedoAction.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Schuermann.Dart.Core.UndoRedo.Interfaces
{
   /// <summary>The undo and redo action.</summary>
   public interface IUndoRedo
   {
      #region Public Methods

      /// <summary>Redoes this instance.</summary>
      public void Redo();

      /// <summary>Undoes this instance.</summary>
      public void Undo();

      #endregion Public Methods
   }
}
