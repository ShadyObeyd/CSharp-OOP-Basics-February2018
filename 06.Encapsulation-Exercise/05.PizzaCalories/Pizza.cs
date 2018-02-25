using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    public const int MaxNameSize = 15;
    public const int MaxToppingsCount = 10;

    private string name;

    public string Name
    {
        get { return name; }
        private set
        {
            if (value == string.Empty || value == null || value == " " || value?.Length > MaxNameSize)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            name = value;
        }
    }

    private Dough dough;

    public Dough Dough
    {
        get { return dough; }
        set { dough = value; }
    }

    private List<Topping> toppings;

    public IReadOnlyCollection<Topping> Toppings
    {
        get { return toppings; }
        private set { value = toppings; }
    }

    public double TotalCalories
    {
        get { return GetTotalCalories(); }
    }


    public Pizza(string name)
    {
        Name = name;
        this.toppings = new List<Topping>();
    }

    public void AddTopping(Topping topping)
    {
        if (this.toppings.Count > 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
        else
        {
            this.toppings.Add(topping);
        }
    }

    private double GetTotalCalories()
    {
        double doughCalories = Dough.CalculateCalories();
        double toppingsCalories = Toppings.Sum(t => t.CalculateCalories());

        return doughCalories + toppingsCalories;
    }

    public override string ToString()
    {
        return $"{Name} - {TotalCalories:f2} Calories.";
    }
}