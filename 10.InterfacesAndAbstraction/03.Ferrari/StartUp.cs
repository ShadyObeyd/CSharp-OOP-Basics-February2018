using System;

class StartUp
{
    static void Main()
    {
        string driverName = Console.ReadLine();

        Ferrari ferrari = new Ferrari("488-Spider", driverName);

        Console.WriteLine(ferrari);
    }
}