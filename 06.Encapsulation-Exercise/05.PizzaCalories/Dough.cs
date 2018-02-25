using System;

public class Dough
{
    public const string DoughMessage = "Invalid type of dough.";
    public const int MinGrams = 1;
    public const int MaxGrams = 200;

    private string flourType;

    public string FlourType
    {
        get { return flourType; }
        private set
        {
            if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
            {
                throw new ArgumentException(DoughMessage);
            }
            flourType = value;
        }
    }

    private string bakingTechnique;

    public string BakingTechnique
    {
        get { return bakingTechnique; }
        private set
        {
            if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
            {
                throw new ArgumentException(DoughMessage);
            }
            bakingTechnique = value;
        }
    }

    private int wight;

    public int Weight
    {
        get { return wight; }
        private set
        {
            if (value < MinGrams || value > MaxGrams)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            wight = value;
        }
    }

    public Dough(string flourType, string bakingTechnique, int weight)
    {
        FlourType = flourType;
        BakingTechnique = bakingTechnique;
        Weight = weight;
    }

    public double CalculateCalories()
    {
        double flourModifier = 0;
        double bakingModifier = 0;

        switch (FlourType.ToLower())
        {
            case "white":
                flourModifier = 1.5;
                break;
            case "wholegrain":
                flourModifier = 1.0;
                break;
        }

        switch (BakingTechnique.ToLower())
        {
            case "crispy":
                bakingModifier = 0.9;
                break;
            case "chewy":
                bakingModifier = 1.1;
                break;
            case "homemade":
                bakingModifier = 1.0;
                break;
        }

        return (2.0 * wight) * flourModifier * bakingModifier;
    }
}