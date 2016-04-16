﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AlignAdjacentContextsPolicy.cs" company="Nick Pruehs, Denis Vaz Alves">
//   Copyright 2011-2016 Nick Pruehs, Denis Vaz Alves.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ByChance.Configuration.PostProcessing
{
    using System;
    using System.Linq;

    using ByChance.Configuration.Parameters;
    using ByChance.Core;

    /// <summary>
    /// Aligns all open contexts in the processed level that are within the offset
    /// specified at the construction of this policy and are allowed to be aligned
    /// according to the specified level generator configuration.
    /// </summary>
    /// <seealso cref="Offset"/>
    /// <seealso cref="IContextAlignmentRestriction.CanBeAligned(Context, Context, object)"/>
    public sealed class AlignAdjacentContextsPolicy : PostProcessingPolicy
    {
        #region Constructors and Destructors

        /// <summary>
        /// Creates a new post-processing policy for aligning contexts that are
        /// within the specified offset.
        /// </summary>
        /// <param name="offset">Offset within two contexts are to be aligned.</param>
        public AlignAdjacentContextsPolicy(float offset)
        {
            this.Offset = offset;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Offset within two contexts are to be aligned.
        /// </summary>
        public float Offset { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Aligns all open contexts in the processed level that are within the offset
        /// specified at the construction of this policy and are allowed to be aligned
        /// according to the specified level generator configuration.
        /// </summary>
        /// <typeparam name="T">Type of the chunks the level consists of.</typeparam>
        /// <param name="configuration">Configuration of the level generator that built the level to be processed.</param>
        /// <param name="level">Level to process.</param>
        /// <seealso cref="Offset"/>
        /// <seealso cref="IContextAlignmentRestriction.CanBeAligned(Context, Context, object)"/>
        /// <exception cref="ArgumentNullException"><paramref name="configuration"/> or <paramref name="level"/> is <c>null</c>.</exception>
        public override void Process<T>(LevelGeneratorConfiguration configuration, Level<T> level)
        {
            base.Process(configuration, level);

            var openContexts = level.FindOpenContexts();
            for (var i = 0; i < openContexts.Count - 1; i++)
            {
                var firstContext = openContexts[i];
                if (firstContext.Target != null)
                {
                    continue;
                }

                for (var j = i + 1; j < openContexts.Count; j++)
                {
                    var secondContext = openContexts[j];

                    if (!firstContext.IsAdjacentTo(secondContext, this.Offset)
                        || configuration.ContextAlignmentRestrictions.Any(
                            restriction => !restriction.CanBeAligned(firstContext, secondContext, level)))
                    {
                        continue;
                    }

                    firstContext.AlignTo(secondContext);

                    this.LogMessage(
                        string.Format(
                            "+ Aligned adjacent contexts at {0} with an offset of {1}.",
                            firstContext,
                            this.Offset));
                }
            }
        }

        #endregion
    }
}