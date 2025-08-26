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

        public Coordinate Coordinate
        {
            get { return _coordinate; }
            set { _coordinate = value; }
        }

        public Ball(float x, float y)
        {
            _coordinate = new Coordinate(x, y);
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
