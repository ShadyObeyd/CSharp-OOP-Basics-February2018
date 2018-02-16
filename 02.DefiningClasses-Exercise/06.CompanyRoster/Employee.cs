public class Employee
{
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public string Department { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }

    public Employee()
    {
        this.Name = string.Empty;
        this.Salary = 0m;
        this.Department = string.Empty;
        this.Email = "n/a";
        this.Age = -1;
    }

    public Employee(string name, decimal salary, string department) : this()
    {
        this.Name = name;
        this.Salary = salary;
        this.Department = department;
    }

    public Employee(string name, decimal salary, string department, string email) : this(name, salary, department)
    {
        this.Email = email;
    }

    public Employee(string name, decimal salary, string department, string email, int age) : this(name, salary, department, email)
    {
        this.Age = age;
    }
}