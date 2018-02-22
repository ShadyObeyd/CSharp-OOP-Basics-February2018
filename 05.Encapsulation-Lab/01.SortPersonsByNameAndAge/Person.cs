public class Person
{
    private string firstName;

    public string FirstName
    {
        get { return this.firstName; }
        set { firstName = value; }
    }

    private string lastName;

    public string LastName
    {
        get { return this.lastName; }
        set { lastName = value; }
    }

    private int age;

    public int Age
    {
        get { return this.age; }
        set { age = value; }
    }

    public Person(string firstName, string lastName, int age)
    {
        this.firstName = firstName;
        this.LastName = lastName;
        this.age = age;
    }

    public override string ToString()
    {
        return $"{firstName} {lastName} is {age} years old.";
    }
}