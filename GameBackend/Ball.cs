using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBackend
{
    internal class Ball
    {
        private Coordinate _coordinate;

        public Coordinate Coordinate
        {
            get { return _coordinate; }
            set { _coordinate = value; }
        }

        public Ball(int x, int y)
        {
            _coordinate = new Coordinate(x, y);
        }

        public Move()
        {
            float oldX = _coordinate.x;
            float oldY = _coordinate.y;

            float newX = oldX + 1;
            float newY = oldY + 1;

            _coordinate = new Coordinate(newX, newY);
        }
    }
}
