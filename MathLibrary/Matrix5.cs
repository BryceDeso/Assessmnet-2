using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
    public class Matrix5
    {
        public float m11, m12, m13, m14, m15, m21, m22, m23, m24, m25, m31, m32, m33, m34, m35, m41, m42, m43, m44, m45, m51, m52, m53, m54, m55;

        public Matrix5()
        {
            m11 = 1; m12 = 0; m13 = 0; m14 = 0; m15 = 0;
            m21 = 0; m22 = 1; m23 = 0; m24 = 0; m25 = 0;
            m31 = 0; m32 = 0; m33 = 1; m34 = 0; m35 = 0;
            m41 = 0; m42 = 0; m43 = 0; m44 = 1; m45 = 0;
            m51 = 0; m52 = 0; m53 = 0; m54 = 0; m55 = 1;
        }

        public Matrix5(float m11, float m12, float m13, float m14, float m15,
                       float m21, float m22, float m23, float m24, float m25,
                       float m31, float m32, float m33, float m34, float m35,
                       float m41, float m42, float m43, float m44, float m45,
                       float m51, float m52, float m53, float m54, float m55)
        {
            this.m11 = m11; this.m12 = m12; this.m13 = m13; this.m14 = m14; this.m15 = m15;
            this.m21 = m21; this.m22 = m22; this.m23 = m23; this.m24 = m24; this.m25 = m25;
            this.m31 = m31; this.m32 = m32; this.m33 = m33; this.m34 = m34; this.m35 = m35;
            this.m41 = m41; this.m42 = m42; this.m43 = m43; this.m44 = m44; this.m45 = m45;
            this.m51 = m11; this.m52 = m12; this.m53 = m13; this.m54 = m14; this.m55 = m55;
        }

        public static Matrix5 CreateRotation(float radians)
        {
            return new Matrix5
                (
                    (float)Math.Cos(radians), (float)Math.Sin(radians), 0, 0, 0,
                    -(float)Math.Sin(radians), (float)Math.Cos(radians), 0, 0, 0,
                    0, 0, 1, 0, 0,
                    0, 0, 0, 1, 0,
                    0, 0, 0, 0, 1
                );
        }

        //Creates a new matrix that has been translated by the given value.
        public static Matrix5 CreateTranslation(Vector2 position)
        {
            return new Matrix5
                (
                    1, 0, position.X, 0, 0,
                    0, 1, position.Y, 0, 0,
                    0, 0, 1, 0, 0,
                    0, 0, 0, 1, 0,
                    0, 0, 0, 0, 1
                );
        }

        // creates a new matrix that has been scaled by the given value
        public static Matrix5 CreateScale(Vector2 scale)
        {
            return new Matrix5
                (
                    scale.X, 0, 0, 0, 0,
                    0, scale.Y, 0, 0, 0,
                    0, 0, 1, 0, 0,
                    0, 0, 0, 1, 0,
                    0, 0, 0, 0, 1
                );
        }



        public static Matrix5 CreateRotationZ(float radian)
        {
            return new Matrix5
                (
                    (float)Math.Cos(radian), (float)Math.Sin(radian), 0, 0, 0,
                    (float)-Math.Sin(radian), (float)Math.Cos(radian), 0, 0, 0,
                    0, 0, 1, 0, 0, 
                    0, 0, 0, 1, 0,
                    0, 0, 0, 0, 1
                    );
        }

        public static Matrix5 CreateRotationY(float radian)
        {
            return new Matrix5
                (
                    (float)Math.Cos(radian), 0, (float)-Math.Sin(radian), 0, 0,
                    0, 1, 0, 0, 0,
                    (float)Math.Sin(radian), 0, (float)Math.Cos(radian), 0, 0,
                    0, 0, 0, 1, 0,
                    0, 0, 0, 0, 1
                );
        }

        public static Matrix5 CreateRotationX(float radian)
        {
            return new Matrix5
                (
                    1, 0, 0, 0, 0,
                    0, (float)Math.Cos(radian), (float)Math.Sin(radian), 0, 0,
                    0, (float)-Math.Sin(radian), (float)Math.Cos(radian), 0, 0,
                    0, 0, 0, 1, 0,
                    0, 0, 0, 0, 1
                );
        }

        public static Vector5 operator *(Matrix5 matrix, Vector5 vector)
        {
            return new Vector5
                (
                    matrix.m11 * vector.X + matrix.m12 * vector.Y + matrix.m13 * vector.Z + matrix.m14 * vector.W + matrix.m15 * vector.T,
                    matrix.m21 * vector.X + matrix.m22 * vector.Y + matrix.m23 * vector.Z + matrix.m24 * vector.W + matrix.m25 * vector.T,
                    matrix.m31 * vector.X + matrix.m32 * vector.Y + matrix.m33 * vector.Z + matrix.m34 * vector.W + matrix.m35 * vector.T,
                    matrix.m41 * vector.X + matrix.m42 * vector.Y + matrix.m43 * vector.Z + matrix.m44 * vector.W + matrix.m45 * vector.T,
                    matrix.m51 * vector.X + matrix.m52 * vector.Y + matrix.m53 * vector.Z + matrix.m54 * vector.W + matrix.m55 * vector.T
                );
        }

        public static Matrix5 operator -(Matrix5 lhs, Matrix5 rhs)
        {
            return new Matrix5(lhs.m11 - rhs.m11, lhs.m12 - rhs.m12, lhs.m13 - rhs.m13, lhs.m14 - rhs.m14, lhs.m15 - rhs.m15,
                               lhs.m21 - rhs.m21, lhs.m22 - rhs.m22, lhs.m23 - rhs.m23, lhs.m24 - rhs.m24, lhs.m25 - rhs.m25,
                               lhs.m31 - rhs.m31, lhs.m32 - rhs.m32, lhs.m33 - rhs.m33, lhs.m34 - rhs.m34, lhs.m35 - rhs.m35,
                               lhs.m41 - rhs.m41, lhs.m42 - rhs.m42, lhs.m43 - rhs.m43, lhs.m44 - rhs.m44, lhs.m45 - rhs.m45,
                               lhs.m51 - rhs.m51, lhs.m52 - rhs.m52, lhs.m53 - rhs.m53, lhs.m54 - rhs.m54, lhs.m55 - rhs.m55
                               );
        }

        public static Matrix5 operator *(Matrix5 lhs, Matrix5 rhs)
        {
            return new Matrix5
            (
                //Row 1, Column 1
                lhs.m11 * rhs.m11 + lhs.m12 * rhs.m21 + lhs.m13 * rhs.m31 + lhs.m14 * rhs.m41 + lhs.m15 * rhs.m51,
                //Row 1, Column 2
                lhs.m11 * rhs.m12 + lhs.m12 * rhs.m22 + lhs.m13 * rhs.m32 + lhs.m14 * rhs.m42 + lhs.m15 * rhs.m52,
                //Row 1, Column 3
                lhs.m11 * rhs.m13 + lhs.m12 * rhs.m23 + lhs.m13 * rhs.m33 + lhs.m14 * rhs.m43 + lhs.m15 * rhs.m53,
                //Row 1, Column 4
                lhs.m11 * rhs.m14 + lhs.m12 * rhs.m24 + lhs.m13 * rhs.m34 + lhs.m14 * rhs.m44 + lhs.m15 * rhs.m54,
                //Row 5, Column 5
                lhs.m11 * rhs.m14 + lhs.m12 * rhs.m24 + lhs.m13 * rhs.m34 + lhs.m14 * rhs.m44 + lhs.m15 * rhs.m55,

                //Row 2, Column 1
                lhs.m21 * rhs.m11 + lhs.m22 * rhs.m21 + lhs.m23 * rhs.m31 + lhs.m24 * rhs.m41 + lhs.m25 * rhs.m51,
                //Row 2, Column 2
                lhs.m21 * rhs.m12 + lhs.m22 * rhs.m22 + lhs.m23 * rhs.m32 + lhs.m24 * rhs.m42 + lhs.m25 * rhs.m52,
                //Row 2, Column 3
                lhs.m21 * rhs.m13 + lhs.m22 * rhs.m23 + lhs.m23 * rhs.m33 + lhs.m24 * rhs.m43 + lhs.m25 * rhs.m53,
                //Row 2, Column 4
                lhs.m21 * rhs.m14 + lhs.m22 * rhs.m24 + lhs.m23 * rhs.m34 + lhs.m24 * rhs.m44 + lhs.m25 * rhs.m54,
                //Row 5, Column 5
                lhs.m21 * rhs.m14 + lhs.m22 * rhs.m24 + lhs.m23 * rhs.m34 + lhs.m24 * rhs.m44 + lhs.m25 * rhs.m55,

                //Row 3, Column 1
                lhs.m31 * rhs.m11 + lhs.m32 * rhs.m21 + lhs.m33 * rhs.m31 + lhs.m34 * rhs.m41 + lhs.m35 * rhs.m51,
                //Row 3, Column 2
                lhs.m31 * rhs.m12 + lhs.m32 * rhs.m22 + lhs.m33 * rhs.m32 + lhs.m34 * rhs.m42 + lhs.m35 * rhs.m52,
                //Row 3, Column 3
                lhs.m31 * rhs.m13 + lhs.m32 * rhs.m23 + lhs.m33 * rhs.m33 + lhs.m34 * rhs.m43 + lhs.m35 * rhs.m53,
                //Row 3, Column 4
                lhs.m31 * rhs.m14 + lhs.m32 * rhs.m24 + lhs.m33 * rhs.m34 + lhs.m34 * rhs.m44 + lhs.m35 * rhs.m54,
                //Row 5, Column 5
                lhs.m31 * rhs.m14 + lhs.m32 * rhs.m24 + lhs.m33 * rhs.m34 + lhs.m34 * rhs.m44 + lhs.m35 * rhs.m55,

                //Row 4, Column 1
                lhs.m41 * rhs.m11 + lhs.m42 * rhs.m21 + lhs.m43 * rhs.m31 + lhs.m44 * rhs.m41 + lhs.m45 * rhs.m51,
                //Row 4, Column 2
                lhs.m41 * rhs.m12 + lhs.m42 * lhs.m22 + lhs.m43 * lhs.m32 + lhs.m44 * rhs.m42 + lhs.m45 * rhs.m52,
                //Row 4, Column 3
                lhs.m41 * rhs.m13 + lhs.m42 * rhs.m23 + lhs.m43 * rhs.m33 + lhs.m44 * rhs.m43 + lhs.m45 * rhs.m53,
                //Row 4, Column 4
                lhs.m41 * rhs.m14 + lhs.m42 * rhs.m24 + lhs.m43 * rhs.m34 + lhs.m44 * rhs.m44 + lhs.m45 * rhs.m54,
                //Row 5, Column 5
                lhs.m41 * rhs.m14 + lhs.m42 * rhs.m24 + lhs.m43 * rhs.m34 + lhs.m34 * rhs.m44 + lhs.m45 * rhs.m55,

                //Row 5, Column 1
                lhs.m51 * rhs.m11 + lhs.m52 * rhs.m21 + lhs.m53 * rhs.m31 + lhs.m54 * rhs.m41 + lhs.m55 * rhs.m51,
                //Row 5, Column 2
                lhs.m51 * rhs.m12 + lhs.m52 * lhs.m22 + lhs.m53 * lhs.m32 + lhs.m54 * rhs.m42 + lhs.m55 * rhs.m52,
                //Row 5, Column 3
                lhs.m51 * rhs.m13 + lhs.m52 * rhs.m23 + lhs.m53 * rhs.m33 + lhs.m54 * rhs.m43 + lhs.m55 * rhs.m53,
                //Row 5, Column 4
                lhs.m51 * rhs.m14 + lhs.m52 * rhs.m24 + lhs.m53 * rhs.m34 + lhs.m54 * rhs.m44 + lhs.m55 * rhs.m54,
                //Row 5, Column 5
                lhs.m51 * rhs.m15 + lhs.m52 * rhs.m25 + lhs.m53 * rhs.m35 + lhs.m54 * rhs.m45 + lhs.m55 * rhs.m55
            );
        }
    }
}
