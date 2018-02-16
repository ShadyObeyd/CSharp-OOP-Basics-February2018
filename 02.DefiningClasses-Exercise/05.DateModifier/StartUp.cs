using System;

class StartUp
{
    static void Main()
    {
        string firstDate = Console.ReadLine();
        string secondDate = Console.ReadLine();

        DateModifier modifier = new DateModifier();

        int diff = modifier.CalculateDifference(firstDate, secondDate);

        Console.WriteLine(diff);
    }
}