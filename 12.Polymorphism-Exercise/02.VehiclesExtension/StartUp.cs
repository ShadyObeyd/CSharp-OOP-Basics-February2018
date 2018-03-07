using System;

class StartUp
{
    static void Main()
    {
        string[] carTokens = ReadInput();
        string[] truckTokens = ReadInput();
        string[] busTokens = ReadInput();

        double carFuelQuantity = double.Parse(carTokens[1]);
        double carLitersPerKm = double.Parse(carTokens[2]);
        double carTankCapacity = double.Parse(carTokens[3]);

        double truckFuelQuantity = double.Parse(truckTokens[1]);
        double truckLitersPerKm = double.Parse(truckTokens[2]);
        double truckTankCapacity = double.Parse(truckTokens[3]);

        double busFuelQuantity = double.Parse(busTokens[1]);
        double busLitersPerKm = double.Parse(busTokens[2]);
        double busTankCapacity = double.Parse(busTokens[3]);

        Vehicle car = new Car(carFuelQuantity, carLitersPerKm, carTankCapacity);
        Vehicle truck = new Truck(truckFuelQuantity, truckLitersPerKm, truckTankCapacity);
        Vehicle bus = new Bus(busFuelQuantity, busLitersPerKm, busTankCapacity);

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] commandTokens = ReadInput();

            double thirdParameter = double.Parse(commandTokens[2]);
            switch (commandTokens[0])
            {
                case "Drive":
                    if (commandTokens[1] == "Car")
                    {
                        car.Drive(thirdParameter);
                    }
                    else if (commandTokens[1] == "Truck")
                    {
                        truck.Drive(thirdParameter);
                    }
                    else if (commandTokens[1] == "Bus")
                    {
                        bus.Drive(thirdParameter);
                    }
                    break;
                case "Refuel":
                    if (commandTokens[1] == "Car")
                    {
                        car.Refuel(thirdParameter);
                    }
                    else if (commandTokens[1] == "Truck")
                    {
                        truck.Refuel(thirdParameter);
                    }
                    else if (commandTokens[1] == "Bus")
                    {
                        bus.Refuel(thirdParameter);
                    }
                    break;
                case "DriveEmpty":
                    if (commandTokens[1] == "Bus")
                    {
                        Bus emptyBus = (Bus)bus;
                        emptyBus.DriveEmpty(thirdParameter);
                    }
                    break;
            }
        }

        Console.WriteLine($"Car: {car.FuelQuantity:f2}");
        Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
    }

    private static string[] ReadInput()
    {
        return Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
    }
}