using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private RaceTower tower;

    public Engine(RaceTower tower)
    {
        this.tower = tower;
    }

    internal void Run()
    {
        while (true)
        {

            string[] commandTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string commandType = commandTokens[0];

            List<string> methodArgs = commandTokens.Skip(1).ToList();

            switch (commandType)
            {
                case "RegisterDriver":
                    this.tower.RegisterDriver(methodArgs);
                    break;
                case "Leaderboard":
                    Console.WriteLine(this.tower.GetLeaderboard());
                    break;
                case "CompleteLaps":
                    string result = this.tower.CompleteLaps(methodArgs);
                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        Console.WriteLine(result);
                    }
                    break;
                case "Box":
                    this.tower.DriverBoxes(methodArgs);
                    break;
                case "ChangeWeather":
                    this.tower.ChangeWeather(methodArgs);
                    break;
                default:
                    Console.WriteLine("INVALID COMMAND");
                    break;
            }

            if (this.tower.raceOver)
            {
                break;
            }
        }
    }
}