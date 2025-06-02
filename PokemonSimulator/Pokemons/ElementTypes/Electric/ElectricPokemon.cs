namespace PokemonSimulator.Pokemons;

internal class ElectricPokemon : Pokemon
{
    public ElectricPokemon(string name, int level, List<Attack> attacks)
        : base(name, ElementType.Electric, level, attacks)
    {
    }
}


