public abstract class Animal
{
    public Animal(string name, double weight)
    {
        Name = name;
        Weight = weight;
    }

    public string Name { get; protected set; }

    public double Weight { get; protected set; }

    public int FoodEaten { get; protected set; }

    public abstract void EatFood(Food food);

    public virtual string AskForFood()
    {
        return "Sound";
    }
}