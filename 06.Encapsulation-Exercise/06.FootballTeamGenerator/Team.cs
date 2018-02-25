using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private string name;

    public string Name
    {
        get { return name; }
        set
        {
            if (value == string.Empty || value == null || value == " ")
            {
                throw new ArgumentException("A name should not be empty.");
            }
            name = value;
        }
    }


    private List<Player> players;

    public IReadOnlyCollection<Player> Players
    {
        get { return players; }
    }

    public int Rating { get; set; }

    public Team(string name)
    {
        Name = name;
        players = new List<Player>();
        Rating = 0;
    }

    public void AddPlayer(Player player)
    {
        players.Add(player);
    }

    public void RemovePlayer(Player player)
    {
        players.Remove(player);
    }
}