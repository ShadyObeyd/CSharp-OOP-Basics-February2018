public class SonicHarvester : Harvester
{
    private int sonicfactor;

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) : base(id, oreOutput, energyRequirement)
    {
        this.SonicFactor = sonicFactor;
        this.EnergyRequirement = base.EnergyRequirement / this.SonicFactor;
    }

    public int SonicFactor
    {
        get { return sonicfactor; }
        private set { sonicfactor = value; }
    }

    public override string ToString()
    {
        return "Sonic" + base.ToString();
    }
}