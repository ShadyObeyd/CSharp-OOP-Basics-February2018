using System;
using System.Collections.Generic;
using System.Linq;

class RectangleIntersection
{
    static void Main()
    {
        int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        List<Rectangle> rectangles = new List<Rectangle>();

        int rectanclesCount = input[0];
        int intersectionChecks = input[1];

        for (int i = 0; i < rectanclesCount; i++)
        {
            string[] rectangleTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string id = rectangleTokens[0];
            double width = double.Parse(rectangleTokens[1]);
            double height = double.Parse(rectangleTokens[2]);
            double x = double.Parse(rectangleTokens[3]);
            double y = double.Parse(rectangleTokens[4]);

            Rectangle rectangle = new Rectangle(id, width, height, x, y);

            rectangles.Add(rectangle);
        }

        for (int i = 0; i < intersectionChecks; i++)
        {
            string[] rectanglesIds = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string firstRectangleId = rectanglesIds[0];
            string secondRectangleId = rectanglesIds[1];

            Rectangle firstRectangle = rectangles.Where(r => r.Id == firstRectangleId).FirstOrDefault();
            Rectangle secondRectangle = rectangles.Where(r => r.Id == secondRectangleId).FirstOrDefault();

            Console.WriteLine(firstRectangle.Intersects(secondRectangle).ToString().ToLower());
        }
    }
}

