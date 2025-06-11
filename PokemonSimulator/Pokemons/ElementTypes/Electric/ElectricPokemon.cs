using PokemonSimulator.Abstractions;

namespace PokemonSimulator.Pokemons;

internal class ElectricPokemon : Pokemon
{
    public ElectricPokemon(string name, int level, List<Attack> attacks, IUserInterface ui)
        : base(name, ElementType.Electric, level, attacks, ui)
    {
    }
}


