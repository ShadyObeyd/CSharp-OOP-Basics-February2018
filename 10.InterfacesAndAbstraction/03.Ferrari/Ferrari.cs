using System;

public class Ferrari : ICar
{
    public string Model { get; set; }
    public string Driver { get; set; }

    public Ferrari(string model, string driver)
    {
        Model = model;
        Driver = driver;
    }

    public override string ToString()
    {
        return $"{Model}/{UseBreaks()}/{UseGasPedal()}/{Driver}";
    }

    public string UseBreaks()
    {
        return "Brakes!";
    }

    public string UseGasPedal()
    {
        return "Zadu6avam sA!";
    }
}