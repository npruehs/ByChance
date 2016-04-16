﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Vector2F.cs" company="Nick Pruehs, Denis Vaz Alves">
//   Copyright 2011-2016 Nick Pruehs, Denis Vaz Alves.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ByChance.Levels2D
{
    using System;

    using ByChance.Core;

    /// <summary>
    /// Vector in two-dimensional space with floating point components. Note that vectors are immutable.
    /// </summary>
    public struct Vector2F : IEquatable<Vector2F>
    {
        #region Constants

        /// <summary>
        /// Vector with all components set to one.
        /// </summary>
        public static readonly Vector2F One = new Vector2F(1.0f, 1.0f);

        /// <summary>
        /// Null vector.
        /// </summary>
        public static readonly Vector2F Zero = new Vector2F();

        #endregion

        #region Fields

        /// <summary>
        /// X-component of this vector.
        /// </summary>
        private readonly float x;

        /// <summary>
        /// Y-component of this vector.
        /// </summary>
        private readonly float y;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Constructs a new vector with the specified components.
        /// </summary>
        /// <param name="x">
        /// X-component of the new vector.
        /// </param>
        /// <param name="y">
        /// Y-component of the new vector.
        /// </param>
        public Vector2F(float x, float y)
            : this()
        {
            this.x = x;
            this.y = y;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the magnitude of this vector.
        /// </summary>
        public float Length
        {
            get
            {
                return Math2.Sqrt(this.LengthSquared);
            }
        }

        /// <summary>
        /// Gets the squared magnitude of this vector. Faster than <see cref="Length"/>.
        /// </summary>
        public float LengthSquared
        {
            get
            {
                return (this.x * this.x) + (this.y * this.y);
            }
        }

        /// <summary>
        /// Gets the x-component of this vector.
        /// </summary>
        public float X
        {
            get
            {
                return this.x;
            }
        }

        /// <summary>
        /// Gets the y-component of this vector.
        /// </summary>
        public float Y
        {
            get
            {
                return this.y;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Adds the passed vectors.
        /// </summary>
        /// <param name="v1">
        /// First summand.
        /// </param>
        /// <param name="v2">
        /// Second summand.
        /// </param>
        /// <returns>
        /// Sum of the passed vectors.
        /// </returns>
        public static Vector2F Add(Vector2F v1, Vector2F v2)
        {
            return v1 + v2;
        }

        /// <summary>
        /// Adds the passed vector to this one, returning the sum of both vectors.
        /// </summary>
        /// <param name="v">
        /// Vector to add.
        /// </param>
        /// <returns>
        /// Sum of both vectors.
        /// </returns>
        public Vector2F Add(Vector2F v)
        {
            return Add(this, v);
        }

        /// <summary>
        /// Computes the Euclidean distance between the points at <paramref name="v1"/> and <paramref name="v2"/>.
        /// </summary>
        /// <param name="v1">
        /// First point to compute the distance of.
        /// </param>
        /// <param name="v2">
        /// Second point to compute the distance of.
        /// </param>
        /// <returns>
        /// Euclidean distance between the two passed points.
        /// </returns>
        public static float Distance(Vector2F v1, Vector2F v2)
        {
            return Math2.Sqrt(DistanceSquared(v1, v2));
        }

        /// <summary>
        /// Computes the Euclidean distance between the points denoted by this vector and <paramref name="v"/>.
        /// </summary>
        /// <param name="v">
        /// Point to compute the distance to.
        /// </param>
        /// <returns>
        /// Euclidean distance between the two points.
        /// </returns>
        public float Distance(Vector2F v)
        {
            return Distance(this, v);
        }

        /// <summary>
        /// Computes the squared Euclidean distance between the points at <paramref name="v1"/> and <paramref name="v2"/>. Faster than <see cref="Distance(Vector2F, Vector2F)"/>.
        /// </summary>
        /// <param name="v1">
        /// First point to compute the squared distance of.
        /// </param>
        /// <param name="v2">
        /// Second point to compute the squared distance of.
        /// </param>
        /// <returns>
        /// Squared Euclidean distance between the two passed points.
        /// </returns>
        public static float DistanceSquared(Vector2F v1, Vector2F v2)
        {
            var distX = v1.x - v2.x;
            var distY = v1.y - v2.y;
            return (distX * distX) + (distY * distY);
        }

        /// <summary>
        /// Computes the squared Euclidean distance between the points denoted by this vector and <paramref name="v"/>. Faster than <see cref="Distance(Vector2F)"/>.
        /// </summary>
        /// <param name="v">
        /// Point to compute the squared distance to.
        /// </param>
        /// <returns>
        /// Squared Euclidean distance between the two points.
        /// </returns>
        public float DistanceSquared(Vector2F v)
        {
            return DistanceSquared(this, v);
        }

        /// <summary>
        /// Divides the passed vector by the specified scalar.
        /// </summary>
        /// <param name="v">
        /// Dividend.
        /// </param>
        /// <param name="f">
        /// Divisor.
        /// </param>
        /// <returns>
        /// Vector divided by the specified scalar.
        /// </returns>
        public static Vector2F Divide(Vector2F v, float f)
        {
            return v / f;
        }

        /// <summary>
        /// Divides this vector by the specified scalar.
        /// </summary>
        /// <param name="f">
        /// Divisor.
        /// </param>
        /// <returns>
        /// Vector divided by the specified scalar.
        /// </returns>
        public Vector2F Divide(float f)
        {
            return Divide(this, f);
        }

        /// <summary>
        /// Computes the dot product of the two passed vectors.
        /// </summary>
        /// <param name="v1">
        /// First vector to compute the dot product of.
        /// </param>
        /// <param name="v2">
        /// Second vector to compute the dot product of.
        /// </param>
        /// <returns>
        /// Dot product of the two passed vectors.
        /// </returns>
        public static float Dot(Vector2F v1, Vector2F v2)
        {
            return (v1.x * v2.x) + (v1.y * v2.y);
        }

        /// <summary>
        /// Computes the dot product of the passed vector and this one.
        /// </summary>
        /// <param name="v">
        /// Vector to compute the dot product of.
        /// </param>
        /// <returns>
        /// Dot product of the two vectors.
        /// </returns>
        public float Dot(Vector2F v)
        {
            return Dot(this, v);
        }

        /// <summary>
        /// Compares the passed vector to this one for equality.
        /// </summary>
        /// <param name="obj">
        /// Vector to compare.
        /// </param>
        /// <returns>
        /// <c>true</c>, if both vectors are equal, and <c>false</c> otherwise.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Vector2F && this.Equals((Vector2F)obj);
        }

        /// <summary>
        /// Compares the passed vector to this one for equality.
        /// </summary>
        /// <param name="other">
        /// Vector to compare.
        /// </param>
        /// <returns>
        /// <c>true</c>, if both vectors are equal, and <c>false</c> otherwise.
        /// </returns>
        public bool Equals(Vector2F other)
        {
            return this.x.Equals(other.x) && this.y.Equals(other.y);
        }

        /// <summary>
        /// Gets the hash code of this vector.
        /// </summary>
        /// <returns>
        /// Hash code of this vector.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = this.x.GetHashCode();
                hashCode = (hashCode * 397) ^ this.y.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// Linearly interpolates between the two passed vectors.
        /// </summary>
        /// <param name="v1">
        /// First vector to interpolate.
        /// </param>
        /// <param name="v2">
        /// Second vector to interpolate.
        /// </param>
        /// <param name="l">
        /// Interpolation parameter. 0 returns <paramref name="v1"/>, 1 returns <paramref name="v2"/>.
        /// </param>
        /// <returns>
        /// Linear interpolation between the two passed vectors.
        /// </returns>
        public static Vector2F Lerp(Vector2F v1, Vector2F v2, float l)
        {
            if (l <= 0.0f)
            {
                return v1;
            }

            if (l >= 1.0f)
            {
                return v2;
            }

            return v1 + (l * (v2 - v1));
        }

        /// <summary>
        /// Linearly interpolates between the passed vector and this one.
        /// </summary>
        /// <param name="v">
        /// Vector to interpolate.
        /// </param>
        /// <param name="l">
        /// Interpolation parameter. 0 returns this vector, 1 returns <paramref name="v"/>.
        /// </param>
        /// <returns>
        /// Linear interpolation between the two vectors.
        /// </returns>
        public Vector2F Lerp(Vector2F v, float l)
        {
            return Lerp(this, v, l);
        }

        /// <summary>
        /// Multiplies the passed vector with the specified scalar.
        /// </summary>
        /// <param name="v">
        /// Vector to multiply.
        /// </param>
        /// <param name="f">
        /// Scalar to multiply the vector with.
        /// </param>
        /// <returns>
        /// Product of the vector and the scalar.
        /// </returns>
        public static Vector2F Multiply(Vector2F v, float f)
        {
            return f * v;
        }

        /// <summary>
        /// Multiplies the passed vector with the specified scalar.
        /// </summary>
        /// <param name="f">
        /// Scalar to multiply the vector with.
        /// </param>
        /// <param name="v">
        /// Vector to multiply.
        /// </param>
        /// <returns>
        /// Product of the vector and the scalar.
        /// </returns>
        public static Vector2F Multiply(float f, Vector2F v)
        {
            return f * v;
        }

        /// <summary>
        /// Multiplies this vector with the specified scalar.
        /// </summary>
        /// <param name="f">
        /// Scalar to multiply this vector with.
        /// </param>
        /// <returns>
        /// Product of this vector and the scalar.
        /// </returns>
        public Vector2F Multiply(float f)
        {
            return Multiply(f, this);
        }

        /// <summary>
        /// Normalizes the passed vector, returning a unit vector with the same orientation.
        /// If the passed vector is the zero vector, the zero vector is returned instead.
        /// </summary>
        /// <param name="v">
        /// Vector to normalize.
        /// </param>
        /// <returns>
        /// Normalized passed vector.
        /// </returns>
        public static Vector2F Normalize(Vector2F v)
        {
            var lengthSquared = v.LengthSquared;
            if (Math2.Equals(lengthSquared, 0f) || Math2.Equals(lengthSquared, 1f))
            {
                return v;
            }

            var lengthInverse = 1.0f / Math2.Sqrt(lengthSquared);

            return new Vector2F(v.x * lengthInverse, v.y * lengthInverse);
        }

        /// <summary>
        /// Normalizes this vector, returning a unit vector with the same orientation.
        /// If this passed vector is the zero vector, the zero vector is returned instead.
        /// </summary>
        /// <returns>
        /// Normalized vector.
        /// </returns>
        public Vector2F Normalize()
        {
            return Normalize(this);
        }

        /// <summary>
        /// Adds the passed vectors.
        /// </summary>
        /// <param name="v1">
        /// First summand.
        /// </param>
        /// <param name="v2">
        /// Second summand.
        /// </param>
        /// <returns>
        /// Sum of the passed vectors.
        /// </returns>
        public static Vector2F operator +(Vector2F v1, Vector2F v2)
        {
            return new Vector2F(v1.x + v2.x, v1.y + v2.y);
        }

        /// <summary>
        /// Divides the passed vector by the specified scalar.
        /// </summary>
        /// <param name="v">
        /// Dividend.
        /// </param>
        /// <param name="f">
        /// Divisor.
        /// </param>
        /// <returns>
        /// Vector divided by the specified scalar.
        /// </returns>
        public static Vector2F operator /(Vector2F v, float f)
        {
            return new Vector2F(v.x / f, v.y / f);
        }

        /// <summary>
        /// Compares the passed vectors for equality.
        /// </summary>
        /// <param name="v1">
        /// First vector to compare.
        /// </param>
        /// <param name="v2">
        /// Second vector to compare.
        /// </param>
        /// <returns>
        /// <c>true</c>, if both vectors are equal, and <c>false</c> otherwise.
        /// </returns>
        public static bool operator ==(Vector2F v1, Vector2F v2)
        {
            return v1.Equals(v2);
        }

        /// <summary>
        /// Compares the passed vectors for inequality.
        /// </summary>
        /// <param name="v1">
        /// First vector to compare.
        /// </param>
        /// <param name="v2">
        /// Second vector to compare.
        /// </param>
        /// <returns>
        /// <c>true</c>, if the vectors are not equal, and <c>false</c> otherwise.
        /// </returns>
        public static bool operator !=(Vector2F v1, Vector2F v2)
        {
            return !(v1 == v2);
        }

        /// <summary>
        /// Multiplies the passed vector with the specified scalar.
        /// </summary>
        /// <param name="v">
        /// Vector to multiply.
        /// </param>
        /// <param name="f">
        /// Scalar to multiply the vector with.
        /// </param>
        /// <returns>
        /// Product of the vector and the scalar.
        /// </returns>
        public static Vector2F operator *(Vector2F v, float f)
        {
            return f * v;
        }

        /// <summary>
        /// Multiplies the passed vector with the specified scalar.
        /// </summary>
        /// <param name="f">
        /// Scalar to multiply the vector with.
        /// </param>
        /// <param name="v">
        /// Vector to multiply.
        /// </param>
        /// <returns>
        /// Product of the vector and the scalar.
        /// </returns>
        public static Vector2F operator *(float f, Vector2F v)
        {
            return new Vector2F(v.x * f, v.y * f);
        }

        /// <summary>
        /// Subtracts the second vector from the first one.
        /// </summary>
        /// <param name="v1">
        /// Vector to subtract from.
        /// </param>
        /// <param name="v2">
        /// Vector to subtract.
        /// </param>
        /// <returns>
        /// Difference of both vectors.
        /// </returns>
        public static Vector2F operator -(Vector2F v1, Vector2F v2)
        {
            return new Vector2F(v1.x - v2.x, v1.y - v2.y);
        }

        /// <summary>
        /// Subtracts the second vector from the first one.
        /// </summary>
        /// <param name="v1">
        /// Vector to subtract from.
        /// </param>
        /// <param name="v2">
        /// Vector to subtract.
        /// </param>
        /// <returns>
        /// Difference of both vectors.
        /// </returns>
        public static Vector2F Subtract(Vector2F v1, Vector2F v2)
        {
            return v1 - v2;
        }

        /// <summary>
        /// Subtracts the passed vector from this one.
        /// </summary>
        /// <param name="v">
        /// Vector to subtract.
        /// </param>
        /// <returns>
        /// Difference of both vectors.
        /// </returns>
        public Vector2F Subtract(Vector2F v)
        {
            return Subtract(this, v);
        }

        /// <summary>
        /// Returns a <see cref="string"/> representation of this vector.
        /// </summary>
        /// <returns>
        /// This vector as <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return string.Format("({0}, {1})", this.x, this.y);
        }

        #endregion
    }
}