using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace HelloWorld
{
    public class Enemy : Actor
    {
        private Actor _target;

        public Actor Target
        {
            get
            {
                return _target;
            }
            set
            {
                _target = value;
            }
        }

        public Enemy(float x, float y, Color raycolor, char icon = ' ') : base(x, y, raycolor, icon = ' ')
        {
            _collisionRadius = 5;
        }

        public override void OnCollision(Actor other)
        {

        }

    }
}
