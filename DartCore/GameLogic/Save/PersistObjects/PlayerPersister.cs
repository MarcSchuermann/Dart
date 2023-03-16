// -----------------------------------------------------------------------
// <copyright file="PlayerPersister.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using Schuermann.Darts.GameCore.Thrown;

namespace Schuermann.Darts.GameCore.Save.PersistObjects
{
    /// <summary>Persist the plyer istance.</summary>
    internal class PlayerPersister
    {
        #region Public Properties

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>Gets or sets the start points.</summary>
        /// <value>The start points.</value>
        public uint StartPoints { get; set; }

        /// <summary>Gets or sets the throw history.</summary>
        /// <value>The throw history.</value>
        public IList<IDartThrow> ThrowHistory { get; set; }

        #endregion Public Properties
    }
}