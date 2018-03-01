public class Repair
{
    public string Name { get; private set; }
    public int HoursWorked { get; private set; }

    public Repair(string name, int hoursWorked)
    {
        Name = name;
        HoursWorked = hoursWorked;
    }

    public override string ToString()
    {
        return $"  Part Name: {Name} Hours Worked: {HoursWorked}";
    }
}