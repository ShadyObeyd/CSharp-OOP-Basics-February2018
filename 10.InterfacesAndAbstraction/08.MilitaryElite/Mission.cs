using System;

public class Mission
{
    public string CodeName { get; private set; }

    private string state;

    public string State { get; private set; }

    public Mission(string codeName, string state)
    {
        CodeName = codeName;
        State = state;
    }

    public override string ToString()
    {
        return $"  Code Name: {CodeName} State: {State}";
    }
}