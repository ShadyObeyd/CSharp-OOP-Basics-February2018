using System;

public abstract class Vehicle
{
    public Vehicle(double fuelQuantity, double litersPerKm, double tankCapacity)
    {
        FuelQuantity = fuelQuantity;
        LitersPerKm = litersPerKm;
        TankCapacity = tankCapacity;

        if (FuelQuantity > TankCapacity)
        {
            FuelQuantity = 0;
        }
    }

    public double FuelQuantity { get; protected set; }

    public double LitersPerKm { get; protected set; }

    public double TankCapacity { get; protected set; }

    public abstract void Drive(double distance);
    public abstract void Refuel(double liters);
}