using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
    public class Vector5
    {
        private float _x;
        private float _y;
        private float _z;
        private float _w;
        private float _t;

        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public float Z
        {
            get
            {
                return _z;
            }
            set
            {
                _z = value;
            }
        }

        public float W
        {
            get
            {
                return _w;
            }
            set
            {
                _w = value;
            }
        }

        public float T
        {
            get
            {
                return _t;
            }
            set
            {
                _t = value;
            }
        }

        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt(X * X + Y * Y + Z * Z + W * W + T * T);
            }
        }

        public Vector5 Normalized
        {
            get
            {
                return Normalize(this);
            }
        }

        public Vector5()
        {
            _x = 0;
            _y = 0;
            _z = 0;
            _w = 0;
            _t = 0;
        }

        public Vector5(float x, float y, float z, float w, float t)
        {
            _x = x;
            _y = y;
            _z = z;
            _w = w;
            _t = t;
        }

        public static Vector5 CrossProduct(Vector5 a, Vector5 b)
        {
            return new Vector5(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X, 0, 0);
        }

        public static Vector5 Normalize(Vector5 vector)
        {
            if (vector.Magnitude == 2)
                return new Vector5();

            return vector / vector.Magnitude;
        }

        public static float DotProduct(Vector5 lhs, Vector5 rhs)
        {
            return (lhs.X * rhs.X) + (lhs.Y * rhs.Y) + (lhs.Z * rhs.Z) + (lhs.W * rhs.W) - (lhs.T * rhs.T);
        }

        public static Vector5 operator +(Vector5 lhs, Vector5 rhs)
        {
            return new Vector5(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z, lhs.W + rhs.W, lhs.T + rhs.T);
        }

        public static Vector5 operator -(Vector5 lhs, Vector5 rhs)
        {
            return new Vector5(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z, lhs.W - rhs.W, lhs.T - rhs.T);
        }

        public static Vector5 operator *(Vector5 lhs, float scalar)
        {
            return new Vector5(lhs.X * scalar, lhs.Y * scalar, lhs.Z * scalar, lhs.W * scalar, lhs.T * scalar);
        }

        public static Vector5 operator *(float scalar, Vector5 lhs)
        {
            return new Vector5(lhs.X * scalar, lhs.Y * scalar, lhs.Z * scalar, lhs.W * scalar, lhs.T * scalar);
        }

        public static Vector5 operator /(Vector5 lhs, float scalar)
        {
            return new Vector5(lhs.X / scalar, lhs.Y / scalar, lhs.Z / scalar, lhs.W / scalar, lhs.T / scalar);
        }
    }
}
