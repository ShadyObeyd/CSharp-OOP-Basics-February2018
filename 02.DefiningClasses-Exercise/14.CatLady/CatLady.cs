using System;
using System.Collections.Generic;

class CatLady
{
    static void Main()
    {
        string input = Console.ReadLine();

        List<Cat> cats = new List<Cat>();

        while (input != "End")
        {
            string[] catTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string breed = catTokens[0];
            string name = catTokens[1];
            string specialValue = catTokens[2];

            Cat cat = new Cat(breed, name, specialValue);

            cats.Add(cat);
            input = Console.ReadLine();
        }

        string catName = Console.ReadLine();

        Cat wantedCat = cats.Find(c => c.Name == catName);

        Console.WriteLine(wantedCat);
    }
}