| Bryce Deshotel|
|:---|
|s208069|
|Computer Programming|
|Assessment-1 Documentation|

### I. Requirements

Task given: Create a program using C# that meets the specified requirements requested by the professors

#### Task Requirements

    - Completed redistributable maths classes.
    - Complete the unit test
    - Show simple collision dection, a matrix hierarchy, and movement with velocity and vectors.
    - Have someone do a peer review of your work.
    - Complete number conversion exercises.

1. Input information: Player is able to use two of the arrow keys to move up and down the window.
2. Output information: The output varies since the player can either reach the goal and win or bump into a moving spike.


### II. Visuals

    - The game will display the game window.
        -If the player moves and bumps into a moving spike it will display text in the top left corner saying they 
         lost and to click the exit button on the console window to quit.
        -If the player reaches the goal it will display text in the top left corner saying they 
         won and to click the exit button on the console window to quit.


## III. Objects

### Project: Assessment2

#### File: Actor.cs

**Attributes**
    
    
    Name: _icon
    Type: char
    Description: Used to hold a icon for the actors.

    Name: _velocity
    Type: Vector2
    Description: Used to hold an actors velocity.

    Name: acceleration
    Type: Vector2
    Description: Used to enable actors to gain speed while moving.

    Name: _globalTransform
    Type: Matrix3
    Description: Keeps track of evereything is positioned.

    Name: _localTransform
    Type: Matrix3
    Description: Keeps track of where an actor's position is.

    Name: _scale
    Type: Matrix3
    Description: Uses a mtrix to hold the size of an object. 

    Name: _rotation
    Type: Matrix3
    Description: Uses a matrix to hold how far an object will rotate.

    Name: _translation
    Type: Matrix3
    Description: Holds where an actor is using a matrix.

    Name: _color
    Type: ConsoleColor
    Description: Used to store what color an actor whill apear on the debugging window.   

    Name: _rayColor
    Type: Color
    Description: Used to store what color an actor whill apear in a raylib window.  

    Name: _parent
    Type: Actor
    Description: Used to hold what actor's are parents.

    Name: _children
    Type: Actor[]
    Description: An array of actor's that have been childed to another actor.

    Name: _collisionRadius
    Type: float
    Description: Helps set a distance for the radius of a circle to detirmind how far two actors must be before they collide.

    Name: _maxSpeed
    Type: float
    Description: Normalizes accleration to put a cap on how fast an actor can go.

    Name: Started
    Type: Bool
    Description: Is a property that enables something to be done if the action has not already been started ot done yet.

    Name: Forward
    Type: Vector2
    Description: is a property that gets the global transform of an actor and sets the LookAt funtion.

    Name: WorldPosition
    Type: Vector2
    Description: Gets an actors position relative to where it is in the world.

    Name: LocalPosition
    Type: Vector2
    Description: Gets an actors position relative to a parents transform.

    Name: Velocity
    Type: Vector2
    Description: A property that gets and sets _velocity.

    Name: Acceleration
    Type: Vector2
    Description: A property that gets and sets _accleration.

    Name: MaxSpeed
    Type: float
    Description: A property that gets and sets _maxSpeed.

    Name: Actor(float, float, [char], [ConsoleColor])
    Type: Cosntructer
    Description: Is a constructer for a basic actor that allows you to change the position, icon, and color of an actor.

    Name: Acto(float, float, Color, [char], [ConsoleColor])
    Type: Constructer
    Description: An overload of Actor that allows you to change your color in a raylib window.

    Name: AddChildActor(Actor)
    Type: void
    Description: Childs an actor to another actor by adding them into the parent actor's children array.

    Name: RemoveChildActor(Actor)
    Type: bool
    Description: Removes a child from a parents children array.

    Name: LookAt(Vector2)
    Type: void
    Description: Turns an actors facing direction relative to the direction that actor is moving in.

    Name: CheckCollison(Actor)
    Type: void
    Description: Will check the distance of two object's world positions.

    Name: Oncollision(Actor)
    Type: void
    Description: Is called by other classes that inherit Actor but is used to say what happens on collision.

    Name: SetTranslate(Vector2)
    Type: void
    Description: Sets an actors position.

    Name: SetRotation(float)
    Type: void
    Description: Sets how far an actor will rotate.

    Name: SetScale(float, float)
    Type: void
    Description: Will set the scale of an actor.

    Name: UpdateFacing()
    Type: void
    Description: Updates the way an actor is facing.

    Name: UpdateGlobalTransForm()
    Type: void
    Description: Updates the global transform of an actor.

    Name: Start()
    Type: void
    Description: Will set started to true.

    Name: Update(float)
    Type: void
    Description: Updates the transform, global transform, and facing as well as acceleration.

    Name: Draw()
    Type: void
    Description: Draws the actor's icons to the screen.

    Name: End()
    Type: void
    Description: Sets started to false.

