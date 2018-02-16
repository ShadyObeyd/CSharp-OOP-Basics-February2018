using System;
using System.Collections.Generic;

class SpeedRacing
{
    static void Main()
    {
        List<Car> cars = new List<Car>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] carTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string carModel = carTokens[0];
            decimal fuelQuantity = decimal.Parse(carTokens[1]);
            decimal consumptionPerKm = decimal.Parse(carTokens[2]);

            Car car = new Car();

            car.Model = carModel;
            car.FuelAmount = fuelQuantity;
            car.FuelConsumptionPerKm = consumptionPerKm;
            car.DistanceTraveled = 0;

            cars.Add(car);
        }

        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] inputTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string carModel = inputTokens[1];
            decimal desiredDistance = decimal.Parse(inputTokens[2]);

            Car currentCar = cars.Find(c => c.Model == carModel);

            if (!currentCar.CanTravel(desiredDistance))
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }

            input = Console.ReadLine();
        }

        foreach (Car car in cars)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.DistanceTraveled}");
        }
    }
}