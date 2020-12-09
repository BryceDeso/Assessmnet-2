using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace HelloWorld
{
    class Wall : Actor
    {
        public Wall(float x, float y, Color raycolor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, raycolor, icon, color)
        {
            _collisionRadius = 0.2f;
        }

        public override void OnCollision(Actor other)
        {
            //if (other is Enemy)
            //{
            //    if(other.Velocity.X == -1)
            //    {
            //        other.Velocity.X = 1;
            //    }
            //    if(other.Velocity.X == 1)
            //    {
            //        other.Velocity.X = -1;
            //    }
            //}
            base.OnCollision(other);
        }



        public override void Draw()
        {
            //Raylib.DrawRectangle(10, 10, 600, 50, Color.BROWN);
            base.Draw();
        }
    }
}
