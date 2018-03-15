using System;
using System.Collections.Generic;

public class HarvesterFactory
{
    public Harvester CreateHarvester(List<string> arguments)
    {
        string harvesterType = arguments[0];
        string id = arguments[1];
        double oreOutput = double.Parse(arguments[2]);
        double energyRequirement = double.Parse(arguments[3]);

        if (harvesterType == "Sonic")
        {
            int sonicFactor = int.Parse(arguments[4]);
            return new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
        }
        else if (harvesterType == "Hammer")
        {
            return new HammerHarvester(id, oreOutput, energyRequirement);
        }
        else
        {
            throw new ArgumentException();
        }
    }
}