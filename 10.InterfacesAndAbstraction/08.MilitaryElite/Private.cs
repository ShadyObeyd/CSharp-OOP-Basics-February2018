public class Private : Soldier
{
    public double Salary { get; protected set; }

    public Private(string id, string firstName, string lastName, double salary) 
        : base(id, firstName, lastName)
    {
        Salary = salary;
    }

    public override string ToString()
    {
        return base.ToString() + $" Salary: {Salary:f2}";
    }
}