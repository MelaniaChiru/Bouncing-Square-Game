using DrawingLib.Graphics;
using DrawingLib.Input;
using GameBackend;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace BouncingBallGame;

public class BouncingBallGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private List<Ball> _balls;
    private Texture2D _ballImage;
    private Screen _screen;
    private MouseState _previous;
    private MouseState _current;

    private CustomKeyboard _keyboard = CustomKeyboard.Instance;
    private CustomMouse _mouse = CustomMouse.Instance;

    public BouncingBallGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        Window.AllowUserResizing = true;
    }

    protected override void Initialize()
    {
        int screenWidth = 640;
        int screenHeight = 480;

        // TODO: Add your initialization logic here
        _balls = new List<Ball>();
        _screen = new Screen(new RenderTarget2D(GraphicsDevice, screenWidth, screenHeight));

        _current = Mouse.GetState();
        _previous = _current;

        base.Initialize();
    }

    protected override void LoadContent()
    {
        int width = 50;
        int height = 50;

        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _ballImage = new Texture2D(GraphicsDevice, width, height);
        Color[] colorData = new Color[width * height];
        for (int i = 0; i < colorData.Length; i++)
        {
            colorData[i] = Color.Red;
        }

        _ballImage.SetData(colorData);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();


        // TODO: Add your update logic here
        _keyboard.Update();
        _mouse.Update();

        _previous = _current;
        _current = Mouse.GetState();

        int screenWidth = _screen.RenderTarget.Width;
        int screenHeight = _screen.RenderTarget.Height;

        // Map mouse position to screen coordinates
        var mouseScreenPosition = _mouse.GetScreenPosition(_screen);

        if (_current.LeftButton == ButtonState.Pressed && _previous.LeftButton == ButtonState.Released)
        {
            if (mouseScreenPosition != null)
            {
                // Only add ball if mouse is in screen 
                if (mouseScreenPosition.Value.X >= 0 && mouseScreenPosition.Value.X < screenWidth &&
                    mouseScreenPosition.Value.Y >= 0 && mouseScreenPosition.Value.Y < screenHeight)
                {
                    // Add a new ball at the mapped mouse position
                    var newBall = new Ball(mouseScreenPosition.Value.X, mouseScreenPosition.Value.Y, 50, 50, screenWidth, screenHeight);
                    _balls.Add(newBall);
                }

            }
        }

        foreach (var ball in _balls)
        {
            ball.Move();
        }

        // pressing 'Esc' exits the game
        if (_keyboard.IsKeyDown(Keys.Escape))
        {
            return;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        // Enable drawing to the screen
        _screen.Set();

        
        _screen.RenderTarget.GraphicsDevice.Clear(Color.DarkKhaki);

        // Pressing 'W' key makes background white
        if (_keyboard.IsKeyDown(Keys.W))
        {
            _screen.RenderTarget.GraphicsDevice.Clear(Color.White);
        }

        // Pressing 'B' key makes background white
        if (_keyboard.IsKeyDown(Keys.B))
        {
            _screen.RenderTarget.GraphicsDevice.Clear(Color.CornflowerBlue);
        }


        // draw sprites normally
        _spriteBatch.Begin();
        foreach (var ball in _balls) {
            _spriteBatch.Draw(_ballImage, new Vector2(ball.Coordinate.X, ball.Coordinate.Y), Color.White);
        }
        _spriteBatch.End();

        // Disable drawing to the screen
        _screen.UnSet();

        // Draw the contents of the screen to the window
        _screen.Present(new SpritesRenderer(GraphicsDevice), true);


        base.Draw(gameTime);
    }
}

/// References used:
/// https://docs.monogame.net/api/Microsoft.Xna.Framework.Graphics.RenderTarget2D.html
/// https://community.monogame.net/t/window-resizing-from-within-monogame/14383
