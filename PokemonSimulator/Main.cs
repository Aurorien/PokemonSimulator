using PokemonSimulator.Pokemons;

public class Main
{
    public Main()
    {
    }

    public void Run()
    {
        // ToDo: Refactor
        var flamethrower = new Attack("Flamethrower", ElementType.Fire, 90);
        var ember = new Attack("Ember", ElementType.Fire, 40);
        var watergun = new Attack("Water Gun", ElementType.Water, 40);
        var wavecrash = new Attack("Wave Crash", ElementType.Water, 110);
        var nuzzle = new Attack("Nuzzle", ElementType.Electric, 20);
        var thunderbolt = new Attack("Thunderbolt", ElementType.Electric, 90);

        Pokemon shinx = new Shinx(100, [nuzzle, thunderbolt]);
        Console.WriteLine($"A wild {shinx.Name} appeared! It's a level {shinx.Level} {shinx.Type} Pokémon.");
        shinx.Attack();
        shinx.RaiseLevel();

        Pokemon emolga = new Emolga(50, [nuzzle]);
        Console.WriteLine($"A wild {emolga.Name} appeared! It's a level {emolga.Level} {emolga.Type} Pokémon.");
        emolga.Attack();
        emolga.RaiseLevel();

        Pokemon squirtle = new Squirtle(5, [watergun, wavecrash]);
        Console.WriteLine($"A wild {squirtle.Name} appeared! It's a level {squirtle.Level} {squirtle.Type} Pokémon.");
        squirtle.RandomAttack();
        squirtle.RaiseLevel();

        Pokemon charmander = new Charmander(15, [flamethrower, ember]);
        Console.WriteLine($"A wild {charmander.Name} appeared! It's a level {charmander.Level} {charmander.Type} Pokémon.");
        charmander.RandomAttack();
        charmander.RaiseLevel();
    }
}
