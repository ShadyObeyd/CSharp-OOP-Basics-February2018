using System;
public class Owl : Bird
{
    public Owl(string name, double weight, double wingSize)
        : base(name, weight, wingSize)
    {

    }

    public override string AskForFood()
    {
        return "Hoot Hoot";
    }

    public override void EatFood(Food food)
    {
        if (food is Meat)
        {
            FoodEaten += food.Quantity;
            Weight += (food.Quantity * 0.25);
        }
        else
        {
            Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}