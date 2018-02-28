using System;
using System.Text;

public class Human
{
    private string firstName;

    public string FirstName
    {
        get { return firstName; }
        protected set
        {
            ValidateName(value, "firstName", 4);
            firstName = value;
        }
    }

    private string lastName;

    public string LastName
    {
        get { return lastName; }
        protected set
        {
            ValidateName(value, "lastName", 3);
            lastName = value;
        }
    }

    public Human(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine($"First Name: {FirstName}");
        builder.AppendLine($"Last Name: {LastName}");

        return builder.ToString().TrimEnd();
    }

    private void ValidateName(string value, string argument, int MinNameLenght)
    {
        if (!char.IsUpper(value[0]))
        {
            throw new ArgumentException($"Expected upper case letter! Argument: {argument}");
        }
        else if (value?.Length < MinNameLenght)
        {
            throw new ArgumentException($"Expected length at least {MinNameLenght} symbols! Argument: {argument}");
        }
    }
}