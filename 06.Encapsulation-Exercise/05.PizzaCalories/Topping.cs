using System;

public class Topping
{
    public const int MinGrams = 1;
    public const int MaxGrams = 50;

    private string type;

    public string Type
    {
        get { return type; }
        private set
        {
            if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            type = value;
        }
    }

    private int weight;

    public int Weight
    {
        get { return weight; }
        private set
        {
            if (value < MinGrams || value > MaxGrams)
            {
                throw new ArgumentException($"{Type} weight should be in the range [1..50].");
            }
            weight = value;
        }
    }

    public Topping(string type, int weight)
    {
        Type = type;
        Weight = weight;
    }

    public double CalculateCalories()
    {
        double typeModifier = 0;

        switch (Type.ToLower())
        {
            case "meat":
                typeModifier = 1.2;
                break;
            case "veggies":
                typeModifier = 0.8;
                break;
            case "cheese":
                typeModifier = 1.1;
                break;
            case "sauce":
                typeModifier = 0.9;
                break;
        }

        return (2.0 * weight) * typeModifier;
    }
}