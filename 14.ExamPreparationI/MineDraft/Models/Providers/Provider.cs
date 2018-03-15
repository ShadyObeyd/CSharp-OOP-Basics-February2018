﻿using System;
using System.Text;

public abstract class Provider
{
    private const double MAX_ENERGY_OUTPUT = 10000;
    private string id;
    private double energyOutput;

    protected Provider(string id, double energyOutput)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
    }

    public string Id
    {
        get { return id; }
        protected set { id = value; }
    }

    public double EnergyOutput
    {
        get { return energyOutput; }
        protected set
        {
            if (value < 0 || value >= MAX_ENERGY_OUTPUT)
            {
                throw new ArgumentException($"Provider is not registered, because of it's EnergyOutput");
            }
            energyOutput = value;
        }
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine($" Provider - {this.Id}");
        builder.AppendLine($"Energy Output: {this.EnergyOutput}");

        return builder.ToString().TrimEnd();
    }

}