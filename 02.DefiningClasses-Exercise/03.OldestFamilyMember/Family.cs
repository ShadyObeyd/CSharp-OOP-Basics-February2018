using System.Collections.Generic;
using System.Linq;

public class Family
{
    private List<Person> people = new List<Person>();

    public List<Person> People
    {
        get { return people; }
        set { people = value; }
    }

    public void AddMember(Person member)
    {
        this.people.Add(member);
    }

    public int GetOldestMember()
    {
        return this.people.Max(p => p.Age);
    }
}

