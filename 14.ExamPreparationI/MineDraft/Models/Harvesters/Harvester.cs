using System;
using System.Text;

public abstract class Harvester
{
    private const double MAX_ENERGY_REQUIREMENT = 20000;
    private string id;
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public string Id
    {
        get { return id; }
        protected set { id = value; }
    }

    public double OreOutput
    {
        get { return oreOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's OreOutput");
            }
            oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get { return energyRequirement; }
        protected set
        {
            if (value < 0 || value > MAX_ENERGY_REQUIREMENT)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's EnergyRequirement");
            }
            energyRequirement = value;
        }
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine($" Harvester - {this.Id}");
        builder.AppendLine($"Ore Output: {this.OreOutput}");
        builder.AppendLine($"Energy Requirement: {this.EnergyRequirement}");

        return builder.ToString().TrimEnd();
    }
}