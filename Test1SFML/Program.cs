using System;
using System.Collections.Generic;
using SFML.Graphics;

namespace ComplexNumbers
{
    class Program
    {
        public static RenderWindow win;
        public static List<IShape> ShapeList;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Input x: ");
                float x = (float)Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Input y: ");
                float y = (float)Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Input root: ");
                int root = Convert.ToInt16(Console.ReadLine());

                win = new RenderWindow(new SFML.Window.VideoMode(600, 600), "Graphics");

                win.SetVerticalSyncEnabled(true);

                win.Resized += Win_Resized;
                win.KeyPressed += Win_KeyPressed;
                win.Closed += Win_Closed;
                //win.MouseButtonPressed += Win_MouseButtonPressed;

                Point z = new Point(x, y);
                List<Point> RootsList = new List<Point>();

                RootsList = Point.Root(z, root);

                Grid grid = new Grid(ref win, RootsList[0]._Ro);

                ShapeList = new List<IShape>();
                ShapeList.Add(grid);

                List<GridPoint> points = new List<GridPoint>();
                for (int i = 0; i < RootsList.Count; i++)
                {
                    GridPoint gridPoint = new GridPoint(RootsList[i]._X, RootsList[i]._Y, grid, ref win);
                    points.Add(gridPoint);
                    Circle circle = new Circle(gridPoint.Get(), 5, Color.Black, ref win);
                    ShapeList.Add(circle);
                }
                points.Add(new GridPoint(RootsList[0]._X, RootsList[0]._Y, grid, ref win));

                LineStrip lineStrip = new LineStrip(points, ref win);
                ShapeList.Add(lineStrip);

                while (win.IsOpen)
                {
                    win.Clear(Color.White);

                    win.DispatchEvents();

                    for (int i = 0; i < ShapeList.Count; i++)
                    {
                        ShapeList[i].Draw();
                    }

                    win.Display();
                }
                Console.WriteLine();
            }
        }

        private static void Win_MouseButtonPressed(object sender, SFML.Window.MouseButtonEventArgs e)
        {
            Circle circle = new Circle(e.X, e.Y, 5, Color.Black, ref win);
            Lines line = new Lines(win.Size.X / 2, win.Size.Y / 2, e.X, e.Y, Color.Black, Color.Black, ref win);

            ShapeList.Add(circle);
            ShapeList.Add(line);
        }

        private static void Win_Resized(object sender, SFML.Window.SizeEventArgs e)
        {
            //win.SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));
            win.Size = new SFML.System.Vector2u(600, 600);
        }
        private static void Win_KeyPressed(object sender, SFML.Window.KeyEventArgs e)
        {
            if (e.Code == SFML.Window.Keyboard.Key.Escape)
                win.Close();
        }

        private static void Win_Closed(object sender, EventArgs e)
        {
            win.Close();
        }
    }
}


//Circle circle = new Circle(win.Size.X / 2, win.Size.Y / 2, 3 * grid._CageSize, Color.White, ref win, 2);

/*

GridPoint gridPoint1 = new GridPoint(3, 3, grid, ref win);
GridPoint gridPoint2 = new GridPoint(0, 0, grid, ref win);
GridPoint gridPoint3 = new GridPoint(5, 4, grid, ref win);
Lines line1 = new Lines(gridPoint2.Get(), gridPoint1.Get(), Color.Black, Color.Black, ref win);
Lines line2 = new Lines(gridPoint2.Get(), gridPoint3.Get(), Color.Black, Color.Black, ref win);

Vertex[] line = new Vertex[2];
line[0] = new Vertex(new SFML.System.Vector2f(300, 0)); 
line[1] = new Vertex(new SFML.System.Vector2f(300, 600));
line[0].Color = Color.Red;
line[1].Color = Color.Red;
win.Draw(line, PrimitiveType.Lines);

Lines line1 = new Lines(0, 0, win.Size.X, win.Size.Y, Color.Red, Color.Red, ref win);
line1.Draw();

RectangleShape line = new RectangleShape(new SFML.System.Vector2f(win.Size.X, 5));
line.Rotation = 60;
win.Draw(line);

ConvexShape line = new ConvexShape();
line.SetPointCount(4);
line.SetPoint(0, new SFML.System.Vector2f(0, 0));
line.SetPoint(1, new SFML.System.Vector2f(0, win.Size.Y));
line.FillColor = Color.Red;
win.Draw(line);


CircleShape Circle = new CircleShape(5);
Circle.FillColor = Color.Black;
Circle.OutlineThickness = 5;
Circle.OutlineColor = Color.Blue;
Circle.Position = new SFML.System.Vector2f(point._X, point._Y);
win.Draw(Circle);
*/
