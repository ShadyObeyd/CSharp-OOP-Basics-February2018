
public class Car
{
    public string Model { get; set; }
    public decimal FuelAmount { get; set; }
    public decimal FuelConsumptionPerKm { get; set; }
    public decimal DistanceTraveled { get; set; }

    public bool CanTravel(decimal desiredDistance)
    {
        if ((desiredDistance * FuelConsumptionPerKm) <= FuelAmount)
        {
            FuelAmount -= (desiredDistance * FuelConsumptionPerKm);
            DistanceTraveled += desiredDistance;
            return true;
        }
        return false;
    }
}

