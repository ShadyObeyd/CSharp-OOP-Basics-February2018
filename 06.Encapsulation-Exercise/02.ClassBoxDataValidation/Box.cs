using System;

public class Box
{
    private double length;

    public double Length
    {
        get { return length; }
        set
        {
            ValidateData(value, "Length");
            length = value;
        }
    }

    private double width;

    public double Width
    {
        get { return width; }
        set
        {
            ValidateData(value, "Width");
            width = value;
        }
    }

    private double height;

    public double Height
    {
        get { return height; }
        set
        {
            ValidateData(value, "Height");
            height = value;
        }
    }

    private void ValidateData(double value, string side)
    {
        if (value <= 0)
        {
            throw new ArgumentException($"{side} cannot be zero or negative.");
        }

    }

    public Box(double lenght, double width, double height)
    {
        Length = lenght;
        Width = width;
        Height = height;
    }

    public double GetSufaceArea()
    {
        return (2 * Length * Width) + (2 * Length * Height) + (2 * Width * Height);
    }

    public double GetLateralSurfaceArea()
    {
        return (2 * Length * Height) + (2 * Width * Height);
    }

    public double GetVolume()
    {
        return Length * Width * Height;
    }
}