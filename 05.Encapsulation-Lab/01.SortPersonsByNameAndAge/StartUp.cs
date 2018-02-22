using System;
using System.Collections.Generic;
using System.Linq;

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
            string secondName = peopleTokens[1];
            int age = int.Parse(peopleTokens[2]);

            people.Add(new Person(firstName, secondName, age));
        }

        people = people
            .OrderBy(p => p.FirstName)
            .ThenBy(p => p.Age)
            .ToList();

        foreach (Person person in people)
        {
            Console.WriteLine(person);
        }
    }
}