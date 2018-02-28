using System;

public class Rectangle : IDrawable
{
    public int Width { get; private set; }
    public int Height { get; private set; }

    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public void Draw()
    {
        PrintTopAndBot();
        for (int i = 0; i < Height - 2; i++)
        {
            Console.WriteLine("*" + new string(' ', Width - 2) + "*");
        }
        PrintTopAndBot();
    }

    private void PrintTopAndBot()
    {
        Console.WriteLine(new string('*', Width));
    }
}