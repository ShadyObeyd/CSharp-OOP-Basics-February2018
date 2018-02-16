using System;
using System.Linq;

class OldestFamilyMember
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Family family = new Family();

        for (int i = 0; i < n; i++)
        {
            string[] personTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string personName = personTokens[0];
            int personAge = int.Parse(personTokens[1]);

            Person currentPerson = new Person(personName, personAge);

            family.AddMember(currentPerson);
        }

        Person wantedPerson = family.People.Find(p => p.Age.Equals(family.People.Max(x => x.Age)));

        Console.WriteLine($"{wantedPerson.Name} {wantedPerson.Age}");
    }
}
