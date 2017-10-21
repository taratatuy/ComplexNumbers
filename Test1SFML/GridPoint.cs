using SFML.Graphics;

namespace ComplexNumbers
{
    class GridPoint : Point , IShape
    {
        public new float _X { get; }
        public new float _Y { get; }
        private RenderWindow window;

        public GridPoint(float x, float y, Grid grid, ref RenderWindow window) : base(x, y)
        {
            this.window = window;
            _X = grid._Window.Size.X / 2 + x * grid._CageSize;
            _Y = grid._Window.Size.Y / 2 - y * grid._CageSize;
            Draw();
        }

        public Point Get()
        {
            Point point = new Point(_X, _Y);
            return point;
        }

        public void Draw()
        {
            Circle circle = new Circle(_X, _Y, 4, Color.Black, ref window);
        }
    }
}
