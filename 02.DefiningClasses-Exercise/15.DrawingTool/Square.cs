using System;

class Square
{
    public int Lenght { get; set; }

    public Square(int lenght)
    {
        this.Lenght = lenght;
    }

    public void Draw()
    {
        Console.WriteLine($"|{new string('-', this.Lenght)}|");

        for (int i = 0; i < this.Lenght - 2; i++)
        {
            Console.WriteLine($"|{new string(' ', this.Lenght)}|");
        }
        Console.WriteLine($"|{new string('-', this.Lenght)}|");
    }
}