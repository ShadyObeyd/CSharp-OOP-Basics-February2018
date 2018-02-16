using System;
using System.Collections.Generic;
using System.Linq;

class PokemonTrainer
{
    static void Main()
    {
        string input = Console.ReadLine();

        List<Trainer> trainers = new List<Trainer>();

        while (input != "Tournament")
        {
            string[] inputTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string trainerName = inputTokens[0];
            string pokemonName = inputTokens[1];
            string pokemonElement = inputTokens[2];
            int pokemonHealth = int.Parse(inputTokens[3]);

            Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

            Trainer trainer;

            if (trainers.Any(t => t.Name == trainerName))
            {
                trainer = trainers.Find(t => t.Name == trainerName);
            }
            else
            {
                trainer = new Trainer(trainerName, 0, new List<Pokemon>());
                trainers.Add(trainer);
            }

            trainer.Pokemons.Add(pokemon);

            input = Console.ReadLine();
        }

        input = Console.ReadLine();

        while (input != "End")
        {
            foreach (Trainer trainer in trainers)
            {
                if (trainer.Pokemons.Any(p => p.Element == input))
                {
                    trainer.Badges++;
                }
                else
                {
                    if (trainer.Pokemons.Any())
                    {
                        foreach (Pokemon pokemon in trainer.Pokemons)
                        {
                            if (pokemon.Health > 0)
                            {
                                pokemon.Health -= 10;
                            }
                        }

                        trainer.Pokemons.RemoveAll(p => p.Health <= 0);
                    }
                }
            }
            input = Console.ReadLine();
        }

        foreach (Trainer trainer in trainers.OrderByDescending(t => t.Badges))
        {
            Console.WriteLine(trainer);
        }
    }
}