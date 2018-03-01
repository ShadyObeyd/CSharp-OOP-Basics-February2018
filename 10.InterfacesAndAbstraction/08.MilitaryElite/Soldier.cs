abstract public class Soldier
{
    public string Id { get; protected set; }
    public string FirstName { get; protected set; }
    public string LastName { get; protected set; }

    public Soldier(string id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
    {
        return $"Name: {FirstName} {LastName} Id: {Id}";
    }
}