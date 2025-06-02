using PokemonSimulator.Pokemons;

public class Game
{
    private List<Attack> AvailableAttacks { get; }

    public Game()
    {
        AvailableAttacks = InitializeAttacks();
    }

    public void Run()
    {
        AvailableAttacks[0].Use(42);

        Pokemon squirtle = new Squirtle(5, AvailableAttacks);
        Console.WriteLine($"A wild {squirtle.Name} appeared! It's a level {squirtle.Level} {squirtle.Type} Pokémon.");
        squirtle.RandomAttack();

        Pokemon charmander = new Charmander(10, AvailableAttacks);
        Console.WriteLine($"A wild {charmander.Name} appeared! It's a level {charmander.Level} {charmander.Type} Pokémon.");
        charmander.RandomAttack();
        charmander.Evolve();

    }

    private List<Attack> InitializeAttacks()
    {
        return new List<Attack>
        {
            new Attack("Flamethrower", ElementType.Fire, 12),
            new Attack("Ember", ElementType.Fire, 6),
            new Attack("Water Gun", ElementType.Water, 8),
            new Attack("Thunderbolt", ElementType.Electric, 10)
        };
    }
}
