﻿using System;
using System.Collections.Generic;

public class TyreFactory
{
    public Tyre CreateTyre(List<string> arguments)
    {
        string tyreType = arguments[0];
        double hardness = double.Parse(arguments[1]);

        if (tyreType == "Ultrasoft")
        {
            double grip = double.Parse(arguments[2]);
            return new UltrasoftTyre(hardness, grip);
        }
        else if (tyreType == "Hard")
        {
            return new HardTyre(hardness);
        }
        else
        {
            throw new ArgumentException();
        }

    }
}