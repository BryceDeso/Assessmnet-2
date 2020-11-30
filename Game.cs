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

        //Run the game
        public void Run()
        {
            Start();

            while(!_gameover == false && !Raylib.WindowShouldClose())
            {
                Update();

                Draw();

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
            }
        }

        //Performed once when the game begins
        public void Start()
        {
            
        }

        //Repeated until the game ends
        public void Update()
        {
            
        }

        public void Draw()
        {

        }

        //Performed once when the game ends
        public void End()
        {
            
        }
    }
}
