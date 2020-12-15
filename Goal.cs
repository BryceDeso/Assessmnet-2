using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace HelloWorld
{
    class Goal : Actor
    {
        public Goal(float x, float y, Color raycolor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, raycolor, icon, color)
        {
            _collisionRadius = 0.2f;
        }

        public override void OnCollision(Actor other)
        {
            if(other is Player)
            {
                Raylib.ClearBackground(Color.LIME);
                DrawWinText();
                Game.SetGameCondition(true);
            }
            base.OnCollision(other);
        }

        public void DrawWinText()
        {
            Raylib.DrawText("You win!\nPress the X on the console window to quit!", 3, 6, 4, Color.ORANGE);
        }

        public override void Draw()
        {
            Raylib.DrawRectangle(0, 500, 800, 50, Color.GOLD);
            Raylib.DrawText("Goal", 180, 500, 40, Color.PURPLE);
            base.Draw();
        }
    }
}
