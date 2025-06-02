namespace PokemonSimulator.Pokemons;

internal class WaterPokemon : Pokemon
{
    public WaterPokemon(string name, int level, List<Attack> attacks)
        : base(name, ElementType.Water, level, attacks)
    {
    }
}