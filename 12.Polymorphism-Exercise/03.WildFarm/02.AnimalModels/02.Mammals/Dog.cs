using System;

public class Dog : Mammal
{
    public Dog(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
    {

    }

    public override string AskForFood()
    {
        return "Woof!";
    }

    public override void EatFood(Food food)
    {
        if (food is Meat)
        {
            FoodEaten += food.Quantity;
            Weight += (food.Quantity * 0.4);
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