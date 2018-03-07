public abstract class Bird : Animal
{
    public Bird(string name, double weight, double wingSize) 
        : base(name, weight)
    {
        WingSize = wingSize;
    }

    public double WingSize { get; protected set; }

    public override string ToString()
    {
        return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
    }
}