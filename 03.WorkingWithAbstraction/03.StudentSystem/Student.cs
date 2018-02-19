public class Student
{
    private string name;
    private int age;
    private double grade;

    public double Grade
    {
        get { return grade; }
        set { grade = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Student(string name, int age, double grade)
    {
        this.Name = name;
        this.Age = age;
        this.grade = grade;
    }

    public override string ToString()
    {
        string comment = string.Empty;

        if (Grade >= 5)
        {
            comment = "Excellent student.";
        }
        else if (Grade >= 3.50 && Grade < 5.00)
        {
            comment = "Average student.";
        }
        else
        {
            comment = "Very nice person.";
        }

        return $"{Name} is {Age} years old. {comment}";
    }
}
