public class Box
{
    public double Length { get;  }
    public double Width { get;  }
    public double Height { get; }

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