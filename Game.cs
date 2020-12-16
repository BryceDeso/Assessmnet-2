using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using MathLibrary;
using Raylib_cs;

namespace HelloWorld
{
    class Game
    {
        private static bool _gameOver = false;
        private static Scene[] _scenes;
        private static int _currentSceneIndex;
        public static int CurrentSceneIndex
        {
            get
            {
                return _currentSceneIndex;
            }
        }

        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.White;

        public static void SetGameCondition(bool value)
        {
            _gameOver = value;
        }

        public static Scene GetScene(int index)
        {
            if (index < 0 || index >= _scenes.Length)
                return new Scene();

            return _scenes[index];
        }

        public static Scene GetCurrentScene()
        {
            return _scenes[_currentSceneIndex];
        }

        public static int AddScene(Scene scene)
        {
            if (scene == null)
                return -1;

            Scene[] tempArray = new Scene[_scenes.Length + 1];

            for (int i = 0; i < _scenes.Length; i++)
            {
                tempArray[i] = _scenes[i];
            }

            int index = _scenes.Length;

            tempArray[index] = scene;

            _scenes = tempArray;

            return index;
        }

        public static bool RemoveScene(Scene scene)
        {
            if (scene == null)
                return false;

            bool sceneRemoved = false;

            Scene[] tempArray = new Scene[_scenes.Length - 1];

            int j = 0;
            for (int i = 0; i < _scenes.Length; i++)
            {
                if (tempArray[i] != scene)
                {
                    tempArray[j] = _scenes[i];
                    j++;
                }
                else
                {
                    sceneRemoved = true;
                }
            }

            if (sceneRemoved)
                _scenes = tempArray;

            return sceneRemoved;
        }

