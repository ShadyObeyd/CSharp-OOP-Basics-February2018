using System;

public class Bus : Vehicle
{
    public Bus(double fuelQuantity, double litersPerKm, double tankCapacity) : base(fuelQuantity, litersPerKm, tankCapacity)
    {

    }

    public override void Drive(double distance)
    {
        double totalExpenditure = distance * (LitersPerKm + 1.4);

        if (totalExpenditure <= FuelQuantity)
        {
            FuelQuantity -= totalExpenditure;
            Console.WriteLine($"{GetType().Name} travelled {distance} km");
        }
        else
        {
            Console.WriteLine($"{GetType().Name} needs refueling");
        }

    }

    public void DriveEmpty(double distance)
    {
        double totalExpenditure = distance * LitersPerKm;

        if (totalExpenditure <= FuelQuantity)
        {
            FuelQuantity -= totalExpenditure;
            Console.WriteLine($"{GetType().Name} travelled {distance} km");
        }
        else
        {
            Console.WriteLine($"{GetType().Name} needs refueling");
        }
    }

    public override void Refuel(double liters)
    {
        if (liters <= 0)
        {
            Console.WriteLine("Fuel must be a positive number");
        }
        else
        {
            if (FuelQuantity + liters > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
            else
            {
                FuelQuantity += liters;
            }
        }
    }
}

