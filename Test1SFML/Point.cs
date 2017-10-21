using System;
using System.Collections.Generic;

namespace ComplexNumbers
{
    class Point 
    {
        public float _X { get; private set; }
        public float _Y { get; private set; }
        public float _Ro { get; private set; }
        double _Fi { get; set; }

        Point() { }

        public Point(float x, float y)
        {
            _X = x;
            _Y = y;

            _Ro = (float)Math.Sqrt(_X * _X + _Y * _Y);
            _Fi = Math.Asin(_Y / _Ro);
        }

        public static List<Point> Root(Point z1, int n)
        {
            List<Point> RootPoints = new List<Point>();

            for (int i = 0; i < n; i++)
            {
                Point z = new Point();

                z._Ro = (float)Math.Pow(z1._Ro, 1 / (double)n);
                z._Fi = (z1._Fi + (2 * Math.PI * i)) / n;
                z._X = (float)(z._Ro * Math.Cos(z._Fi));
                z._Y = (float)(z._Ro * Math.Sin(z._Fi));

                RootPoints.Add(z);
            }

            return RootPoints;
        }

    }
}
