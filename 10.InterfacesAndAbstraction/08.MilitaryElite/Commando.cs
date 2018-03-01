using System.Collections.Generic;
using System.Text;

public class Commando : SpecialisedSoldier
{
    public List<Mission> Missions { get; set; }

    public Commando(string id, string firstName, string lastName, double salary, string corps) 
        : base (id, firstName, lastName, salary, corps)
    {
        Missions = new List<Mission>();
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder
            .AppendLine(base.ToString())
            .AppendLine("Missions:");

        foreach (Mission mission in Missions)
        {
            builder.AppendLine(mission.ToString());
        }

        return builder.ToString().TrimEnd();
    }
}