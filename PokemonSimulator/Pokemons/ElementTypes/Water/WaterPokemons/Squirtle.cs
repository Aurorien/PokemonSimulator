using PokemonSimulator.Abstractions;

namespace PokemonSimulator.Pokemons;

internal class Squirtle : WaterPokemon, IEvolvable
{
    public Squirtle(int level, List<Attack> attacks, IUserInterface ui)
        : base("Squirtle", level, attacks, ui)
    {
    }

    public void Evolve()
    {
        string oldName = this.Name; // strings are imutable and when a string updated a new string object is created, here we store the old name before changing it and it hold the reference to the old name's string object

        if (Level == 16)
        {
            this.Name = "Wartortle";
        }
        else if (Level == 35)
        {
            this.Name = "Blastoise";
        }
        else
        {
            return; // no evolution occurs if the level is not high enough
        }

        this.Level += 10;

        _ui.WriteLine($"{oldName} is evolving... Now it is {this.Name}! Level {this.Level}!");
    }
}
