using System;
using System.Linq;

class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Point(string input)
    {
        int[] coordinates = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        X = coordinates[0];
        Y = coordinates[1];
    }
}