#### File: Enemy.cs

**Attributes**

    Name: _target
    Type: Actor
    Description: Holds what actor it needs to react to.

    Name: Target
    Type: Actor
    Description: Is a property that gets and sets _target.

    Name: Enemy(float, float, [char], [ConsoleColor])
    Type: Cosntructer
    Description: Is a constructer override of actor that includes a colliison radius.

    Name: Enemy(flaot, float, Color, [char], [ConsoleColor])
    Type: Constructer
    Description: Oveload of enemy construter that includes an option to change color in raylib window.

    Name: OnCollision(Actor)
    Type: void
    Description: Override of Actors Oncollision, will set gameover to true and drawing lose text to screen.

    Name: Start()
    Type: void
    Description: Override of actors Start.

    Name: Update(float)
    Type: void
    Description: Override of Actors Update.

    Name: Draw()
    Type: void
    Description: Draws a circle the size of an enemies collision raidus.

    Name: DrawLoseText()
    Type: void
    Description: Displays text saying the player lost when a player collides with an enemy.

    Name: End()
    Type: void
    Description: Override of Actor's End.

#### File: Game.cs

**Attributes**

    Name: _gamover
    Type: bool
    Description: holds true of false.

    Name: _scenes
    Type: Scene[]
    Description: Holds an array of scenes.

    Name: _currentSceneIndex
    Type: int
    Description: Will get the current scene from _scnene.

    Name: CurrentSceneIndex
    Type: int
    Description: Property that gets _currentSceneIndex.

    Name: DefaultColor
    Type: ConsoleColor
    Description: Property that gets and sets ConsoleColor

    Name: SetGameCondition(bool)
    Type: void
    Description: Sets _gameOver to true or false.

    Name: GetScene(int)
    Type: Scene
    Description: Gets scene at what int was set in the argument.

    Name: GetCurrentScene()
    Type: Scene
    Description: returns _currentSceneIndex to get current scene.

    Name: AddScene(Scene)
    Type: int
    Description: Adds a scene to the array of scenes.

    Name: RemoveScene(Scene)
    Type: bool
    Description: Will remove a scene from the array of scenes.

    Name: SetCurrentScene(int)
    Type: void
    Description: Sets the current scene by the index set by int.

    Name: GetKeyDown(int)
    Type: bool
    Description: Checks to see if a key is held down.

    Name: GetKeyPressed(int)
    Type: bool
    Description: Checks to see if a key was pressed.

    Name: Game()
    Type: Constructer
    Description: Creates instance of _scene.

    Name: Start()
    Type: void
    Description: Creates instances of players and enemies as well as setting up the scenes and raylib window.

    Name: Update(float)
    Type: void
    Description: Updates scenes.

    Name: Draw()
    Type: void
    Description: Drawing whatever is in _scenes and setting the background to black.

    Name: End()
    Type: void
    Description: N\A

    Name: Run()
    Type: void
    Description: Will run Start, Update, Draw, and End.

#### File: Goal

**Attributes**

    Name: Goal(float, float, Color, [char], [ConsoleColor])
    Type: Constructer
    Description: A constructer that inherits from actor but a collision radius is added.

    Name: OnCollision(Actor)
    Type: void
    Description: Is an override of Actor's, will display win text and set _gameOver to true when collides with a player.

    Name: DrawWinText()
    Type: void
    Description: Will draw when a player collides with a goal, text displayed will tell the player they won.

    Name: Draw()
    Type: void
    Description: Draws the retangle and the word goal.

#### File: PLayer.cs

**Attributes**

    Name: _speed
    Type: float
    Description: Holds how fast the player can move.

    Name: Speed
    Type: float
    Description: Is a property that gets and sets _speed.

    Name: Player(float, float, [char], [ConsoleColor])
    Type: Construter
    Description: A constructer that inherits from the actor class but with a colillision radius added.

    Name: PLayer(float, float, Color, [char], [ConsoleColor])
    Type: Constructer
    Description: Overload of player constructer that allows the change of color in raylib window.

    Name: Update(flaot)
    Type: void
    Description: Updates the accelration and what keys are being pressed.

    Name: Draw()
    Type: void
    Description: Draws a circle based on the collision radius.

#### File: Program

**Attributes**

    Name: Main(string[])
    Type: void
    Description: Will create a new instance of game and run it.

#### File: Scene

