public class Robot : ILivable
{
    public string Model { get; private set; }
    public string Id { get; private set; }

    public Robot(string model, string id)
    {
        Model = model;
        Id = id;
    }
}