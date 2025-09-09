using DrawingLib.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace DrawingLib.Input
{
	public class CustomMouse : ICustomMouse
	{
		private MouseState _current;
		private MouseState _previous;
		public Point WindowPosition { get; }

		public static CustomMouse Instance { get; } = new CustomMouse();

		private CustomMouse()
		{
			_current = Mouse.GetState();
			_previous = _current;
		}

		public Vector2? GetScreenPosition(IScreen screen)
		{
			if (screen == null)
			{
				throw new ArgumentNullException(nameof(screen), "Screen cannot be null");
			}

			var currentPosition = WindowPosition;

			// Check that mouse position is inside screen
			if (currentPosition.X < 0 || currentPosition.Y < 0 || currentPosition.X >= screen.Width || currentPosition.Y >= screen.Height)
			{
				return null;
			}

			return new Vector2(currentPosition.X, currentPosition.Y);
		}

		public bool IsLeftButtonClicked()
		{
			return _current.LeftButton == ButtonState.Pressed && _previous.LeftButton == ButtonState.Released;
		}

		public bool IsLeftButtonDown()
		{
			return _current.LeftButton == ButtonState.Pressed;
		}

		public bool IsLeftButtonUp()
		{
			return _current.LeftButton == ButtonState.Released;
		}

		public bool IsMiddleButtonClicked()
		{
			return _current.MiddleButton == ButtonState.Pressed && _previous.MiddleButton == ButtonState.Released;
		}

		public bool IsMiddleButtonDown()
		{
			return _current.MiddleButton == ButtonState.Pressed;
		}

		public bool IsRightButtonClicked()
		{
			return _current.RightButton == ButtonState.Pressed && _previous.RightButton == ButtonState.Released;
		}

		public bool IsRightButtonDown()
		{
			return _current.RightButton == ButtonState.Pressed;
		}

		public void Update()
		{
			_previous = _current;
			_current = Mouse.GetState();
		}
	}
}