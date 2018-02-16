using System;

public class Rectangle
{
    public int Lenght { get; set; }
    public int Width { get; set; }

    public Rectangle(int width, int lenght)
    {
        this.Width = width;
        this.Lenght = lenght;
    }

    public void Draw()
    {
        Console.WriteLine($"|{new string('-', this.Width)}|");
        for (int i = 0; i < this.Lenght - 2; i++)
        {
            Console.WriteLine($"|{new string(' ', this.Width)}|");
        }
        Console.WriteLine($"|{new string('-', this.Width)}|");
    }
}

