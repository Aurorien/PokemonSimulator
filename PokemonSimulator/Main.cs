using PokemonSimulator.Abstractions;
using PokemonSimulator.Pokemons;

public class Main
{
    private readonly IUserInterface _ui;
    private List<Pokemon> pokemons = new List<Pokemon>();


    public Main(IUserInterface ui)
    {
        this._ui = ui;
    }

    public void Run()
    {
        Init();
        Play();
    }

    private void Play()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        _ui.WriteLine("=========================================");
        _ui.WriteLine("Welcome to the Pokémon Simulator!");
        _ui.WriteLine("=========================================\n");
        Console.ForegroundColor = ConsoleColor.Cyan;

        foreach (var pokemon in pokemons)
        {
            _ui.WriteLine($"\nA wild {pokemon.Name} appeared! It's a level {pokemon.Level} {pokemon.Type} Pokémon.");

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

        Shinx shinx = new Shinx(100, [nuzzle, thunderbolt], _ui);
        Emolga emolga = new Emolga(50, [nuzzle], _ui);
        Squirtle squirtle = new Squirtle(5, [watergun, wavecrash], _ui);
        Charmander charmander = new Charmander(15, [flamethrower, ember], _ui);

        pokemons.AddRange([shinx, emolga, squirtle, charmander]);
    }
}
