using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ShoppingSpree
{
    class StartUp
    {
        static void Main()
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] peopleInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            FillPeople(people, peopleInput);

            string[] productsInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            FillProducts(products, productsInput);

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string personName = inputTokens[0];
                string productName = inputTokens[1];

                if (!products.Any(p => p.Name == productName) || !people.Any(p => p.Name == personName))
                {
                    continue;
                }

                Person wantedPerson = people.FirstOrDefault(p => p.Name == personName);
                Product wantedProduct = products.FirstOrDefault(p => p.Name == productName);

                if (wantedProduct.Cost > wantedPerson.Money)
                {
                    Console.WriteLine($"{wantedPerson} can't afford {wantedProduct}");
                }
                else
                {
                    wantedPerson.Products.Add(wantedProduct);
                    Console.WriteLine($"{wantedPerson} bought {wantedProduct}");
                    wantedPerson.Money -= wantedProduct.Cost;
                }
                input = Console.ReadLine();
            }

            foreach (Person person in people)
            {
                if (person.Products.Any())
                {
                    Console.WriteLine($"{person} - {string.Join(", ", person.Products)}");
                }
                else
                {
                    Console.WriteLine($"{person} - Nothing bought");
                }
            }
        }

        private static void FillPeople(List<Person> people, string[] peopleInput)
        {
            for (int i = 0; i < peopleInput.Length; i++)
            {
                string[] peopleTokens = peopleInput[i].Split('=', StringSplitOptions.RemoveEmptyEntries);

                string personName = peopleTokens[0];
                decimal personMoney = decimal.Parse(peopleTokens[1]);

                try
                {
                    people.Add(new Person(personName, personMoney));
                }
                catch (ArgumentException argEx)
                {
                    Console.WriteLine(argEx.Message);
                    Environment.Exit(0);
                }
            }
        }

        private static void FillProducts(List<Product> products, string[] productsInput)
        {
            for (int i = 0; i < productsInput.Length; i++)
            {
                string[] productTokens = productsInput[i].Split('=', StringSplitOptions.RemoveEmptyEntries);

                string productName = productTokens[0];
                decimal productPrice = decimal.Parse(productTokens[1]);

                try
                {
                    products.Add(new Product(productName, productPrice));
                }
                catch (ArgumentException argEx)
                {
                    Console.WriteLine(argEx.Message);
                    Environment.Exit(0);
                }
            }
        }
    }
}