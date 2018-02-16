using System;

public class Engine
{
    public string Model { get; set; }
    public int Power { get; set; }
    public int Displacement { get; set; }
    public string Efficiency { get; set; }

    public Engine(string model,  int power)
    {
        this.Model = model;
        this.Power = power;
        this.Displacement = 0;
        this.Efficiency = "n/a";
    }

    public Engine(string model, int power, int displacement) : this(model, power)
    {
        this.Displacement = displacement;
    }

    public Engine(string model, int power, string efficiency) : this(model, power)
    {
        this.Efficiency = efficiency;
    }

    public Engine(string model, int power, int displacement, string efficiency) : this(model, power)
    {
        this.Displacement = displacement;
        this.Efficiency = efficiency;
    }

    public override string ToString()
    {
        string displacement = string.Empty;
        if (this.Displacement == 0)
        {
            displacement = "n/a";
        }
        else
        {
            displacement = this.Displacement.ToString();
        }

        return $"{this.Model}:" + Environment.NewLine +
            $"    Power: {this.Power}" + Environment.NewLine +
            $"    Displacement: {displacement}" + Environment.NewLine +
            $"    Efficiency: {this.Efficiency}";
    }
}