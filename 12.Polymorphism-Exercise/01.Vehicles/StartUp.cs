using System;

class StartUp
{
    static void Main()
    {
        string[] carTokens = ReadInput();
        string[] truckTokens = ReadInput();

        double carFuelQuantity = double.Parse(carTokens[1]);
        double carLitersPerKm = double.Parse(carTokens[2]);

        double truckFuelQuantity = double.Parse(truckTokens[1]);
        double truckLitersPerKm = double.Parse(truckTokens[2]);

        Vehicle car = new Car(carFuelQuantity, carLitersPerKm);
        Vehicle truck = new Truck(truckFuelQuantity, truckLitersPerKm);

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] commandTokens = ReadInput();

            switch (commandTokens[0])
            {
                case "Drive":
                    double distance = double.Parse(commandTokens[2]);
                    if (commandTokens[1] == "Car")
                    {
                        car.Drive(distance);
                    }
                    else if (commandTokens[1] == "Truck")
                    {
                        truck.Drive(distance);
                    }
                    break;
                case "Refuel":
                    double liters = double.Parse(commandTokens[2]);
                    if (commandTokens[1] == "Car")
                    {
                        car.Refuel(liters);
                    }
                    else if (commandTokens[1] == "Truck")
                    {
                        truck.Refuel(liters);
                    }
                    break;
            }
        }

        Console.WriteLine($"Car: {car.FuelQuantity:f2}");
        Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
    }

    private static string[] ReadInput()
    {
        return Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
    }
}