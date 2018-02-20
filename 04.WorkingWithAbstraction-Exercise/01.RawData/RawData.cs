using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    class RawData
    {
        static void Main()
        {
            List<Car> cars = new List<Car>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] carTokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = carTokens[0];
                int engineSpeed = int.Parse(carTokens[1]);
                int enginePower = int.Parse(carTokens[2]);

                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(carTokens[3]);
                string cargoType = carTokens[4];

                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Tyre[] tyres = new Tyre[4];

                double firstTyrePressure = double.Parse(carTokens[5]);
                int firstTyreAge = int.Parse(carTokens[6]);

                tyres[0] = new Tyre(firstTyrePressure, firstTyreAge);

                double secondTyrePressure = double.Parse(carTokens[7]);
                int secondTyreAge = int.Parse(carTokens[8]);

                tyres[1] = new Tyre(secondTyrePressure, secondTyreAge);

                double thirdTyrePressure = double.Parse(carTokens[9]);
                int thirdTyreAge = int.Parse(carTokens[10]);

                tyres[2] = new Tyre(thirdTyrePressure, thirdTyreAge);

                double fourthTyrePressure = double.Parse(carTokens[11]);
                int fourthTyreAge = int.Parse(carTokens[12]);

                tyres[3] = new Tyre(fourthTyrePressure, fourthTyreAge);

                cars.Add(new Car(model, engine, cargo, tyres));
            }

            string criteria = Console.ReadLine();

            cars = GetWantedCars(cars, criteria);

            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }

        private static List<Car> GetWantedCars(List<Car> cars, string criteria)
        {
            if (criteria == "fragile")
            {
                return cars.Where(c => c.Cargo.Type == criteria && c.Tyres.Any(t => t.Pressure < 1)).ToList();
            }
            else if (criteria == "flamable")
            {
                return cars.Where(c => c.Cargo.Type == criteria && c.Engine.Power > 250).ToList();
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}