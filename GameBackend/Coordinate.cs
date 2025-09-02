using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBackend
{
    public class Coordinate
    {
        private float _x;
        private float _y;

        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public Coordinate(float x, float y, int ballWith, int ballHeight)
        {
            if (x < 0 - ballWith)
            {
                throw new ArgumentException("x coordinate cannot be less than 0");
            }

            if (y < 0 - ballHeight)
            {
                throw new ArgumentException("y coordinate cannot be less than 0");
            }
            _x = x;
            _y = y;
        }

    }
}
