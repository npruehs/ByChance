﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Context3D.cs" company="Nick Pruehs, Denis Vaz Alves">
//   Copyright 2011-2016 Nick Pruehs, Denis Vaz Alves.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ByChance.Levels3D
{
    using System;

    using ByChance.Core;

    /// <summary>
    /// Describes a position a chunk can be aligned at to another one in a
    /// 3D level.
    /// </summary>
    public sealed class Context3D : Context
    {
        #region Constructors and Destructors

        /// <summary>
        /// Constructs a new context with the passed position relative to the
        /// position of the chunk it belongs to.
        /// </summary>
        /// <param name="relativePosition">
        /// Position of the new context relative to the
        /// position of the chunk it belongs to.
        /// </param>
        internal Context3D(Vector3F relativePosition)
            : this(relativePosition, string.Empty)
        {
        }

        /// <summary>
        /// Constructs a new context of the specified category and with the passed
        /// position relative to the position of the chunk it belongs to.
        /// </summary>
        /// <param name="relativePosition">
        /// Position of the new context relative to the
        /// position of the chunk it belongs to.
        /// </param>
        /// <param name="tag">Category of the new context.</param>
        internal Context3D(Vector3F relativePosition, string tag)
            : base(tag)
        {
            this.RelativePosition = relativePosition;
        }

        /// <summary>
        /// Constructs a new context with the same index and relative position
        /// as the passed one and attaches it to the specified chunk.
        /// </summary>
        /// <param name="template">Context whose attributes to copy.</param>
        /// <param name="source">Chunk to attach the new context to.</param>
        internal Context3D(Context3D template, Chunk source)
            : base(template.Tag)
        {
            this.Index = template.Index;
            this.Source = source;
            this.RelativePosition = template.RelativePosition;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Absolute position of this context within the level.
        /// </summary>
        public Vector3F AbsolutePosition
        {
            get
            {
                return ((Chunk3D)this.Source).Position + this.RelativePosition;
            }
        }

        /// <summary>
        /// Position of this context relative to the
        /// position of the chunk it belongs to.
        /// </summary>
        public Vector3F RelativePosition { get; internal set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Checks whether this context is within <paramref name="offset"/> to <paramref name="other"/>
        /// in terms of the Euclidean norm.
        /// </summary>
        /// <param name="other">Context to check the adjacency to.</param>
        /// <param name="offset">Offset within this context is considered to be adjacent to <paramref name="other"/>.</param>
        /// <returns><c>true</c>, if <paramref name="other"/> is within <paramref name="offset"/> to this one, and <c>false</c> otherwise.</returns>
        /// <exception cref="ArgumentException">Context to check the adjacency to is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException">Context to check the adjacency to is not of type <see cref="Context3D"/>.</exception>
        public override bool IsAdjacentTo(Context other, float offset)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }

            Context3D context3D = other as Context3D;

            if (context3D == null)
            {
                throw new ArgumentException("Passed context is not of type Context3D.", "other");
            }

            return context3D.AbsolutePosition.Distance(this.AbsolutePosition) <= offset;
        }

        /// <summary>
        /// Returns the absolute position of this context within the level
        /// as string.
        /// </summary>
        /// <returns>Absolute position of this context within the level.</returns>
        public override string ToString()
        {
            return this.AbsolutePosition.ToString();
        }

        #endregion
    }
}