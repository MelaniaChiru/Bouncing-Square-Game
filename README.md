# 🟥 Bouncing Square Game
Simple project built with the **MonoGame framework**. It demonstrates core game loop concepts, collision detection, and user input handling by allowing the player to dynamically create and destroy bouncing squares within the game window.

## 💡 Features
* **Dynamic Object Creation**: Left-click the mouse anywhere on the screen to instantly spawn a new square that begins moving.
* **Boundary Collision**: Each square bounces realistically off all four edges of the game window.
* **Frame-Rate Independent Movement**: Object movement and updates are tied to game time, ensuring smooth, consistent behavior regardless of the system's current frame rate.
* **Scalable Display**: The game is fully scalable, adjusting to different window sizes while maintaining the correct aspect ratio and ensuring the squares' positions and sizes scale appropriately.
* **Customizable Aesthetics**: Users can easily change the background color of the game window.
* **Screen Clearing**: Right-click mouse to clear all squares.

## ⚙️ Built with
* C#
* MonoGame Framework
* Vector math


## 🎬 Demo



## Running the game

1. If not already done, install .NET SDK from official Microsoft website
>[!NOTE]
> The .NET version of this project is 9.0
> but if you have an older version, you can manually change the project's version by going in all the .csproj files as well as the .sln file to change `9.0` to which version you have installed.

2. Install MonoGame Templates
```
dotnet new install MonoGame.Templates.CSharp
```
3. Clone project
```
git clone https://github.com/MelaniaChiru/Bouncing-Ball-Game.git
```
4. Go to 'BouncingBallGame' folder. (BouncingBallGame.csproj should be inside)
``` cd BouncingBallGame```
6. Run game
  ``` dotnet run ```

## Future Improvements
* Introcude **square to square collision** (i.e. have squares bounce off each other).
* Add different shapes (circles, triangles, rectangles, etc.)
