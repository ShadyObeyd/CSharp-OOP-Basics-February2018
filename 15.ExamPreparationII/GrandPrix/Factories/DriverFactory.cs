using System;
using System.Collections.Generic;
using System.Linq;

public class DriverFactory
{
    public Driver CreateDriver(List<string> arguments)
    {
        TyreFactory tyreFactory = new TyreFactory();

        string driverType = arguments[0];
        string name = arguments[1];
        int hp = int.Parse(arguments[2]);
        double fuelAmount = double.Parse(arguments[3]);
        
        
        List<string> tyreArguments = arguments.Skip(4).ToList();

        Tyre tyre = tyreFactory.CreateTyre(tyreArguments);

        Car car = new Car(hp, fuelAmount, tyre);

        if (driverType == "Aggressive")
        {
            return new AggressiveDriver(name, car);
        }
        else if (driverType == "Endurance")
        {
            return new EnduranceDriver(name, car);
        }
        else
        {
            throw new ArgumentException();
        }
    }
}