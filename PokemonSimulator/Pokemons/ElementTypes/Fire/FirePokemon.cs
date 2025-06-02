namespace PokemonSimulator.Pokemons;

internal class FirePokemon : Pokemon
{
    public FirePokemon(string name, int level, List<Attack> attacks)
        : base(name, ElementType.Fire, level, attacks)
    {
    }
}