﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RectangleF.cs" company="Nick Pruehs, Denis Vaz Alves">
//   Copyright 2011-2016 Nick Pruehs, Denis Vaz Alves.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ByChance.Levels2D
{
    using System;

    /// <summary>
    /// Rectangle with floating point position and extent.
    /// </summary>
    public class RectangleF : IEquatable<RectangleF>
    {
        #region Fields

        /// <summary>
        /// Size of this rectangle, its width and height.
        /// </summary>
        private Vector2F size;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Constructs a new rectangle with the specified position and size.
        /// </summary>
        /// <param name="x">
        /// X-component of the rectangle position.
        /// </param>
        /// <param name="y">
        /// Y-component of the rectangle position.
        /// </param>
        /// <param name="width">
        /// Rectangle width.
        /// </param>
        /// <param name="height">
        /// Rectangle height.
        /// </param>
        public RectangleF(float x, float y, float width, float height)
            : this(new Vector2F(x, y), new Vector2F(width, height))
        {
        }

        /// <summary>
        /// Constructs a new rectangle with the specified position and size.
        /// </summary>
        /// <param name="x">
        /// X-component of the rectangle position.
        /// </param>
        /// <param name="y">
        /// Y-component of the rectangle position.
        /// </param>
        /// <param name="size">
        /// Rectangle size.
        /// </param>
        public RectangleF(float x, float y, Vector2F size)
            : this(new Vector2F(x, y), size)
        {
        }

        /// <summary>
        /// Constructs a new rectangle with the specified position and size.
        /// </summary>
        /// <param name="position">
        /// Rectangle position.
        /// </param>
        /// <param name="width">
        /// Rectangle width.
        /// </param>
        /// <param name="height">
        /// Rectangle height.
        /// </param>
        public RectangleF(Vector2F position, float width, float height)
            : this(position, new Vector2F(width, height))
        {
        }

        /// <summary>
        /// Constructs a new rectangle with the specified position and size.
        /// </summary>
        /// <param name="position">
        /// Rectangle position.
        /// </param>
        /// <param name="size">
        /// Rectangle size.
        /// </param>
        public RectangleF(Vector2F position, Vector2F size)
        {
            this.Position = position;
            this.Size = size;
        }

        /// <summary>
        /// Constructs a new rectangle without position or size.
        /// </summary>
        public RectangleF()
            : this(0f, 0f, 0f, 0f)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the area of this rectangle, the product of its width and height.
        /// </summary>
        public float Area
        {
            get
            {
                return this.Size.X * this.Size.Y;
            }
        }

        /// <summary>
        /// Gets the y-component of the bottom side of this rectangle.
        /// </summary>
        public float Bottom
        {
            get
            {
                return this.Position.Y + this.Size.Y;
            }
        }

        /// <summary>
        /// Gets the position of the bottom left corner of this rectangle.
        /// </summary>
        public Vector2F BottomLeft
        {
            get
            {
                return this.Position + new Vector2F(0f, this.Size.Y);
            }
        }

        /// <summary>
        /// Gets the position of the bottom right corner of this rectangle.
        /// </summary>
        public Vector2F BottomRight
        {
            get
            {
                return this.Position + this.Size;
            }
        }

        /// <summary>
        /// Gets the position of the center of this rectangle.
        /// </summary>
        public Vector2F Center
        {
            get
            {
                return (this.Position + this.Size) / 2;
            }
        }

        /// <summary>
        /// Gets or sets the height of this rectangle.
        /// </summary>
        public float Height
        {
            get
            {
                return this.Size.Y;
            }

            set
            {
                this.Size = new Vector2F(this.Size.X, value);
            }
        }

        /// <summary>
        /// Gets the x-component of the left side of this rectangle.
        /// </summary>
        public float Left
        {
            get
            {
                return this.Position.X;
            }
        }

        /// <summary>
        /// Gets the position of this rectangle.
        /// </summary>
        public Vector2F Position { get; set; }

        /// <summary>
        /// Gets the x-component of the right side of this rectangle.
        /// </summary>
        public float Right
        {
            get
            {
                return this.Position.X + this.Size.X;
            }
        }

        /// <summary>
        /// Gets or sets the size of this rectangle, its width and height.
        /// </summary>
        public Vector2F Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (value.X < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Width must be non-negative.");
                }

                if (value.Y < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Height must be non-negative.");
                }

                this.size = value;
            }
        }

        /// <summary>
        /// Gets the y-component of the top side of this rectangle.
        /// </summary>
        public float Top
        {
            get
            {
                return this.Position.Y;
            }
        }

        /// <summary>
        /// Gets the position of the top left corner of this rectangle.
        /// </summary>
        public Vector2F TopLeft
        {
            get
            {
                return this.Position;
            }
        }

        /// <summary>
        /// Gets the position of the top right corner of this rectangle.
        /// </summary>
        public Vector2F TopRight
        {
            get
            {
                return this.Position + new Vector2F(this.Size.X, 0f);
            }
        }

        /// <summary>
        /// Gets or sets the width of this rectangle.
        /// </summary>
        public float Width
        {
            get
            {
                return this.Size.X;
            }

            set
            {
                this.Size = new Vector2F(value, this.Size.Y);
            }
        }

        /// <summary>
        /// Gets or sets the x-component of the position of this rectangle.
        /// </summary>
        public float X
        {
            get
            {
                return this.Position.X;
            }

            set
            {
                this.Position = new Vector2F(value, this.Position.Y);
            }
        }

        /// <summary>
        /// Gets or sets the y-component of the position of this rectangle.
        /// </summary>
        public float Y
        {
            get
            {
                return this.Position.Y;
            }

            set
            {
                this.Position = new Vector2F(this.Position.X, value);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Checks whether this rectangle entirely encompasses the passed other one.
        /// </summary>
        /// <param name="other">
        /// Rectangle to check.
        /// </param>
        /// <returns>
        /// <c>true</c>, if this rectangle contains <paramref name="other"/>, and <c>false</c> otherwise.
        /// </returns>
        public bool Contains(RectangleF other)
        {
            return (this.Left <= other.Left && this.Right >= other.Right)
                   && (this.Top <= other.Top && this.Bottom >= other.Bottom);
        }

        /// <summary>
        /// Checks whether this rectangle contains the point denoted by the specified vector.
        /// </summary>
        /// <param name="point">
        /// Point to check.
        /// </param>
        /// <returns>
        /// <c>true</c>, if this rectangle contains <paramref name="point"/>, and <c>false</c> otherwise.
        /// </returns>
        public bool Contains(Vector2F point)
        {
            return point.X >= this.Left && point.X < this.Right && point.Y >= this.Top && point.Y < this.Bottom;
        }

        /// <summary>
        /// Compares the passed rectangle to this one for equality.
        /// </summary>
        /// <param name="other">
        /// Rectangle to compare.
        /// </param>
        /// <returns>
        /// <c>true</c>, if both rectangles are equal, and <c>false</c> otherwise.
        /// </returns>
        public bool Equals(RectangleF other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Position.Equals(other.Position) && this.Size.Equals(other.Size);
        }

        /// <summary>
        /// Compares the passed rectangle to this one for equality.
        /// </summary>
        /// <param name="obj">
        /// Rectangle to compare.
        /// </param>
        /// <returns>
        /// <c>true</c>, if both rectangles are equal, and <c>false</c> otherwise.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == this.GetType() && this.Equals((RectangleF)obj);
        }

        /// <summary>
        /// Gets the hash code of this rectangle.
        /// </summary>
        /// <returns>
        /// Hash code of this rectangle.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (this.Position.GetHashCode() * 397) ^ this.Size.GetHashCode();
            }
        }

        /// <summary>
        /// Checks whether this rectangle at least partially intersects the passed other one.
        /// </summary>
        /// <param name="other">
        /// Rectangle to check.
        /// </param>
        /// <returns>
        /// <c>true</c>, if this rectangle intersects <paramref name="other"/>, and <c>false</c> otherwise.
        /// </returns>
        public bool Intersects(RectangleF other)
        {
            return (this.Right > other.Left && this.Left < other.Right)
                   && (this.Bottom > other.Top && this.Top < other.Bottom);
        }

        /// <summary>
        /// Returns a <see cref="string"/> representation of this rectangle.
        /// </summary>
        /// <returns>
        /// This rectangle as <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Position: {0}, Size: {1}", this.Position, this.Size);
        }

        /// <summary>
        /// Creates the union of this rectangle of the passed other one.
        /// </summary>
        /// <param name="other">
        /// Rectangle to unite with.
        /// </param>
        public void Union(RectangleF other)
        {
            var mostRight = Math.Max(this.Right, other.Right);
            var mostTop = Math.Max(this.Top, other.Top);

            this.X = Math.Min(this.X, other.X);
            this.Y = Math.Min(this.Y, other.Y);

            this.Width = mostRight - this.X;
            this.Height = mostTop - this.Y;
        }

        #endregion
    }
}