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
        private int _screenHeight;
        private int _vx;
        private int _vy;

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
            _coordinate = new Coordinate(x, y, _width, _height);
            _width = width;
            _height = height;
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
            _vx = 2;
            _vy = 2;
        }

        public void Move()
        {
            float oldX = _coordinate.X;
            float oldY = _coordinate.Y;

            // checks to make sure ball stays in frame
            if (_coordinate.X + _width <= 0 || _coordinate.X + _width > _screenWidth)
            {
                _vx = _vx * -1;
            }

            if (_coordinate.Y + _height <= 0 || _coordinate.Y + _height > _screenHeight)
            {
                _vy = _vy * -1;
            }

            float newX = oldX + _vx;
            float newY = oldY + _vy;

            _coordinate = new Coordinate(newX, newY, _width, _height);
        }
    }
}
