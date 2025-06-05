using PokemonSimulator.Pokemons;

public class Main
{
    private List<Pokemon> pokemons = new List<Pokemon>();

    public Main()
    {
    }

    public void Run()
    {
        Init();
        Play();
    }

    private void Play()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("=========================================");
        Console.WriteLine("Welcome to the Pokémon Simulator!");
        Console.WriteLine("=========================================\n");
        Console.ForegroundColor = ConsoleColor.Cyan;

        foreach (var pokemon in pokemons)
        {
            Console.WriteLine($"\nA wild {pokemon.Name} appeared! It's a level {pokemon.Level} {pokemon.Type} Pokémon.");

            if (pokemon is Squirtle)
                pokemon.RandomAttack();
            else
                pokemon.Attack();

            pokemon.RaiseLevel();

            if (pokemon is not Squirtle)
                pokemon.RandomAttack();
            else
                pokemon.Attack();

            pokemon.RaiseLevel();
        }
    }

    private void Init()
    {
        var flamethrower = new Attack("Flamethrower", ElementType.Fire, 90);
        var ember = new Attack("Ember", ElementType.Fire, 40);
        var watergun = new Attack("Water Gun", ElementType.Water, 40);
        var wavecrash = new Attack("Wave Crash", ElementType.Water, 110);
        var nuzzle = new Attack("Nuzzle", ElementType.Electric, 20);
        var thunderbolt = new Attack("Thunderbolt", ElementType.Electric, 90);

        Shinx shinx = new Shinx(100, [nuzzle, thunderbolt]);
        Emolga emolga = new Emolga(50, [nuzzle]);
        Squirtle squirtle = new Squirtle(5, [watergun, wavecrash]);
        Charmander charmander = new Charmander(15, [flamethrower, ember]);

        pokemons.AddRange([shinx, emolga, squirtle, charmander]);
    }
}
