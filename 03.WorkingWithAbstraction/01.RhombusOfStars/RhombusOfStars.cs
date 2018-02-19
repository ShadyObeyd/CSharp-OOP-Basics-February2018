using System;

class RhombusOfStars
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            PrintRow(n, i);
        }

        for (int i = n - 1; i >= 1; i--)
        {
            PrintRow(n, i);
        }
    }

    static void PrintRow(int rhombusSize, int symbolCount)
    {
        Console.Write(new string(' ', rhombusSize - symbolCount));

        for (int j = 1; j <= symbolCount; j++)
        {
            Console.Write("* ");
        }
        Console.WriteLine();

    }
}
