using System;
using System.Collections.Generic;

class StartUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<Person> people = new List<Person>();

        for (int i = 0; i < n; i++)
        {
            string[] peopleTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string firstName = peopleTokens[0];
            string lastName = peopleTokens[1];
            int age = int.Parse(peopleTokens[2]);
            decimal salary = decimal.Parse(peopleTokens[3]);

            try
            {
                people.Add(new Person(firstName, lastName, age, salary));
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }

        decimal bonus = decimal.Parse(Console.ReadLine());

        foreach (Person person in people)
        {
            person.IncreaseSalary(bonus);
            Console.WriteLine(person);
        }
    }
}