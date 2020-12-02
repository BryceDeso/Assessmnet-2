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
        protected Actor[] _children;
        protected Actor _parent;
        protected float _collisionRadius;
        protected float _maxSpeed;
        protected char _icon;
        protected Color _rayColor;
        protected ConsoleColor _color;

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

        public Vector2 WorldPosition
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
            _rayColor = raycolor;
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
            float distance = (other.WorldPosition - WorldPosition).Magnitude;
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

        public void UpdateFacing()
        {
            if(_velocity.Magnitude <= 0)
            {
                return;
            }
            Forward = Velocity.Normalized;
        }

        private void UpdateTransform()
        {
            _localTransform = _translation * _rotation * _scale;
        }

        private void UpdateGlobalTransform()
        {
            if(_parent != null)
            {
                _globalTransform = _parent._globalTransform * _localTransform;
            }
        }

        public virtual void Start()
        {
            
        }

        public virtual void Update(float deltaTime)
        {
            UpdateTransform();

            UpdateGlobalTransform();

            UpdateFacing();

            Velocity += Acceleration;

            if(Velocity.Magnitude > MaxSpeed)
            {
                Velocity = Velocity.Normalized * MaxSpeed;
            }

            LocalPosition += _velocity * deltaTime;
        }

        public virtual void Draw()
        {
            //Draws the actor and a line indicating it facing to the raylib window.
            //Scaled to match console movement
            Raylib.DrawText(_icon.ToString(), (int)(WorldPosition.X * 32), (int)(WorldPosition.Y * 32), 32, _rayColor);
            Raylib.DrawLine(
                (int)(WorldPosition.X * 32),
                (int)(WorldPosition.Y * 32),
                (int)((WorldPosition.X + Forward.X) * 32),
                (int)((WorldPosition.Y + Forward.Y) * 32),
                Color.WHITE
            );

            //Changes the color of the console text to be this actors color
            Console.ForegroundColor = _color;

            //Only draws the actor on the console if it is within the bounds of the window
            if (WorldPosition.X >= 0 && WorldPosition.X < Console.WindowWidth
                && WorldPosition.Y >= 0 && WorldPosition.Y < Console.WindowHeight)
            {
                Console.SetCursorPosition((int)WorldPosition.X, (int)LocalPosition.Y);
                Console.Write(_icon);
            }

            //Reset console text color to be default color
            Console.ForegroundColor = Game.DefaultColor;
        }

        public virtual void End()
        {

        }
    }
}
