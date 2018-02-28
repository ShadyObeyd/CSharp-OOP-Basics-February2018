public class Kitten : Cat
{
    public Kitten(string name, string age, string gender) : base(name, age, gender)
    {

    }

    public override string Gender
    {
        get { return "Female"; }
    }

    public override string ProduceSound()
    {
        return "Meow";
    }
}