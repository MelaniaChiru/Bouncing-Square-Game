using Microsoft.Xna.Framework.Input;

namespace DrawingLib.Input
{
	public class CustomKeyboard : ICustomKeyboard
	{
		private KeyboardState _current;
		private KeyboardState _previous;

		public static CustomKeyboard Instance { get; } = new CustomKeyboard();

		private CustomKeyboard()
		{
			_current = Keyboard.GetState();
			_previous = _current;
		}

		public bool IsKeyClicked(Keys key)
		{
			return _current.IsKeyDown(key) && !_previous.IsKeyDown(key);
		}

		public bool IsKeyDown(Keys key)
		{
			return _current.IsKeyDown(key);
		}

		public void Update()
		{
			_previous = _current;
			_current = Keyboard.GetState();
		}
	}
}