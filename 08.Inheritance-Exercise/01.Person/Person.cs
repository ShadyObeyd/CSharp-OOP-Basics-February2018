using System;

public class Person
{
    public const int MinNameLenght = 3;

    private string name;

    public string Name
    {
        get { return this.name; }
        protected set
        {
            if (value?.Length < MinNameLenght)
            {
                throw new ArgumentException("Name's length should not be less than 3 symbols!");
            }
            name = value;
        }
    }

    private int age;

    public virtual int Age
    {
        get { return this.age; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Age must be positive!");
            }
            this.age = value;
        }
    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}";
    }
}