public class Cat : Feline
{
    public Cat(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion, breed)
    {

    }

    public override string AskForFood()
    {
        return "Meow";
    }

    public override void EatFood(Food food)
    {
        if (food is Vegetable || food is Meat)
        {
            FoodEaten += food.Quantity;
            Weight += (food.Quantity * 0.3);
        }
    }
}