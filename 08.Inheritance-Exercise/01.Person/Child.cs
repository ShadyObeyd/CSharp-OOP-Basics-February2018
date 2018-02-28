using System;

public class Child : Person
{
    public const int MaxChildAge = 15;
    
    public override int Age
    {
        get { return base.Age; }
        protected set
        {
            if (value > MaxChildAge)
            {
                throw new ArgumentException("Child's age must be less than 15!");
            }
            base.Age = value;
        }
    }
    public Child(string name, int age) : base(name, age)
    {

    }
}