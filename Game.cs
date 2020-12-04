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
        private static Scene[] _scenes = new Scene[0];
        private static int _currentSceneIndex;

        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.White;

        public static void SetGameOver(bool value)
        {
            _gameover = value;
        }

        public static Scene GetScene(int index)
        {
            if (index < 0 || index >= _scenes.Length)
            {
                return new Scene();
            }

            return _scenes[index];
        }

        public static Scene GetCurrentScene()
        {
            return _scenes[_currentSceneIndex];
        }

        public static int AddScene(Scene scene)
        {
            if(scene == null)
            {
                return -1;
            }

            Scene[] newArray = new Scene[_scenes.Length + 1];

            for(int i = 0; i< _scenes.Length; i++)
            {
                newArray[i] = _scenes[i];
            }

            int index = _scenes.Length;

            newArray[index] = scene;

            _scenes = newArray;

            return index;
        }

        public static bool RemoveScene(Scene scene)
        {
            if(scene == null)
            {
                return false;
            }
            bool sceneRemoved = false;

            Scene[] newArray = new Scene[_scenes.Length - 1];

            int j = 0;

            for(int i = 0; i < _scenes.Length; i++)
            {
                if(newArray[i] != scene)
                {
                    newArray[j] = _scenes[i];
                    j++;
                }
                else
                {
                    sceneRemoved = true;
                }
            }

            if (sceneRemoved)
            {
                _scenes = newArray;
            }

            return sceneRemoved;
        }

        public static void SetCurrentScene(int index)
        {
            if(index < 0 || index >= _scenes.Length)
            {
                return;
            }

            _currentSceneIndex = index;
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

            Scene scene1 = new Scene();            

            Player player = new Player(10, 15, Color.BLUE, '■', ConsoleColor.Blue);
            Actor actor = new Actor(10, 10, Color.RED, '■', ConsoleColor.Red);

            player.AddChildActor(actor);

            scene1.AddActor(player);
            scene1.AddActor(actor);

            AddScene(scene1);
        }

        //Repeated until the game ends
        public void Update(float deltatime)
        {
            _scenes[_currentSceneIndex].Update(deltatime);
        }

        public void Draw()
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.BLACK);

            Console.Clear();

            _scenes[_currentSceneIndex].Draw();

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

            while (!_gameover == true && !Raylib.WindowShouldClose())
            {
                float deltaTime = Raylib.GetFrameTime();

                Update(deltaTime);

                Draw();

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
            }
        }
    }
}
