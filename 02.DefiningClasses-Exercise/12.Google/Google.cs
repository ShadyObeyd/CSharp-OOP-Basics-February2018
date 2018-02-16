using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Google
{
    static void Main()
    {
        string input = Console.ReadLine();

        List<Person> people = new List<Person>();

        while (input != "End")
        {
            string[] personTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string personName = personTokens[0];

            Person person;

            if (people.Any(p => p.Name == personName))
            {
                person = people.Find(p => p.Name == personName);
            }
            else
            {
                person = new Person();
                person.Name = personName;
                person.Pokemons = new List<Pokemon>();
                person.Children = new List<Child>();
                person.Parents = new List<Parent>();

                people.Add(person);
            }

            switch (personTokens[1])
            {
                case "company":
                    string companyName = personTokens[2];
                    string department = personTokens[3];
                    decimal salary = decimal.Parse(personTokens[4]);

                    Company company = new Company(companyName, department, salary);
                    person.Company = company;
                    break;
                case "pokemon":
                    string pokemonName = personTokens[2];
                    string pokemonType = personTokens[3];

                    Pokemon pokemnon = new Pokemon(pokemonName, pokemonType);
                    person.Pokemons.Add(pokemnon);
                    break;
                case "parents":
                    string parentName = personTokens[2];
                    string parentBirthday = personTokens[3];

                    Parent parent = new Parent(parentName, parentBirthday);
                    person.Parents.Add(parent);
                    break;
                case "children":
                    string childName = personTokens[2];
                    string childBirthday = personTokens[3];

                    Child child = new Child(childName, childBirthday);
                    person.Children.Add(child);
                    break;
                case "car":
                    string carModel = personTokens[2];
                    int speed = int.Parse(personTokens[3]);

                    Car car = new Car(carModel, speed);
                    person.Car = car;
                    break;
            }

            input = Console.ReadLine();
        }

        string wantedName = Console.ReadLine();

        Person wantedPerson = people.Find(p => p.Name == wantedName);

        string personResult = Regex.Replace(wantedPerson.ToString(), @"^\s+$[\r\n]*", "", RegexOptions.Multiline).TrimEnd();

        Console.WriteLine(personResult);
    }
}