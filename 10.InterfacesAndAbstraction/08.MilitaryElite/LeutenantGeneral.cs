using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private
{
    public List<Soldier> Privates { get; set; }

    public LeutenantGeneral(string id, string firstName, string lastName, double salary)
        : base(id, firstName, lastName, salary)
    {
        Privates = new List<Soldier>();
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder
            .AppendLine(base.ToString())
            .AppendLine("Privates:");

        foreach (Private privatee in Privates)
        {
            builder.AppendLine(privatee.ToString());
        }

        return builder.ToString().TrimEnd();
    }
}