using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace HelloWorld
{
    class Game
    {
        private static bool _gameover = false;

        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.White;

        public static void SetGameOver(bool value)
        {
            _gameover = value;
        }

        public static bool GetKeyDown(int key)
        {
            return Raylib.IsKeyDown((KeyboardKey)key);
        }

        public static bool GetKeyPressed(int key)
        {
            return Raylib.IsKeyPressed((KeyboardKey)key);
        }

        //Performed once when the game begins
        public void Start()
        {
            Raylib.InitWindow(1024, 760, "Assessment-2");
            Raylib.SetTargetFPS(60);

            Console.CursorVisible = false;
            Console.Title = "Math for Games";

            Actor actor = new Actor(10, 10, Color.RED, '■');
        }

        //Repeated until the game ends
        public void Update()
        {
            
        }

        public void Draw()
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.BLACK);

            Console.Clear();

            Raylib.EndDrawing();
        }

        //Performed once when the game ends
        public void End()
        {
            
        }

        //Run the game
        public void Run()
        {
            Start();

            while (!_gameover == false && !Raylib.WindowShouldClose())
            {
                Update();

                Draw();

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
            }
        }
    }
}
