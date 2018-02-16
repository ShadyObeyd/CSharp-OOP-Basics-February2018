using System.Collections.Generic;

public class Trainer
{
    public string Name { get; set; }
    public int Badges { get; set; }
    public List<Pokemon> Pokemons { get; set; }

    public Trainer(string name, int badges, List<Pokemon> pokemons)
    {
        this.Name = name;
        this.Badges = badges;
        this.Pokemons = pokemons;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Badges} {this.Pokemons.Count}";
    }
}