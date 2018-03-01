using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private
{
    public List<Private> Privates { get; set; }

    public LeutenantGeneral(string id, string firstName, string lastName, double salary)
        : base(id, firstName, lastName, salary)
    {
        Privates = new List<Private>();
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