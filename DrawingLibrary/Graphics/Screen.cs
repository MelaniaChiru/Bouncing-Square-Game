using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace DrawingLib.Graphics
{
	public class Screen : IScreen
	{
		public int Height { get; set; }
		public int Width { get; set; }
		public RenderTarget2D RenderTarget { get; set; }
		private bool _isSet = false;

		public Screen(RenderTarget2D renderTarget)
		{
			if (renderTarget == null)
			{
				throw new ArgumentNullException(nameof(renderTarget), "RenderTarget2D cannot be null");
			}

			RenderTarget = renderTarget;
			Width = renderTarget.Width;
			Height = renderTarget.Height;
		}

		public void Present(ISpritesRenderer spritesRenderer, bool textureFiltering = true)
		{
			if (spritesRenderer == null)
			{
				throw new ArgumentNullException(nameof(spritesRenderer), "SpritesRenderer cannot be null");
			}

			Rectangle destinationRectangle = CalculateDestinationRectangle();

			spritesRenderer.Begin(textureFiltering);
			spritesRenderer.End();
		}

		public void Set()
		{
			if (_isSet)
			{
				throw new Exception("Screen is already set");
			}
			RenderTarget.GraphicsDevice.SetRenderTarget(RenderTarget);
			_isSet = true;
		}

		public void UnSet()
		{
			if (!_isSet)
			{
				throw new Exception("Screen is already unset");
			}
			RenderTarget.GraphicsDevice.SetRenderTarget(null);
			_isSet = false;
		}

		public Rectangle CalculateDestinationRectangle()
		{
			// Get the current viewport dimensions
			Viewport viewport = RenderTarget.GraphicsDevice.Viewport;
			int windowWidth = viewport.Width;
			int windowHeight = viewport.Height;

			// Calculate aspect ratios
			float windowAspectRatio = (float)windowWidth / windowHeight;
			float screenAspectRatio = (float)Width / Height;

			int rectangleWith, retangleHeight;
			int X, Y;

			if (windowAspectRatio > screenAspectRatio)
			{
				// Window is wider than the screen aspect ratio
				retangleHeight = windowHeight;
				rectangleWith = (int)(retangleHeight * screenAspectRatio);
				X = (windowWidth - rectangleWith) / 2;
				Y = 0;
			}
			else
			{
				// Window is taller than the screen aspect ratio
				rectangleWith = windowWidth;
				retangleHeight = (int)(rectangleWith / screenAspectRatio);
				X = 0;
				Y = (windowHeight - retangleHeight) / 2;
			}

			return new Rectangle(X, Y, rectangleWith, retangleHeight);
		}

		public void Dispose()
		{
			RenderTarget?.Dispose();
		}
    }
}