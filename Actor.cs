using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace HelloWorld
{
    public class Actor
    {
        protected Matrix3 _globalTransform;
        protected Matrix3 _localTransform;
        protected Matrix3 _scale;
        protected Matrix3 _rotation;
        protected Matrix3 _translation;
        protected Vector2 _velocity;
        protected Vector2 _acceleration;
        protected float _collisionRadius;
        protected float _maxSpeed;

        public Vector2 Forward
        {
            get
            {
                return new Vector2(_globalTransform.m11, _globalTransform.m21);
            }
            set
            {
                Vector2 lookposition = LocalPosition + value.Normalized;
                LookAt(lookposition);
            }
        }

        public Vector2 WorldPositon
        {
            get
            {
                return new Vector2(_globalTransform.m13, _globalTransform.m23);
            }
        }

        public Vector2 LocalPosition
        {
            get
            {
                return new Vector2(_localTransform.m13, _localTransform.m23);
            }
            set
            {
                _translation.m13 = value.X;

                _translation.m23 = value.Y;
            }
        }

        public Vector2 Velocity
        {
            get
            {
                return _velocity;
            }
            set
            {
                _velocity = value;
            }
        }

        public Vector2 Acceleration
        {
            get
            {
                return _acceleration;
            }
            set
            {
                _acceleration = value;
            }
        }

        public float MaxSpeed
        {
            get
            {
                return _maxSpeed;
            }
            set
            {
                _maxSpeed = value;
            }
        }


    }
}
