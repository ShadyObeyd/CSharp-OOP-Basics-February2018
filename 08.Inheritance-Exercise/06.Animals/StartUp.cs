using System;
using System.Collections.Generic;

class StartUp
{
    static void Main()
    {
        string input = Console.ReadLine();

        List<Animal> zoo = new List<Animal>();

        while (input != "Beast!")
        {
            string[] animalTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (animalTokens.Length != 3)
            {
                Console.WriteLine("Invalid input!");
                continue;
            }

            string name = animalTokens[0];
            string age = animalTokens[1];
            string gender = animalTokens[2];

            try
            {
                switch (input)
                {
                    case "Dog":
                        Dog dog = new Dog(name, age, gender);
                        zoo.Add(dog);
                        break;
                    case "Cat":
                        Cat cat = new Cat(name, age, gender);
                        zoo.Add(cat);
                        break;
                    case "Frog":
                        Frog frog = new Frog(name, age, gender);
                        zoo.Add(frog);
                        break;
                    case "Kitten":
                        Kitten kitten = new Kitten(name, age, gender);
                        zoo.Add(kitten);
                        break;
                    case "Tomcat":
                        Tomcat tomcat = new Tomcat(name, age, gender);
                        zoo.Add(tomcat);
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            input = Console.ReadLine();
        }

        Console.WriteLine(string.Join(Environment.NewLine, zoo));
    }
}