**Attributes**

    Name: _actors
    Type: Actor[]
    Description: Holds an array of all actors.

    Name: _transform
    Type: Matrix3
    Description: Holds matrix transform.

    Name: Started
    Type: bool
    Description: A property that gets and sets started.

    Name: World
    Type: Matrix3
    Description: A property that gets _transform.

    Name: Scene()
    Type: Constructer
    Description: Creates an instance of _actor.

    Name: AddActor(Actor)
    Type: void
    Description: Adds actor to _actors.

    Name: RemoveActor(int)
    Type: bool
    Description: Will remove actor from _actors.

    Name: CheckCollision()
    Type: void
    Description: Will check collison between all actors in a scene.

    Name: RemoveActor(Actor)
    Type: bool
    Description: Overlaod of RemoveActor(int), overload takes an actor instead of int.

    Name: Start()
    Type: void
    Description: N\A

    Name: Update(float)
    Type: void
    Description: Updates _actors and Checkcollison.

    Name: Draw()
    Type: void
    Description: Draws any actors to the screen if they are in scene.

    Name: End()
    Type: void
    Description: N\A

### Project: MathLibrary

#### File: Matrix3

**Attributes**

    Name: m11, m12, m13, m21, m22, m23, m31, m32, m33
    Type: float
    Description: Will store numbers to alter matrix.

    Name: Matrix3()
    Type: Constructer
    Description: Sets numbers in matrix.

    Name: Matrix3(float, float, float, float, float, float, float, float, float)
    Type: Constructer
    Description: Overlaod of Matrix3(), allows chnages to all points in matrix.

    Name: CreateRotation(float)
    Type: Matrix3
    Description: Creats roation based on float inputed in argument.

    Name: CreateTranslation(Vector2)
    Type: Matrix3
    Description: Sets translation based on cordinates set in the Vector2 in the argument.

    Name: CreateScale(Vector2)
    Type: Matrix3
    Description: Sets scale based on input in argument.

    Name: operator*(Matrix3, Vector3)
    Type: Equation
    Description: Multiplies Mtrix3 by Vector3

    Name: operator-(Matrix3, Matrix3)
    Type: Equation
    Description: Subtracts Matrix3 by a Matrix3.

    Name: operator*(Matrix3, Matrix3)
    Type: Equation
    Description: Mutiplies a Matrix3 by a Matrix3.

#### File: Matrix4

**Attributes**

    Name: m11, m12, m13, m14, m21, m22, m23, m24, m31, m32, m33, m34, m41, m42, m43, m44
    Type: float
    Description: Will store numbers to alter matrix.

    Name: Matrix4()
    Type: Constructer
    Description: Sets numbers in matrix.

    Name: Matrix4(float, float, float, float, float, float, float, float, float, float, float, float, float, float, float, float)
    Type: Constructer
    Description: Overlaod of Matrix3(), allows chnages to all points in matrix.

    Name: CreateTranslation(Vector2)
    Type: Matrix4
    Description: Sets translation based on cordinates set in the Vector2 in the argument.

    Name: CreateScale(Vector2)
    Type: Matrix4
    Description: Sets scale based on input in argument.

    Name: CreateRotationZ(float)
    Type: Matrix4
    Description: Rotates object on Z axis

    Name: CreateRotationY(float)
    Type: Matrix4
    Description: Rotates object on Y axis.

    Name: CreateRotationX(float)
    Type: Matrix4
    Description: Rotates object on X axis.

    Name: operator*(Matrix4, Vector4)
    Type: Equation
    Description: Multiplies Matrix4 by Vector4

    Name: operator-(Matrix4, Matrix4)
    Type: Equation
    Description: Subtracts Matrix4 by a Matrix4.

    Name: operator*(Matrix4, Matrix4)
    Type: Equation
    Description: Mutiplies a Matrix4 by a Matrix4.

#### File: Vector2

**Attributes**

    Name: _x
    Type: float
    Description: holds float that will translate to the x axis.

    Name: _y
    Type: float
    Description: Holds float that will translate to the y axis.

    Name: X
    Type: float
    Description: Property that gets and sets _x.

    Name: Y
    Type: float
    Description: Property that gets and sets _y.

    Name: Magnitude
    Type: float
    Description: Gets the distance between the vectors origin and endpoint.

    Name: Normalized
    Type: Vector2
    Description: Makes sure your vectors dont add when moving an actor.

    Name: Vector2
    Type: Cosntructer
    Description: Sets all axis to 0.

    Name: Vector2(float, float)
    Type: Constructer
    Description: Overload of Vector2(), allows you to set all axis by inputing into argument.

    Name: CrossProduct(Vector2, Vector2)
    Type: Vector2
    Description: finds vector perpindicualr to two other vectors.

    Name: Normalize(Vector2)
    Type: Vector2
    Description: Normalizes vector inputed into argument.

    Name: DotProduct(Vector2, Vector2)
    Type: float
    Description: Takes two equal length numbers an makes them one.

    Name: operator+(Vector2, Vector2)
    Type: Vector2
    Description: Adds left hand side by right hand side

    Name: operator-(Vector2, Vector2)
    Type: Vector2
    Description: Subtracts left hand side by right hand side

    Name: operator*(Vector2, float)
    Type: Vector2
    Description: Multipies a Vector4 by a float.

    Name: operator*(flaot, Vector2)
    Type: Vector2
    Description: Multipies a float by a Vector4.

    Name: operator/(Vector2, float)
    Type: Vector2
    Description: Divides a Vector4 by a float inputed into the argument.

