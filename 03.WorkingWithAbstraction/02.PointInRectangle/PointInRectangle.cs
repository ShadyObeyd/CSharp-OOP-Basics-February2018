using System;

class PointInRectangle
{
    static void Main()
    {
        Rectangle rectangle = new Rectangle(Console.ReadLine());

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Point point = new Point(Console.ReadLine());

            Console.WriteLine(rectangle.Contains(point));
        }
    }
}