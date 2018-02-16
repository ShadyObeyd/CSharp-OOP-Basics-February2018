using System;
using System.Collections.Generic;

public class Person
{
    public string Name { get; set; }
    public Company Company { get; set; }
    public Car Car { get; set; }
    public List<Parent> Parents { get; set; }
    public List<Child> Children { get; set; }
    public List<Pokemon> Pokemons { get; set; }

    public override string ToString()
    {
        return $"{this.Name}" + Environment.NewLine +
            $"Company:" + Environment.NewLine +
            $"{this.Company}" + Environment.NewLine +
            $"Car:" + Environment.NewLine +
            $"{this.Car}" + Environment.NewLine +
            $"Pokemon:" + Environment.NewLine +
            $"{string.Join(Environment.NewLine, this.Pokemons)}" + Environment.NewLine +
            $"Parents:" + Environment.NewLine +
            $"{string.Join(Environment.NewLine, this.Parents)}" + Environment.NewLine +
            $"Children:" + Environment.NewLine +
            $"{string.Join(Environment.NewLine, this.Children)}";
    }
}