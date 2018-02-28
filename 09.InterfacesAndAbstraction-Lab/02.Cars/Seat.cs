using System.Text;

public class Seat : ICar
{
    public string Model { get; set; }
    public string Color { get; set; }

    public Seat(string model, string color)
    {
        Model = model;
        Color = color;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder
            .AppendLine($"{Color} Seat {Model}")
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