namespace PokemonSimulator.Pokemons;

internal class Charmander : FirePokemon
{
    public Charmander(int level, List<Attack> attacks)
        : base("Charmander", level, attacks)
    {
    }

    public override void Evolve()
    {
        string oldName = this.Name;
        this.Name = "Charmeleon";
        this.Level += 10;
        Console.WriteLine($"{oldName} evolved into {this.Name}! Level increased to {this.Level}!");
    }
}

