using PokemonSimulator.Abstractions;

namespace PokemonSimulator.Pokemons;

internal class FirePokemon : Pokemon
{
    public FirePokemon(string name, int level, List<Attack> attacks, IUserInterface ui)
        : base(name, ElementType.Fire, level, attacks, ui)
    {
    }
}