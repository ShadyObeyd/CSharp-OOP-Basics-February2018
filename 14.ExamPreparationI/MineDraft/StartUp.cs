using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        DraftManager manager = new DraftManager();

        string input = Console.ReadLine();

        while (input != "Shutdown")
        {
            string[] inputTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<string> arguments = inputTokens.Skip(1).ToList();

            switch (inputTokens[0])
            {
                case "RegisterHarvester":
                    Console.WriteLine(manager.RegisterHarvester(arguments));
                    break;
                case "RegisterProvider":
                    Console.WriteLine(manager.RegisterProvider(arguments));
                    break;
                case "Day":
                    Console.WriteLine(manager.Day());
                    break;
                case "Mode":
                    Console.WriteLine(manager.Mode(arguments));
                    break;
                case "Check":
                    Console.WriteLine(manager.Check(arguments));
                    break;
            }
            input = Console.ReadLine();
        }
        Console.WriteLine(manager.ShutDown());
    }
}