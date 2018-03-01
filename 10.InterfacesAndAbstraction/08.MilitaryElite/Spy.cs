using System.Text;

public class Spy : Soldier
{
    public int CodeNumber { get; set; }

    public Spy(string id, string firtsName, string lastName, int codeNumber)
        : base(id, firtsName, lastName)
    {
        CodeNumber = codeNumber;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder
            .AppendLine(base.ToString())
            .AppendLine($"Code Number: {CodeNumber}");

        return builder.ToString().TrimEnd();
    }
}