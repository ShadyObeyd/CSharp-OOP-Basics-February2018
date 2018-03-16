using System;

public class UltrasoftTyre : Tyre
{
    private double degradation;

    public UltrasoftTyre(double hardness, double grip) : base(hardness)
    {
        this.Name = "Ultrasoft";
        this.Grip = grip;
    }

    public double Grip { get; protected set; }

    public override double Degradation
    {
        get { return this.degradation; }
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException("Blown Tyre");
            }
            degradation = value;
        }
    }

    public override void ReduceDegradation()
    {
        this.Degradation -= (this.Hardness + this.Grip);
    }
}