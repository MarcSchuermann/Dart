// -----------------------------------------------------------------------
// <copyright file="IUndoRedoable.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Schuermann.Darts.GameCore.UndoRedo.Interfaces
{
    /// <summary>The undo and redo interface.</summary>
    public interface IUndoRedoable
    {
        #region Public Methods

        /// <summary>Redoes this instance.</summary>
        void Redo();

        /// <summary>Undoes this instance.</summary>
        void Undo();

        #endregion Public Methods
    }
}