using SFML.Graphics;

namespace ComplexNumbers
{
    class Grid : IShape
    {
        public RenderWindow _Window { get; }
        private int _MaxSize { get; }
        public int _CageSize { get; }
        private Color _CageColor = new Color(204, 204, 204);
        float _CircleRadius { get; }
        private RenderWindow window2;

        public Grid(ref RenderWindow window, float maxSize )
        {
            _Window = window;
            window2 = window;
            _CircleRadius = maxSize;
            _MaxSize = (int)maxSize + (int)_CircleRadius * 4;

            _CageSize = (int)_Window.Size.X / _MaxSize;

            Draw();
        }

        public void Draw()
        {
            //Circle circle1 = new Circle(_Window.Size.X / 2, _Window.Size.Y / 2, 5 * _CageSize, Color.White, ref window2, 2);

            Circle circle2 = new Circle(_Window.Size.X / 2, _Window.Size.Y / 2, _CircleRadius * _CageSize, Color.White, ref window2, 2);

            for (int i = 0; i < _MaxSize; i++)
            {
                Lines line1 = new Lines(_Window.Size.X / 2 + _CageSize * i, 0, _Window.Size.X / 2 + _CageSize * i, _Window.Size.Y, _CageColor, _CageColor, ref window2); //Вертикальные линии.
                Lines line2 = new Lines(0, _Window.Size.Y / 2 + _CageSize * i, _Window.Size.X, _Window.Size.Y / 2 + _CageSize * i, _CageColor, _CageColor, ref window2); // Горизонтальные линии.
            }

            for (int i = 0; i < _MaxSize; i++)
            {
                Lines line1 = new Lines(_Window.Size.X / 2 - _CageSize * i, 0, _Window.Size.X / 2 - _CageSize * i, _Window.Size.Y, _CageColor, _CageColor, ref window2); //Вертикальные линии.
                Lines line2 = new Lines(0, _Window.Size.Y / 2 - _CageSize * i, _Window.Size.X, _Window.Size.Y / 2 - _CageSize * i, _CageColor, _CageColor, ref window2); // Горизонтальные линии.
            }

            Lines lineY = new Lines(_Window.Size.X / 2, 0, _Window.Size.X / 2, _Window.Size.Y, Color.Black, Color.Black, ref window2);
            Lines lineX = new Lines(0, _Window.Size.Y / 2, _Window.Size.X, _Window.Size.Y / 2, Color.Black, Color.Black, ref window2);
        }

    }
}
