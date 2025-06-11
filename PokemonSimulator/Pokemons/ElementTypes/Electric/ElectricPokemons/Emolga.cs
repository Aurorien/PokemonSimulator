using PokemonSimulator.Abstractions;

namespace PokemonSimulator.Pokemons;

internal class Emolga : ElectricPokemon
{
    public Emolga(int level, List<Attack> attacks, IUserInterface ui)
        : base("Emolga", level, attacks, ui)
    {
    }

}
