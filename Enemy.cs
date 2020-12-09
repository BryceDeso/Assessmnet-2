using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace HelloWorld
{

    class Enemy : Actor
    {
        private Actor _target;

        public Actor Target
        {
            get { return _target; }
            set { _target = value; }
        }

        public Enemy(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, icon, color)
        {
            _collisionRadius = 0.2f;
        }

        public Enemy(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, rayColor, icon, color)
        {
            _collisionRadius = 0.2f;
        }

        public override void OnCollision(Actor other)
        {
            if (other is Player)
            {
                DrawLoseText();
                Game.SetGameCondition(true);
            }
            base.OnCollision(other);
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
        }

        public override void Draw()
        {
            Raylib.DrawCircleLines(
               (int)(WorldPosition.X * 32.5f),
               (int)(WorldPosition.Y * 32.7),
               _collisionRadius * 6,
               Color.WHITE
               );

            base.Draw();
        }

        public static void DrawLoseText()
        {
            Raylib.DrawText("You lose!\nPress esc to quit.", 15, 11, 10, Color.WHITE);
        }

        public override void End()
        {
            base.End();
        }

    }
}
