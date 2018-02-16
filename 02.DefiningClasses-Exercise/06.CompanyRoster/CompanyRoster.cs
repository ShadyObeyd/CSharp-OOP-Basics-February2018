using System;
using System.Collections.Generic;
using System.Linq;

class CompanyRoster
{
    static void Main()
    {
        Dictionary<string, List<decimal>> departments = new Dictionary<string, List<decimal>>();

        int n = int.Parse(Console.ReadLine());

        List<Employee> employees = new List<Employee>();

        for (int i = 0; i < n; i++)
        {
            string[] employeeTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = employeeTokens[0];
            decimal salary = decimal.Parse(employeeTokens[1]);
            string position = employeeTokens[2];
            string department = employeeTokens[3];

            Employee employee = new Employee();

            employee.Name = name;
            employee.Salary = salary;
            employee.Department = department;

            if (employeeTokens.Length == 5)
            {
                if (employeeTokens[4].Contains("@"))
                {

                    string email = employeeTokens[4];
                    employee.Email = email;
                }
                else
                {
                    int age = int.Parse(employeeTokens[4]);
                    employee.Age = age;
                }
            }
            else if (employeeTokens.Length == 6)
            {
                string email = employeeTokens[4];
                int age = int.Parse(employeeTokens[5]);

                employee.Email = email;
                employee.Age = age;
            }

            if (!departments.ContainsKey(department))
            {
                departments.Add(department, new List<decimal>());
            }
            departments[department].Add(salary);

            employees.Add(employee);
        }

        string wantedDepartment = GetWantedDepartment(departments);

        Console.WriteLine($"Highest Average Salary: {wantedDepartment}");

        foreach (Employee employee in employees.Where(e => e.Department == wantedDepartment).OrderByDescending(e => e.Salary))
        {
            string name = employee.Name;
            decimal salary = employee.Salary;
            string email = employee.Email;
            int age = employee.Age;

            Console.WriteLine($"{name} {salary:f2} {email} {age}");
        }
    }

    static string GetWantedDepartment(Dictionary<string, List<decimal>> departments)
    {
        string wantedDepartment = string.Empty;
        decimal largestAverageSalary = 0m;

        foreach (var item in departments)
        {
            string department = item.Key;
            List<decimal> salaries = item.Value;

            if (salaries.Average() > largestAverageSalary)
            {
                largestAverageSalary = salaries.Average();
                wantedDepartment = department;
            }
        }

        return wantedDepartment;
    }
}