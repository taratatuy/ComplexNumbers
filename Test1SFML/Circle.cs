using SFML.Graphics;

namespace ComplexNumbers
{
    class Circle : IShape
    {
        private Point _Point { get; set; }
        private float _X { get; set; }
        private float _Y { get; set; }
        private float _Radius { get; set; }
        private Color _Color1 { get; }
        private Color _Color2 { get; }
        private int _BorderSize { get; }
        private RenderWindow _Window;

        public Circle(float x, float y, float r, Color color1, ref RenderWindow window, int borderSize = 0)
        {
            _X = x;
            _Y = y;
            _Radius = r;
            _Color1 = color1;
            _BorderSize = borderSize;
            _Window = window;

            Draw();
        }

        public Circle(Point point, float r, Color color1, ref RenderWindow window, int borderSize = 0)
        {
            _Point = point;
            _X = _Point._X;
            _Y = _Point._Y;
            _Radius = r;
            _Color1 = color1;
            _BorderSize = borderSize;
            _Window = window;

            Draw();
        }

        public void Draw()
        {
            CircleShape Circle = new CircleShape(_Radius);
            Circle.FillColor = _Color1;
            Circle.OutlineThickness = _BorderSize;
            Circle.OutlineColor = Color.Blue;
            Circle.Position = new SFML.System.Vector2f(_X - _Radius, _Y - _Radius);
            _Window.Draw(Circle);
        }
    }
}
