using PokemonSimulator.Abstractions;

namespace PokemonSimulator.Pokemons;

internal class Charmander : FirePokemon, IEvolvable
{
    public Charmander(int level, List<Attack> attacks)
        : base("Charmander", level, attacks)
    {
    }

    public void Evolve()
    {
        string oldName = this.Name; // strings are imutable and when a string updated a new string object is created, here we store the old name before changing it and it hold the reference to the old name's string object

        if (Level == 16)
        {
            this.Name = "Charmeleon";
        }
        else if (Level == 35)
        {
            this.Name = "Charizard";
        }
        else
        {
            return; // no evolution occurs if the level is not high enough
        }

        this.Level += 10;

        Console.WriteLine($"{oldName} is evolving... Now it is {this.Name}! Level {this.Level}!");
    }
}

