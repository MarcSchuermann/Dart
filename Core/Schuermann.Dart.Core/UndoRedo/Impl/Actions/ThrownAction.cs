// -----------------------------------------------------------------------
// <copyright file="ThrownAction.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using Schuermann.Dart.Core.Game;
using Schuermann.Dart.Core.Thrown;
using Schuermann.Dart.Core.UndoRedo.Interfaces;

namespace Schuermann.Darts.GameCore.UndoRedo.Impl.Actions
{
   internal class ThrownAction : IUndoRedo
    {
        #region Private Fields

        private readonly IPlayer player;
        private readonly IDartThrow thrownPoints;

        #endregion Private Fields

        #region Public Constructors

        public ThrownAction(IPlayer player, IDartThrow thrownPoints)
        {
            this.player = player;
            this.thrownPoints = thrownPoints;
        }

        #endregion Public Constructors

        #region Public Methods

        public void Redo()
        {
            player.ThrowHistory.Add(thrownPoints);
        }

        public void Undo()
        {
            player.ThrowHistory.RemoveAt(player.ThrowHistory.Count - 1);
        }

        #endregion Public Methods
    }
}