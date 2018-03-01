using System;
using System.Text;

public abstract class SpecialisedSoldier : Private
{
    public string Corps { get; protected set; }

    public SpecialisedSoldier(string id, string firstName, string lastName, double salary, string corps) 
        : base(id, firstName, lastName, salary)
    {
        Corps = corps;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder
            .AppendLine(base.ToString())
            .AppendLine($"Corps: {Corps}");

        return builder.ToString().TrimEnd();
    }
}