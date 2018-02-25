using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        string input = Console.ReadLine();

        List<Team> teams = new List<Team>();

        while (input != "END")
        {
            string[] inputTokens = input.Split(';', StringSplitOptions.RemoveEmptyEntries);

            switch (inputTokens[0])
            {
                case "Team":
                    string teamName = inputTokens[1];
                    try
                    {
                        Team team = new Team(teamName);
                        teams.Add(team);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "Add":
                    AddPlayer(inputTokens, teams);
                    break;
                case "Remove":
                    RemovePlayer(inputTokens, teams);
                    break;
                case "Rating":
                    GetRating(inputTokens, teams);
                    break;
            }
            input = Console.ReadLine();
        }
    }

    private static void GetRating(string[] inputTokens, List<Team> teams)
    {
        string teamName = inputTokens[1];

        if (TeamExists(teams, teamName))
        {
            Team team = GetTeam(teams, teamName);

            int rating = team.Rating;
            foreach (Player player in team.Players)
            {
                int playerAverage = (int)Math.Round((double)(player.Endurance + player.Dribble + player.Sprint + player.Passing + player.Shooting) / 5);
                rating += playerAverage;
            }
            Console.WriteLine($"{teamName} - {rating}");
        }
        else
        {
            PrintMissingTeamMsg(teamName);
        }
    }

    private static void RemovePlayer(string[] inputTokens, List<Team> teams)
    {
        string teamName = inputTokens[1];
        string playerName = inputTokens[2];

        if (TeamExists(teams, teamName))
        {
            Team team = GetTeam(teams, teamName);

            if (team.Players.Any(p => p.Name == playerName))
            {
                Player player = team.Players.FirstOrDefault(p => p.Name == playerName);

                team.RemovePlayer(player);
            }
            else
            {
                Console.WriteLine($"Player {playerName} is not in {teamName} team.");
            }
        }
        else
        {
            PrintMissingTeamMsg(teamName);
        }
    }

    private static void AddPlayer(string[] inputTokens, List<Team> teams)
    {
        string teamName = inputTokens[1];
        string playerName = inputTokens[2];
        int endurance = int.Parse(inputTokens[3]);
        int sprint = int.Parse(inputTokens[4]);
        int dribble = int.Parse(inputTokens[5]);
        int passing = int.Parse(inputTokens[6]);
        int shooting = int.Parse(inputTokens[7]);

        if (TeamExists(teams, teamName))
        {
            Team team = GetTeam(teams, teamName);

            try
            {
                team.AddPlayer(new Player(playerName, endurance, sprint, dribble, passing, shooting));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            PrintMissingTeamMsg(teamName);
        }
    }

    private static Team GetTeam(List<Team> teams, string teamName)
    {
        return teams.FirstOrDefault(t => t.Name == teamName);
    }

    private static bool TeamExists(List<Team> teams, string teamName)
    {
        return teams.Any(t => t.Name == teamName);
    }

    private static void PrintMissingTeamMsg(string teamName)
    {
        Console.WriteLine($"Team {teamName} does not exist.");
    }
}