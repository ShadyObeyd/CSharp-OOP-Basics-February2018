public class Hen : Bird
{
    public Hen(string name, double weight, double wingSize) 
        : base(name, weight, wingSize)
    {

    }

    public override void EatFood(Food food)
    {
        FoodEaten += food.Quantity;
        Weight += (food.Quantity * 0.35);
    }

    public override string AskForFood()
    {
        return "Cluck";
    }
}