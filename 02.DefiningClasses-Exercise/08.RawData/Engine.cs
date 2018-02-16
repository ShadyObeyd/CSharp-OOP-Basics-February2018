public class Engine
{
    public int EngineSpeed { get; set; }
    public int EnginePower { get; set; }

    public Engine(int engineSpeed, int enginePower)
    {
        this.EnginePower = enginePower;
        this.EngineSpeed = engineSpeed;
    }
}