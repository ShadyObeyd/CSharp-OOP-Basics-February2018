public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput) : base(id, energyOutput)
    {
        this.EnergyOutput += this.EnergyOutput * 0.5;
    }

    public override string ToString()
    {
        return "Pressure" + base.ToString();
    }
}