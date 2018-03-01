using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        string input = Console.ReadLine();

        List<IBirthable> aliveCreatures = new List<IBirthable>();

        while (input != "End")
        {
            string[] creatureTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            switch (creatureTokens[0])
            {
                case "Citizen":
                    Citizen citizen = new Citizen(creatureTokens[1], int.Parse(creatureTokens[2]), creatureTokens[3], creatureTokens[4]);
                    aliveCreatures.Add(citizen);
                    break;
                case "Pet":
                    Pet pet = new Pet(creatureTokens[1], creatureTokens[2]);
                    aliveCreatures.Add(pet);
                    break;
            }
            input = Console.ReadLine();
        }
        string birthdate = Console.ReadLine();

        foreach (IBirthable creature in aliveCreatures.Where(c => c.Birthdate.EndsWith(birthdate)))
        {
            Console.WriteLine(creature.Birthdate);
        }
    }
}