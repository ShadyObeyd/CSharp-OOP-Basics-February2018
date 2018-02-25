using System;

public class Player
{
    private string name;

    public string Name
    {
        get { return name; }
        private set
        {
            if (value == string.Empty || value == null || value == " ")
            {
                throw new ArgumentException("A name should not be empty.");
            }
            name = value;
        }
    }

    private int endurance;

    public int Endurance
    {
        get { return endurance; }
        private set
        {
            ValidateStat("Endurance", value);
            endurance = value;
        }
    }

    private int sprint;

    public int Sprint
    {
        get { return sprint; }
        private set
        {
            ValidateStat("Sprint", value);
            sprint = value;
        }
    }

    private int dribble;

    public int Dribble
    {
        get { return dribble; }
        private set
        {
            ValidateStat("Dribble", value);
            dribble = value;
        }
    }

    private int passing;

    public int Passing
    {
        get { return passing; }
        private set
        {
            ValidateStat("Passing", value);
            passing = value;
        }
    }

    private int shooting;

    public int Shooting
    {
        get { return shooting; }
        private set
        {
            ValidateStat("Shooting", value);
            shooting = value;
        }
    }

    private void ValidateStat(string statName, int value)
    {
        if (value < 0 || value > 100)
        {
            throw new ArgumentException($"{statName} should be between 0 and 100.");
        }
    }

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        Name = name;
        Endurance = endurance;
        Sprint = sprint;
        Dribble = dribble;
        Passing = passing;
        Shooting = shooting;
    }
}