#### File Vector3

**Attributes**

    Name: _x
    Type: float
    Description: holds float that will translate to the x axis.

    Name: _y
    Type: float
    Description: Holds float that will translate to the y axis.

    Name: _z
    Type: float
    Description: Holds float that will translate to the z axis.

    Name: X
    Type: float
    Description: Property that gets and sets _x.

    Name: Y
    Type: float
    Description: Property that gets and sets _y.

    Name: Z
    Type: float
    Description: Property that gets and sets _z.


    Name: Magnitude
    Type: float
    Description: Gets the distance between the vectors origin and endpoint.

    Name: Normalized
    Type: Vector3
    Description: Makes sure your vectors dont add when moving an actor.

    Name: Vector3
    Type: Cosntructer
    Description: Sets all axis to 0.

    Name: Vector3(float, float, float)
    Type: Constructer
    Description: Overload of Vector3(), allows you to set all axis by inputing into argument.

    Name: CrossProduct(Vector3, Vector3)
    Type: Vector3
    Description: finds vector perpindicualr to two other vectors.

    Name: Normalize(Vector3)
    Type: Vector3
    Description: Normalizes vector inputed into argument.

    Name: DotProduct(Vector3, Vector3)
    Type: float
    Description: Takes two equal length numbers an makes them one.

    Name: operator+(Vector3, Vector3)
    Type: Vector3
    Description: Adds left hand side by right hand side

    Name: operator-(Vector3, Vector3)
    Type: Vector4
    Description: Subtracts left hand side by right hand side

    Name: operator*(Vector3, float)
    Type: Vector3
    Description: Multipies a Vector3 by a float.

    Name: operator*(float, Vector3)
    Type: Vector3
    Description: Multipies a float by a Vector4.

    Name: operator/(Vector4, float)
    Type: Vector3
    Description: Divides a Vector4 by a float inputed into the argument.

#### File: Vector4

**Attributes**

    Name: _x
    Type: float
    Description: holds float that will translate to the x axis.

    Name: _y
    Type: float
    Description: Holds float that will translate to the y axis.

    Name: _z
    Type: float
    Description: Holds float that will translate to the z axis.

    Name: _w
    Type: float
    Description: Holds float that will translate to the w axis.

    Name: X
    Type: float
    Description: Property that gets and sets _x.

    Name: Y
    Type: float
    Description: Property that gets and sets _y.

    Name: Z
    Type: float
    Description: Property that gets and sets _z.

    Name: W
    Type: float
    Description: Property that gets and sets _w.

    Name: Magnitude
    Type: float
    Description: Gets the distance between the vectors origin and endpoint.

    Name: Normalized
    Type: Vector4
    Description: Makes sure your vectors dont add when moving an actor.

    Name: Vector4
    Type: Cosntructer
    Description: Sets all axis to 0.

    Name: Vector4(float, float, float, float)
    Type: Constructer
    Description: Overload of Vector4(), allows you to set all axis by inputing into argument.

    Name: CrossProduct(Vector4, Vector4)
    Type: Vector4
    Description: finds vector perpindicualr to two other vectors.

    Name: Normalize(Vector4)
    Type: Vector4
    Description: Normalizes vector inputed into argument.

    Name: DotProduct(Vector4, Vector4)
    Type: float
    Description: Takes two equal length numbers an makes them one.

    Name: operator+(Vector4, Vector4)
    Type: Vector4
    Description: Adds left hand side by right hand side

    Name: operator-(Vector4, Vector4)
    Type: Vector4
    Description: Subtracts left hand side by right hand side

    Name: operator*(Vector4, float)
    Type: Vector4
    Description: Multipies a Vector4 by a float.

    Name: operator*(flaot, Vector4)
    Type: Vector4
    Description: Multipies a float by a Vector4.

    Name: operator/(Vector4, float)
    Type: Vector4
    Description: Divides a Vector4 by a float inputed into the argument.