using System;

class StartUp
{
    static void Main()
    {
        string input = Console.ReadLine();

        if (input == "Square")
        {
            int lenght = int.Parse(Console.ReadLine());

            Square square = new Square(lenght);
            square.Draw();
        }
        else if (input == "Rectangle")
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());

            Rectangle rectangle = new Rectangle(width, lenght);

            rectangle.Draw();
        }
    }
}