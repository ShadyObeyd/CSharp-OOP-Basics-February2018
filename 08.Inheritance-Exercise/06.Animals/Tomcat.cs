public class Tomcat : Cat
{
    public Tomcat(string name, string age, string gender) : base(name, age, gender)
    {

    }

    public override string Gender
    {
        get { return "Male"; }
    }

    public override string ProduceSound()
    {
        return "MEOW";
    }
}