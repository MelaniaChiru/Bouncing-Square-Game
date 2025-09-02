using DrawingLib.Graphics;
using GameBackend;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BouncingBallGame;

public class BouncingBallGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Ball _ball;
    private Texture2D _ballImage;
    private Screen _screen;

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
        _ball = new Ball(0, 0, 50, 50, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
        _screen = new Screen(new RenderTarget2D(GraphicsDevice, screenWidth, screenHeight));

        base.Initialize();
    }

    protected override void LoadContent()
    {
        int width = _ball.Width;
        int height = _ball.Height;

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
        _ball.Move();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        // Enable drawing to the screen
        _screen.Set();

        // draw sprites normally
        _spriteBatch.Begin();
        _spriteBatch.Draw(_ballImage, new Vector2(_ball.Coordinate.X, _ball.Coordinate.Y), Color.White);
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
