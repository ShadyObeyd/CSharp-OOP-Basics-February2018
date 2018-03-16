using System;

public abstract class Driver
{
    private const double BOX_TIME = 20;

    protected Driver(string name, Car car)
    {
        this.Name = name;
        this.Car = car;
        this.TotalTime = 0;
        this.IsRacing = true;
    }

    public string Name { get; protected set; }

    public double FuelConsumptionPerKm { get; protected set; }

    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public double TotalTime { get; set; }

    public Car Car { get; protected set; }

    private string FailureReason { get; set; }

    public bool IsRacing { get; private set; }

    public string Status => this.IsRacing ? $"{this.TotalTime:f3}" : this.FailureReason;

    public void IncreaseBoxTime()
    {
        this.TotalTime += BOX_TIME;
    }

    public void CompleteLap(int trackLength)
    {
        this.TotalTime += (60 / (trackLength / this.Speed));

        this.Car.ReduceFuelAmount(trackLength, this.FuelConsumptionPerKm);

        this.Car.Tyre.ReduceDegradation();
    }

    internal void Fail(string message)
    {
        this.IsRacing = false;
        this.FailureReason = message;
    }
}