        public static void SetCurrentScene(int index)
        {
            if (index < 0 || index >= _scenes.Length)
                return;

            if (_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].End();

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

        public Game()
        {
            _scenes = new Scene[0];
        }

        public void Start()
        {
            //Creates a new window for raylib
            Raylib.InitWindow(470, 550, "Math For Games");
            Raylib.SetTargetFPS(60);

            //Set up console window
            Console.CursorVisible = false;
            Console.Title = "Math For Games";

            //Create a new scene for our actors to exist in
            Scene scene1 = new Scene();
            Scene scene2 = new Scene();

            //Create the enemies to add to the scene           
            Enemy enemy1 = new Enemy(0, 2, Color.GREEN, '#', ConsoleColor.Green);
            Enemy enemy6 = new Enemy(-5, 0, Color.GREEN, '#', ConsoleColor.Green);
            Enemy enemy11 = new Enemy(-10, 0, Color.GREEN, '#', ConsoleColor.Green);
            Enemy enemy16 = new Enemy(-15, 0, Color.GREEN, '#', ConsoleColor.Green);
            Enemy enemy21 = new Enemy(-20, 0, Color.GREEN, '#', ConsoleColor.Green);
            Enemy enemy26 = new Enemy(-25, 0, Color.GREEN, '#', ConsoleColor.Green);

            Enemy enemy2 = new Enemy(13, 5, Color.RED, '#', ConsoleColor.Red);
            Enemy enemy7 = new Enemy(5, 0, Color.RED, '#', ConsoleColor.Red);
            Enemy enemy12 = new Enemy(10, 0, Color.RED, '#', ConsoleColor.Red);
            Enemy enemy17 = new Enemy(15, 0, Color.RED, '#', ConsoleColor.Red);
            Enemy enemy22 = new Enemy(20, 0, Color.RED, '#', ConsoleColor.Red);
            Enemy enemy27 = new Enemy(25, 0, Color.RED, '#', ConsoleColor.Red);

            Enemy enemy3 = new Enemy(0, 8, Color.YELLOW, '#', ConsoleColor.Yellow);
            Enemy enemy8 = new Enemy(-5, 0, Color.YELLOW, '#', ConsoleColor.Yellow);
            Enemy enemy13 = new Enemy(-10, 0, Color.YELLOW, '#', ConsoleColor.Yellow);
            Enemy enemy18 = new Enemy(-15, 0, Color.YELLOW, '#', ConsoleColor.Yellow);
            Enemy enemy23 = new Enemy(-20, 0, Color.YELLOW, '#', ConsoleColor.Yellow);
            Enemy enemy28 = new Enemy(-25, 0, Color.YELLOW, '#', ConsoleColor.Yellow);

            Enemy enemy4 = new Enemy(13, 11, Color.GRAY, '#', ConsoleColor.Gray);
            Enemy enemy9 = new Enemy(5, 0, Color.GRAY, '#', ConsoleColor.Gray);
            Enemy enemy14 = new Enemy(10, 0, Color.GRAY, '#', ConsoleColor.Gray);
            Enemy enemy19 = new Enemy(15, 0, Color.GRAY, '#', ConsoleColor.Gray);
            Enemy enemy24 = new Enemy(20, 0, Color.GRAY, '#', ConsoleColor.Gray);
            Enemy enemy29 = new Enemy(25, 0, Color.GRAY, '#', ConsoleColor.Gray);

            Enemy enemy5 = new Enemy(0, 14, Color.WHITE, '#', ConsoleColor.White);
            Enemy enemy10 = new Enemy(-5, 0, Color.WHITE, '#', ConsoleColor.White);
            Enemy enemy15 = new Enemy(-10, 0, Color.WHITE, '#', ConsoleColor.White);
            Enemy enemy20 = new Enemy(-15, 0, Color.WHITE, '#', ConsoleColor.White);
            Enemy enemy25 = new Enemy(-20, 0, Color.WHITE, '#', ConsoleColor.White);
            Enemy enemy30 = new Enemy(-25, 0, Color.WHITE, '#', ConsoleColor.White);

            //Child enemies to each other to create pattern
            enemy1.AddChildActor(enemy6);
            enemy1.AddChildActor(enemy11);
            enemy1.AddChildActor(enemy16);
            enemy1.AddChildActor(enemy21);
            enemy1.AddChildActor(enemy26);

            enemy2.AddChildActor(enemy7);
            enemy2.AddChildActor(enemy12);
            enemy2.AddChildActor(enemy17);
            enemy2.AddChildActor(enemy22);
            enemy2.AddChildActor(enemy27);

            enemy3.AddChildActor(enemy8);
            enemy3.AddChildActor(enemy13);
            enemy3.AddChildActor(enemy18);
            enemy3.AddChildActor(enemy23);
            enemy3.AddChildActor(enemy28);

            enemy4.AddChildActor(enemy9);
            enemy4.AddChildActor(enemy14);
            enemy4.AddChildActor(enemy19);
            enemy4.AddChildActor(enemy24);
            enemy4.AddChildActor(enemy29);

            enemy5.AddChildActor(enemy10);
            enemy5.AddChildActor(enemy15);
            enemy5.AddChildActor(enemy20);
            enemy5.AddChildActor(enemy25);
            enemy5.AddChildActor(enemy30);


            enemy1.SetTranslate(new Vector2(0, 2));

            enemy1.Velocity.X = 1;
            enemy2.Velocity.X = -1.5f;
            enemy3.Velocity.X = 1;
            enemy4.Velocity.X = -1;
            enemy5.Velocity.X = 1.5f;

            //Create player and a goal to add to the scene
            Player player = new Player(7.5f, 0, Color.BLUE, '@', ConsoleColor.Red);
            Goal goal = new Goal(7.5f, 16, Color.BROWN, ' ', ConsoleColor.Blue);

            //Player Values
            player.Speed = 2;
            player.SetScale(1f, 2);
            player.SetRotation(1.55f);

            //Add actors to the scenes
            scene1.AddActor(player);
            scene1.AddActor(goal);        
            scene1.AddActor(enemy1);
            scene1.AddActor(enemy2);
            scene1.AddActor(enemy3);
            scene1.AddActor(enemy4);
            scene1.AddActor(enemy5);
            scene1.AddActor(enemy6);
            scene1.AddActor(enemy7);
            scene1.AddActor(enemy8);
            scene1.AddActor(enemy9);
            scene1.AddActor(enemy10);
            scene1.AddActor(enemy11);
            scene1.AddActor(enemy12);
            scene1.AddActor(enemy13);
            scene1.AddActor(enemy14);
            scene1.AddActor(enemy15);
            scene1.AddActor(enemy16);
            scene1.AddActor(enemy17);
            scene1.AddActor(enemy18);
            scene1.AddActor(enemy19);
            scene1.AddActor(enemy20);
            scene1.AddActor(enemy21);
            scene1.AddActor(enemy22);
            scene1.AddActor(enemy23);
            scene1.AddActor(enemy24);
            scene1.AddActor(enemy25);
            scene1.AddActor(enemy26);
            scene1.AddActor(enemy27);
            scene1.AddActor(enemy28);
            scene1.AddActor(enemy29);
            scene1.AddActor(enemy30);


            //Sets the starting scene index and adds the scenes to the scenes array
            int startingSceneIndex = 0;
            startingSceneIndex = AddScene(scene1);

            //Sets the current scene to be the starting scene index
            SetCurrentScene(startingSceneIndex);
        }

        /// <summary>
        /// Called every frame
        /// </summary>
        /// <param name="deltaTime">The time between each frame</param>
        public void Update(float deltaTime)
        {
            if (!_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].Start();

            _scenes[_currentSceneIndex].Update(deltaTime);
        }

        //Used to display objects and other info on the screen.
        public void Draw()
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.BLACK);
            Console.Clear();
            _scenes[_currentSceneIndex].Draw();

            Raylib.EndDrawing();
        }

        //Called when the game ends.
        public void End()
        {           

        }
        
        //Handles all of the main game logic including the main game loop.
        public void Run()
        {
            //Call start for all objects in game
            Start();

            //Loops the game until either the game is set to be over or the window closes
            while (!_gameOver == true && !Raylib.WindowShouldClose())
            {
                //Stores the current time between frames
                float deltaTime = Raylib.GetFrameTime();
                //Call update for all objects in game
                Update(deltaTime);
                //Call draw for all objects in game
                Draw();
                //Clear the input stream for the console window
                while (Console.KeyAvailable)
                    Console.ReadKey(true);
            }

            End();
        }
    }
}
