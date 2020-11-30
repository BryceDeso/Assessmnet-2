using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

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
        protected char _icon;
        protected Color _raycolor;

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

        public Actor(float x, float y, Color raycolor, char icon = ' ')
        {
            _raycolor = raycolor;
            _icon = icon;
            _localTransform = new Matrix3();
            LocalPosition = new Vector2(x, y);
            _velocity = new Vector2();
            _rotation = new Matrix3();
            _scale = new Matrix3();
            _translation = new Matrix3();
        }

        public void LookAt(Vector2 position)
        {
            Vector2 direction = (position - LocalPosition).Normalized;

            float dotProd = Vector2.DotProduct(Forward, direction);
            if (Math.Abs(dotProd) > 1)
            {
                return;
            }

            float angle = (float)Math.Acos(dotProd);

            Vector2 perp = new Vector2(direction.X, direction.Y);

            float perpDot = Vector2.DotProduct(perp, Forward);

            if(perpDot != 0)
            {
                angle *= -perpDot / Math.Abs(perpDot);
            }
        }

        public bool CheckCollision(Actor other)
        {
            float distance = (other.WorldPositon - WorldPositon).Magnitude;
            return distance <= other._collisionRadius + _collisionRadius;
        }

        public void OnCollision()
        {

        }

        public void SetTranslation(Vector2 position)
        {
            _translation = Matrix3.CreateTranslation(position);
        }

        public void SetRotation(float radians)
        {
            _rotation = Matrix3.CreateRotation(radians);
        }

        public void SetScale(float x, float y)
        {
            _scale = Matrix3.CreateScale(new Vector2(x, y));
        }

    }
}
