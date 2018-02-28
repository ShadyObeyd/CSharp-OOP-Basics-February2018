using System;
using System.Text;
using System.Text.RegularExpressions;

public class Animal
{
    private string name;

    public string Name
    {
        get { return name; }
        protected set
        {
            if (value == string.Empty || value == null || value == " ")
            {
                ThrowException();
            }
            name = value;
        }
    }

    private string age;

    public string Age
    {
        get { return age; }
        protected set
        {
            Regex pattern = new Regex(@"^\d+$");

            if (!pattern.IsMatch(value))
            {
                ThrowException();
            }
            age = value;
        }
    }

    private string gender;

    public virtual string Gender
    {
        get { return gender; }
        protected set
        {
            if (!(value.ToLower() == "male") && !(value.ToLower() == "female"))
            {
                ThrowException();
            }
            gender = value;
        }
    }

    public Animal(string name, string age, string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder
            .AppendLine(GetType().Name)
            .AppendLine($"{Name} {int.Parse(Age)} {Gender}")
            .AppendLine(ProduceSound());

        return builder.ToString().TrimEnd();
    }

    public virtual string ProduceSound()
    {
        return "Not implemented!";
    }
    private void ThrowException()
    {
        throw new ArgumentException("Invalid input!");
    }
}