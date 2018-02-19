using System;
using System.Linq;

class Rectangle
{
    public Point TopLeft { get; set; }
    public Point BottomRight { get; set; }

    public Rectangle(string input)
    {
        int[] coordinates = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        TopLeft = new Point(coordinates[0], coordinates[1]);
        BottomRight = new Point(coordinates[2], coordinates[3]);
    }

    public bool Contains(Point point)
    {
        bool xIsContained = TopLeft.X <= point.X && BottomRight.X >= point.X;
        bool yIsContained = TopLeft.Y <= point.Y && BottomRight.Y >= point.Y;

        return xIsContained && yIsContained;
    }
}