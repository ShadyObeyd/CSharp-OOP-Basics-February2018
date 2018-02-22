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

    private decimal salary;

    public decimal Salary
    {
        get { return salary; }
        set { salary = value; }
    }


    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.salary = salary;
    }

    public void IncreaseSalary(decimal percentage)
    {
        if (this.age > 30)
        {
            this.salary += this.salary * (percentage / 100);
        }
        else
        {
            this.salary += this.salary * (percentage / 200);
        }
    }

    public override string ToString()
    {
        return $"{firstName} {lastName} receives {salary:f2} leva.";
    }
}