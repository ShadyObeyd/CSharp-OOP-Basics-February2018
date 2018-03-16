using System;
using System.Collections.Generic;

public class Car
{
    private const double FUEL_TANK_CAPACITY = 160;
    private double fuelAmount;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp { get; private set; }

    public Tyre Tyre { get; private set; }

    public double FuelAmount
    {
        get { return this.fuelAmount; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }
            else if (value > FUEL_TANK_CAPACITY)
            {
                fuelAmount = FUEL_TANK_CAPACITY;
            }
            else
            {
                fuelAmount = value;
            }
        }
    }

    public void ReduceFuelAmount(int trackLength, double fuelConsumptionPerKm)
    {
        this.FuelAmount -= (trackLength * fuelConsumptionPerKm);
    }

    public void Refuel(double fuelAmount)
    {
        this.FuelAmount += fuelAmount;
    }

    public void ChangeTyre(List<string> arguments)
    {
        TyreFactory factory = new TyreFactory();

        try
        {
            this.Tyre = factory.CreateTyre(arguments);
        }
        catch (Exception)
        {

        }

    }
}