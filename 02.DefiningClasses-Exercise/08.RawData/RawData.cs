using System;
using System.Collections.Generic;
using System.Linq;

class RawData
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            string[] carTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string model = carTokens[0];

            int engineSpeed = int.Parse(carTokens[1]);
            int enginePower = int.Parse(carTokens[2]);

            Engine engine = new Engine(engineSpeed, enginePower);

            int cargoWeight = int.Parse(carTokens[3]);
            string cargoType = carTokens[4];

            Cargo cargo = new Cargo(cargoWeight, cargoType);

            double firstTirePressure = double.Parse(carTokens[5]);
            int firstTireAge = int.Parse(carTokens[6]);

            double secondTirePressure = double.Parse(carTokens[7]);
            int secondTireAge = int.Parse(carTokens[8]);

            double thirdTirePressure = double.Parse(carTokens[9]);
            int thirdTireAge = int.Parse(carTokens[10]);

            double fourthTirePressure = double.Parse(carTokens[11]);
            int fourthTireAge = int.Parse(carTokens[12]);

            Tyre[] tyres = new Tyre[4];

            tyres[0] = new Tyre(firstTireAge, firstTirePressure);
            tyres[1] = new Tyre(secondTireAge, secondTirePressure);
            tyres[2] = new Tyre(thirdTireAge, thirdTirePressure);
            tyres[3] = new Tyre(fourthTireAge, fourthTirePressure);

            Car car = new Car(model, engine, cargo, tyres);

            cars.Add(car);
        }

        string criteria = Console.ReadLine().ToLower();

        Func<List<Car>, List<Car>> neededCars = GetCars(criteria);

        foreach (Car car in neededCars(cars))
        {
            Console.WriteLine(car.Model);
        }
    }

    static Func<List<Car>, List<Car>> GetCars(string criteria)
    {
        if (criteria == "fragile")
        {
            return x => x.Where(c => c.Cargo.Type == criteria && c.Tyres.Any(t => t.Pressure < 1)).ToList();
        }
        else if (criteria == "flamable")
        {
            return x => x.Where(c => c.Cargo.Type == criteria && c.Engine.EnginePower > 250).ToList();
        }
        else
        {
            throw new FormatException();
        }
    }
}