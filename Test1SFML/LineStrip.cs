using System.Collections.Generic;
using SFML.Graphics;

namespace ComplexNumbers
{
    class LineStrip : IShape
    {
        List<GridPoint> _ListPoints { get; }
        RenderWindow _Window { get; }


        public LineStrip(List<GridPoint> listPoints, ref RenderWindow window)
        {
            _ListPoints = listPoints;
            _Window = window;
        }

        public void Draw()
        {
            Vertex[] lineStrip = new Vertex[_ListPoints.Count];

            for (int i = 0; i < _ListPoints.Count; i++)
            {
                lineStrip[i] = new Vertex(new SFML.System.Vector2f(_ListPoints[i]._X, _ListPoints[i]._Y));
                lineStrip[i].Color = Color.Black;
            }
            _Window.Draw(lineStrip, PrimitiveType.LinesStrip);

        }
    }
}
