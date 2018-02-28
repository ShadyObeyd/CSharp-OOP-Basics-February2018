using System.Text;

public class Tesla : ICar, IElectricCar
{
    public string Model { get; set; }
    public string Color { get; set; }
    public int BatteriesCount { get; set; }

    public Tesla(string model, string color, int batteriesCount)
    {
        Model = model;
        Color = color;
        BatteriesCount = batteriesCount;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder
            .AppendLine($"{Color} Tesla {Model} with {BatteriesCount} Batteries")
            .AppendLine(Start())
            .AppendLine(Stop());

        return builder.ToString().TrimEnd();
    }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }
}