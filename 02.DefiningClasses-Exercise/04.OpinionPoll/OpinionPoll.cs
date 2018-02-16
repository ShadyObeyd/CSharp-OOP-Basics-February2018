using System;
using System.Collections.Generic;
using System.Linq;

class OpinionPoll
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<Person> people = new List<Person>();

        for (int i = 0; i < n; i++)
        {
            string[] personTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string personName = personTokens[0];
            int personAge = int.Parse(personTokens[1]);

            Person currentPerson = new Person(personName, personAge);

            people.Add(currentPerson);
        }

        foreach (Person person in people.Where(p => p.Age > 30).OrderBy(p => p.Name))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}

