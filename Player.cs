﻿using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace HelloWorld
{
    class Player : Actor
    {
        private float _speed = 1;

        public float Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
            }
        }

        public Player(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, icon, color)
        {
            _collisionRadius = 0.5f;
        }

        public Player(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, rayColor, icon, color)
        {
            _collisionRadius = 0.5f;
        }

        public override void Update(float deltaTime)
        {           
            int xDirection = 0;
            int yDirection = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_UP))
                + Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_DOWN));

            Acceleration = new Vector2(xDirection, yDirection);

            base.Update(deltaTime);
        }

        public override void Draw()
        {
            Raylib.DrawCircleLines(
               (int)(WorldPosition.X * 32),
               (int)(WorldPosition.Y * 32),
               _collisionRadius * 6,
               Color.WHITE
               );

            base.Draw();
        }
    }
}
