﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MaximumChunkCountTerminationCondition.cs" company="Nick Pruehs, Denis Vaz Alves">
//   Copyright 2011-2016 Nick Pruehs, Denis Vaz Alves.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ByChance.Configuration.Parameters
{
    using ByChance.Levels3D;

    /// <summary>
    ///   Finishes level generation after a certain amount of chunks has been added.
    /// </summary>
    public class MaximumChunkCountTerminationCondition : ITerminationCondition
    {
        #region Properties

        /// <summary>
        ///   Maximum number of level chunks.
        /// </summary>
        public int MaximumChunkCount { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///   Returns <c>true</c>, if the level generation should stop, and
        ///   <c>false</c>, otherwise.
        /// </summary>
        /// <param name="level">Current generated level.</param>
        /// <returns>
        ///   <c>true</c>, if the level generation should stop, and
        ///   <c>false</c>, otherwise.
        /// </returns>
        public bool ConditionIsMet(object level)
        {
            var level3D = (Level3D)level;
            return level3D.Count >= this.MaximumChunkCount;
        }

        #endregion
    }
}