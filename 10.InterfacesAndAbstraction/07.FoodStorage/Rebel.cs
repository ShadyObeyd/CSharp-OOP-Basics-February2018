using System;

public class Rebel : IBuyer
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Group { get; set; }
    public int Food { get; set; }

    public Rebel(string name, int age, string group)
    {
        Name = name;
        Age = age;
        Group = group;
    }

    public void BuyFood()
    {
        Food += 5;
    }
}