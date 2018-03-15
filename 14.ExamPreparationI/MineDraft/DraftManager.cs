using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private List<Harvester> harvesters;
    private List<Provider> providers;
    private HarvesterFactory harvesterFactory;
    private ProviderFactory providerFactory;
    private double totalOreMined;
    private double totalEnergyStored;
    private string mode;

    public DraftManager()
    {
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.harvesterFactory = new HarvesterFactory();
        this.providerFactory = new ProviderFactory();
        this.totalOreMined = 0;
        this.totalEnergyStored = 0;
        this.mode = "Full";
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            Harvester harvester = harvesterFactory.CreateHarvester(arguments);
            this.harvesters.Add(harvester);

            return $"Successfully registered {arguments[0]} Harvester - {harvester.Id}";
        }
        catch (ArgumentException ex)
        {
           return ex.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            Provider provider = providerFactory.CreateProvider(arguments);
            this.providers.Add(provider);

            return $"Successfully registered {arguments[0]} Provider - {provider.Id}";
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
        }
    }

    public string Day()
    {
        double orePerDayMined = 0;
        double energyPerDayRequired = 0;
        double energyPerDayProvided = providers.Sum(p => p.EnergyOutput);
        this.totalEnergyStored += energyPerDayProvided;

        StringBuilder builder = new StringBuilder();

        if (this.mode == "Full")
        {
            energyPerDayRequired = harvesters.Sum(h => h.EnergyRequirement);
            orePerDayMined = harvesters.Sum(h => h.OreOutput);
        }
        else if (this.mode == "Half")
        {
            energyPerDayRequired = harvesters.Sum(h => h.EnergyRequirement) * 0.6;
            orePerDayMined = harvesters.Sum(h => h.OreOutput) * 0.5;
        }
        else if (this.mode == "Energy")
        {
            energyPerDayRequired = 0;
            orePerDayMined = 0;
        }

        if (totalEnergyStored >= energyPerDayRequired)
        {
            this.totalEnergyStored -= energyPerDayRequired;
            this.totalOreMined += orePerDayMined;
        }
        else
        {
            orePerDayMined = 0;
        }

        builder.AppendLine("A day has passed.");
        builder.AppendLine($"Energy Provided: {energyPerDayProvided}");
        builder.AppendLine($"Plumbus Ore Mined: {orePerDayMined}");

        return builder.ToString().TrimEnd();
    }

    public string Mode(List<string> arguments)
    {
        this.mode = arguments[0];
        return $"Successfully changed working mode to {this.mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];

        if (this.providers.Any(p => p.Id == id))
        {
            return providers.FirstOrDefault(p => p.Id == id).ToString();
        }
        else if (this.harvesters.Any(h => h.Id == id))
        {
            return harvesters.FirstOrDefault(h => h.Id == id).ToString();
        }
        else
        {
            return $"No element found with id - {id}";
        }
    }
    public string ShutDown()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine($"System Shutdown");
        builder.AppendLine($"Total Energy Stored: {this.totalEnergyStored}");
        builder.AppendLine($"Total Mined Plumbus Ore: {this.totalOreMined}");

        return builder.ToString().TrimEnd();
    }
}