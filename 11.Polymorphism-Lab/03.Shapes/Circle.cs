using System;

public class Circle : Shape
{
    public Circle(double radius)
    {
        Radius = radius;
    }

    private double radius;

    public double Radius
    {
        get { return radius; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Radius should be positive and larger than zero!");
            }
            radius = value;
        }
    }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * Radius;
    }

    public override string Draw()
    {
        return base.Draw() + GetType().Name;
    }
}