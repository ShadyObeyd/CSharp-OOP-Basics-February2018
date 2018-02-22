using System;
class StartUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Team team = new Team("SoftUni");

        for (int i = 0; i < n; i++)
        {
            string[] playerTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string firstName = playerTokens[0];
            string lastName = playerTokens[1];
            int age = int.Parse(playerTokens[2]);
            decimal salary = decimal.Parse(playerTokens[3]);

            team.AddPlayer(new Person(firstName, lastName, age, salary));
        }

        Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
        Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
    }
}