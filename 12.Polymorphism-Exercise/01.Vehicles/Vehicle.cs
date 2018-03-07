using System;

public abstract class Vehicle
{
    public Vehicle(double fuelQuantity, double litersPerKm)
    {
        FuelQuantity = fuelQuantity;
        LitersPerKm = litersPerKm;
    }

    public double FuelQuantity { get; protected set; }
    public double LitersPerKm { get; protected set; }

    public abstract void Drive(double distance);
    public abstract void Refuel(double liters);
}