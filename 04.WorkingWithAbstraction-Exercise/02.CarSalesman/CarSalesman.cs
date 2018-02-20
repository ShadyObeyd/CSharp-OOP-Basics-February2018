using System;
using System.Collections.Generic;

class CarSalesman
{
    static void Main()
    {
        int enginesCount = int.Parse(Console.ReadLine());

        List<Engine> engines = new List<Engine>();

        for (int i = 0; i < enginesCount; i++)
        {
            string[] engineTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Engine engine = GetEngine(engineTokens);

            engines.Add(engine);
        }

        int carsCount = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>();

        for (int i = 0; i < carsCount; i++)
        {
            string[] carTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Car car = GetCar(carTokens, engines);

            cars.Add(car);
        }

        foreach (Car car in cars)
        {
            Console.WriteLine(car);
        }
    }

    private static Car GetCar(string[] carTokens, List<Engine> engines)
    {
        string model = carTokens[0];
        Engine engine = engines.Find(e => e.Model == carTokens[1]);

        if (carTokens.Length == 2)
        {
            return new Car(model, engine);
        }
        else if (carTokens.Length == 3)
        {
            int weight;
            if (int.TryParse(carTokens[2], out weight))
            {
                return new Car(model, engine, weight);
            }
            else
            {
                string color = carTokens[2];
                return new Car(model, engine, color);
            }
        }
        else
        {
            int weight = int.Parse(carTokens[2]);
            string color = carTokens[3];
            return new Car(model, engine, weight, color);
        }
    }

    static Engine GetEngine(string[] engineTokens)
    {
        string model = engineTokens[0];
        int power = int.Parse(engineTokens[1]);

        if (engineTokens.Length == 2)
        {
            return new Engine(model, power);
        }
        else if (engineTokens.Length == 3)
        {
            int displacement;
            if (int.TryParse(engineTokens[2], out displacement))
            {
                return new Engine(model, power, displacement);
            }
            else
            {
                string efficiency = engineTokens[2];
                return new Engine(model, power, efficiency);
            }
        }
        else
        {
            int displacement = int.Parse(engineTokens[2]);
            string efficiency = engineTokens[3];
            return new Engine(model, power, displacement, efficiency);
        }
    }
}