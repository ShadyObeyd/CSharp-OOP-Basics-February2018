using System;

public class Mouse : Mammal
{
    public Mouse(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
    {

    }

    public override string AskForFood()
    {
        return "Squeak";
    }

    public override void EatFood(Food food)
    {
        if (food is Vegetable || food is Fruit)
        {
            FoodEaten += food.Quantity;
            Weight += food.Quantity * (0.1);
        }
        else
        {
            Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
        }
    }

    public override string ToString()
    {
        return $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}

