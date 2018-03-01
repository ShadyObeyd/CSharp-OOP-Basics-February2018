using System;

class StartUp
{
    static void Main()
    {
        string[] numbers = ReadInput();
        string[] sites = ReadInput();

        Smarthphone phone = new Smarthphone(numbers, sites);

        phone.Call();
        phone.Browse();
    }

    private static string[] ReadInput()
    {
        return Console.ReadLine().Split(' ');
    }
}