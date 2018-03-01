using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier
{
    public List<Repair> Repairs { get; set; }

    public Engineer(string id, string firstName, string lastName, double salary, string corps)
        : base(id, firstName, lastName, salary, corps)
    {
        Repairs = new List<Repair>();
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder
            .AppendLine(base.ToString())
            .AppendLine("Repairs:");

        foreach (Repair repair in Repairs)
        {
            builder.AppendLine(repair.ToString());
        }

        return builder.ToString().TrimEnd();
    }
}