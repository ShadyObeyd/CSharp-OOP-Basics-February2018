using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        List<Animal> animals = new List<Animal>();
        int i = 0;
        
        string input = Console.ReadLine();
        
        while (input != "End")
        {
            string[] inputTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
            if (i % 2 == 0)
            {
                Animal animal = null;
                string name = inputTokens[1];
                double weight = double.Parse(inputTokens[2]);

                switch (inputTokens[0])
                {
                    case "Owl":
                        animal = new Owl(name, weight, double.Parse(inputTokens[3]));
                        break;
                    case "Hen":
                        animal = new Hen(name, weight, double.Parse(inputTokens[3]));
                        break;
                    case "Mouse":
                        animal = new Mouse(name, weight, inputTokens[3]);
                        break;
                    case "Dog":
                        animal = new Dog(name, weight, inputTokens[3]);
                        break;
                    case "Cat":
                        animal = new Cat(name, weight, inputTokens[3], inputTokens[4]);
                        break;
                    case "Tiger":
                        animal = new Tiger(name, weight, inputTokens[3], inputTokens[4]);
                        break;
                }
                Console.WriteLine(animal.AskForFood());
                animals.Add(animal);
            }
            else
            {
                Animal animal = animals.Last();
                Food food = null;
                int quantity = int.Parse(inputTokens[1]);

                switch (inputTokens[0])
                {
                    case "Vegetable":
                        food = new Vegetable(quantity);
                        break;
                    case "Fruit":
                        food = new Fruit(quantity);
                        break;
                    case "Meat":
                        food = new Meat(quantity);
                        break;
                    case "Seeds":
                        food = new Seeds(quantity);
                        break;
                }
                animal.EatFood(food);
            }
            i++;
            input = Console.ReadLine();
        }

        foreach (Animal animal in animals)
        {
            Console.WriteLine(animal);
        }
    }
}