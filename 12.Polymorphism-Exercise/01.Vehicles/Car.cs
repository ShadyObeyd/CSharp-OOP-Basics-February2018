using System;

public class Car : Vehicle
{
    public Car(double fuelQuantity, double litersPerKm) : base(fuelQuantity, litersPerKm)
    {

    }

    public override void Drive(double distance)
    {
        double totalExpenditure = distance * (LitersPerKm + 0.9);

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
        FuelQuantity += liters;
    }
}