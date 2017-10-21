using SFML.Graphics;

namespace ComplexNumbers
{
    class Lines : IShape
    {
        private float _X1 { get; set; }
        private float _Y1 { get; set; }
        private float _X2 { get; set; }
        private float _Y2 { get; set; }
        private Color _Color1 { get; }
        private Color _Color2 { get; }
        private RenderWindow _Window { get; }

        Vertex[] line = new Vertex[2];
        
        public Lines(float startPointX, float startPointY, float secondPointX, float secondPointY, Color firstColor, Color secondColor, ref RenderWindow window)
        {
            _X1 = startPointX;
            _Y1 = startPointY;
            _X2 = secondPointX;
            _Y2 = secondPointY;
            _Color1 = firstColor;
            _Color2 = secondColor;
            _Window = window;

            Draw();
        }

        public Lines(Point firstPoint, Point secondPoint, Color firstColor, Color secondColor, ref RenderWindow window)
        {
            _X1 = firstPoint._X;
            _Y1 = firstPoint._Y;
            _X2 = secondPoint._X;
            _Y2 = secondPoint._Y;
            _Color1 = firstColor;
            _Color2 = secondColor;
            _Window = window;
         
            Draw();
        }

        public void Draw()
        {
            line[0] = new Vertex(new SFML.System.Vector2f(_X1, _Y1));
            line[1] = new Vertex(new SFML.System.Vector2f(_X2, _Y2));
            line[0].Color = _Color1;
            line[1].Color = _Color2;
            _Window.Draw(line, PrimitiveType.Lines);
        }
    }
}
