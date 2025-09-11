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

            // Bounce horizontally
            if (oldX <= 0 || oldX + _width >= _screenWidth)
            {
                _vx *= -1;
            }

            // Bounce vertically
            if (oldY <= 0 || oldY + _height >= _screenHeight)
            {
                _vy *= -1;
            }

            // Move ball
            float newX = oldX + _vx;
            float newY = oldY + _vy;

            // make sure ball stays within screen
            // makes sure ball does not go beyonf the edge of the screen
            newX = Math.Max(0, Math.Min(newX, _screenWidth - _width));
            newY = Math.Max(0, Math.Min(newY, _screenHeight - _height));

            _coordinate = new Coordinate(newX, newY, _width, _height);
        }
    }
}
