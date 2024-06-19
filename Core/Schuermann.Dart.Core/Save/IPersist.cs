// -----------------------------------------------------------------------
// <copyright file="IPersist.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.IO;
using Schuermann.Dart.Core.Game;

namespace Schuermann.Darts.GameCore.Save
{
    /// <summary>Saves or loads the game.</summary>
    public interface IPersist
    {
        #region Public Methods

        /// <summary>Loads the specified stream.</summary>
        /// <param name="stream">The stream.</param>
        IGameInstance Load(Stream stream);

        /// <summary>Saves the specified instance.</summary>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        Stream Save(IGameInstance instance);

        #endregion Public Methods
    }
}