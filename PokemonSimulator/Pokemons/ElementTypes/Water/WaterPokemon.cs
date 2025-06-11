
using PokemonSimulator.Abstractions;

namespace PokemonSimulator.Pokemons;

internal class WaterPokemon : Pokemon
{
    public WaterPokemon(string name, int level, List<Attack> attacks, IUserInterface ui)
        : base(name, ElementType.Water, level, attacks, ui)
    {
    }
}