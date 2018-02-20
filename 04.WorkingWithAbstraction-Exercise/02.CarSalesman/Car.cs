using System;

public class Car
{
    public string Model { get; set; }
    public Engine Engine { get; set; }
    public int Weight { get; set; }
    public string Color { get; set; }

    public Car(string model, Engine engine)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = 0;
        this.Color = "n/a";
    }
    
    public Car(string model, Engine engine, int weight) : this(model, engine)
    {
        this.Weight = weight;
    }

    public Car(string model, Engine engine, string color) : this(model, engine)
    {
        this.Color = color;
    }

    public Car(string model, Engine engine, int weight, string color) : this(model, engine)
    {
        this.Weight = weight;
        this.Color = color;
    }

    public override string ToString()
    {
        string weight = string.Empty;
        if (this.Weight == 0)
        {
            weight = "n/a";
        }
        else
        {
            weight = this.Weight.ToString();
        }

        return $"{this.Model}:" + Environment.NewLine +
            $"  {this.Engine}" + Environment.NewLine +
            $"  Weight: {weight}" + Environment.NewLine +
            $"  Color: {this.Color}";
    }
}