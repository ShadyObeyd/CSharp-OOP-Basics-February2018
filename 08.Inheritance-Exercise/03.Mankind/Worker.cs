using System;
using System.Text;

public class Worker : Human
{
    public const decimal MinWeekSalary = 10m;
    public const decimal MinHours = 1.0m;
    public const decimal MaxHours = 12.0m;

    private decimal weekSalary;

    public decimal WeekSalary
    {
        get { return weekSalary; }
        protected set
        {
            if (value <= MinWeekSalary)
            {
                throw new ArgumentException(GetErrotMessage("weekSalary"));
            }
            weekSalary = value;
        }
    }

    private decimal hoursPerDay;

    public decimal HoursPerDay
    {
        get { return hoursPerDay; }
        protected set
        {
            if (value < MinHours || value > MaxHours)
            {
                throw new ArgumentException(GetErrotMessage("workHoursPerDay"));
            }
            hoursPerDay = value;
        }
    }

    public decimal SalaryPerHour
    {
        get { return this.GetSalaryPerHour(); }
    }

    public Worker(string firstName, string lastName, decimal weekSalary, decimal hoursPerDay) : base(firstName, lastName)
    {
        WeekSalary = weekSalary;
        HoursPerDay = hoursPerDay;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine(base.ToString());
        builder.AppendLine($"Week Salary: {WeekSalary:f2}");
        builder.AppendLine($"Hours per day: {HoursPerDay:f2}");
        builder.AppendLine($"Salary per hour: {SalaryPerHour:f2}");

        return builder.ToString().TrimEnd();
    }

    private string GetErrotMessage(string argument)
    {
        return $"Expected value mismatch! Argument: {argument}";
    }

    private decimal GetSalaryPerHour()
    {
        decimal salaryPerDay = WeekSalary / 5.0m;

        return salaryPerDay / HoursPerDay;
    }
}