using System;
using System.Text;
using System.Text.RegularExpressions;

public class Student : Human
{
    private string facultyNumber;

    public string FacultyNumber
    {
        get { return facultyNumber; }
        protected set
        {
            if (!IsValid(value))
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            facultyNumber = value;
        }
    }

    public Student(string firstName, string lastName, string facultyNumber) : base(firstName, lastName)
    {
        FacultyNumber = facultyNumber;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine(base.ToString());
        builder.AppendLine($"Faculty number: {FacultyNumber}");

        return builder.ToString().TrimEnd();
    }

    private bool IsValid(string value)
    {
        Regex pattern = new Regex(@"^[A-Za-z0-9]{5,10}$");

        if (pattern.IsMatch(value))
        {
            return true;
        }
        return false;
    }
}