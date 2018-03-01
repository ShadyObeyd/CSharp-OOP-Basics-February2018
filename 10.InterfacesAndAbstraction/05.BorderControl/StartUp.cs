using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        string input = Console.ReadLine();

        List<ILivable> subjects = new List<ILivable>();

        while (input != "End")
        {
            string[] tokens = input.Split(' ');

            if (tokens.Length == 2)
            {
                Robot robot = new Robot(tokens[0], tokens[1]);
                subjects.Add(robot);
            }
            else if (tokens.Length == 3)
            {
                Citizen citizen = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]);
                subjects.Add(citizen);
            }
            input = Console.ReadLine();
        }

        string fakeIdEnding = Console.ReadLine();

        foreach (ILivable subject in subjects.Where(s => s.Id.EndsWith(fakeIdEnding)))
        {
            Console.WriteLine(subject.Id);
        }
    }
}