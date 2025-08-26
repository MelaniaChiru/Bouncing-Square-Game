using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBackend
{
    public class Ball
    {
        private Coordinate _coordinate;
        private int _width;
        private int _height;
        private int _screenWidth;
        private int _ScreenHeight;

        public int Width
        {
            get { return _width; }
        }

        public int Height
        {
            get { return _height; }
        }

        public Coordinate Coordinate
        {
            get { return _coordinate; }
            set { _coordinate = value; }
        }

        public Ball(float x, float y, int width, int height, int screenWidth, int screenHeight)
        {
            _coordinate = new Coordinate(x, y);
            _width = width;
            _height = height;
            _screenWidth = screenWidth;
            _ScreenHeight = screenHeight;
        }

        public void Move()
        {
            float oldX = _coordinate.X;
            float oldY = _coordinate.Y;

            float newX = oldX + 1;
            float newY = oldY + 1;

            _coordinate = new Coordinate(newX, newY);
        }
    }
}
