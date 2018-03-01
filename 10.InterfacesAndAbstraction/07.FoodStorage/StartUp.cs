using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<IBuyer> buyers = new List<IBuyer>();

        for (int i = 0; i < n; i++)
        {
            string[] buyerTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (buyerTokens.Length == 4)
            {
                Citizen citizen = new Citizen(buyerTokens[0], int.Parse(buyerTokens[1]), buyerTokens[2], buyerTokens[3]);
                buyers.Add(citizen);
            }
            else if (buyerTokens.Length == 3)
            {
                Rebel rebel = new Rebel(buyerTokens[0], int.Parse(buyerTokens[1]), buyerTokens[2]);
                buyers.Add(rebel);
            }
        }

        string name = Console.ReadLine();

        int totalFood = 0;

        while (name != "End")
        {
            if (buyers.Any(b => b.Name == name))
            {
                IBuyer buyer = buyers.FirstOrDefault(b => b.Name == name);
                buyer.BuyFood();
                totalFood += buyer.Food;
                buyer.Food = 0;
            }
            name = Console.ReadLine();
        }
        Console.WriteLine(totalFood);
    }
}