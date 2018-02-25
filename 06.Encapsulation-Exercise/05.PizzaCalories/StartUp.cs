using System;

class StartUp
{
    static void Main()
    {
        try
        {
            string[] pizzaTokens = Console.ReadLine().Split(' ', StringSplitOptions.None);

            string pizzaName = pizzaTokens[1];

            Pizza pizza = new Pizza(pizzaName);

            string[] doughTokens = Console.ReadLine().Split(' ', StringSplitOptions.None);

            string flourType = doughTokens[1];
            string bakingTechnique = doughTokens[2];
            int doughWeight = int.Parse(doughTokens[3]);

            Dough dough = new Dough(flourType, bakingTechnique, doughWeight);

            pizza.Dough = dough;

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] toppingTokens = input.Split(' ', StringSplitOptions.None);

                string type = toppingTokens[1];
                int toppingWeight = int.Parse(toppingTokens[2]);

                Topping topping = new Topping(type, toppingWeight);

                input = Console.ReadLine();

                pizza.AddTopping(topping);
            }
            Console.WriteLine(pizza);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}