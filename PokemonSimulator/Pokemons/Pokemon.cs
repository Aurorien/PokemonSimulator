using PokemonSimulator.Abstractions;
using System.Diagnostics.CodeAnalysis;

namespace PokemonSimulator.Pokemons;

internal abstract class Pokemon
{
    private readonly List<Attack> _attacks;

    private string _name;
    private ElementType _type;
    private int _level;

    public string Name
    {
        get => _name;

        [MemberNotNull(nameof(_name))] // attribute to ensure _name is not null when set, also lhelps the compiler understand that this property will always be set before use
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be null or empty.", nameof(value));

            if (value.Length < 2 || value.Length > 15)
                throw new ArgumentException("Name must be between 2 and 15 characters.", nameof(value));
            _name = value;
        }
    }
    public ElementType Type
    {
        get => _type;

        [MemberNotNull(nameof(_type))]
        protected set
        {
            if (!Enum.IsDefined(typeof(ElementType), value))
                throw new ArgumentException("Invalid element type.", nameof(value));
            _type = value;
        }
    }
    public int Level
    {
        get => _level;

        [MemberNotNull(nameof(_level))]
        protected set
        {

            if (value < 1)
                throw new ArgumentException("Level must be greater than or equal to 1.", nameof(value));
            _level = value;
        }
    }

    public Pokemon(string name, ElementType type, int level, List<Attack> attacks)
    {
        Name = name;
        Type = type;
        Level = level;
        _attacks = attacks ?? throw new ArgumentNullException(nameof(attacks));
    }


    public void RandomAttack()
    {
        if (_attacks.Count == 0)
        {
            Console.WriteLine($"{Name} has no attacks to use!");
            return;
        }

        var random = new Random();
        int randomIndex = random.Next(_attacks.Count);
        Attack selectedAttack = _attacks[randomIndex];
        selectedAttack.Use(Level);
    }

    public void Attack()
    {
        if (_attacks.Count == 0)
        {
            Console.WriteLine($"{Name} has no attacks to use!");
            return;
        }

        Console.WriteLine($"{Name} has the following attacks:");

        for (int i = 0; i < _attacks.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {_attacks[i].Name} (Type: {_attacks[i].Type}, Power: {_attacks[i].BasePower})");
        }

        Console.Write("Choose an attack by number: ");

        string input = Console.ReadLine() ?? string.Empty;

        if (int.TryParse(input, out int attackIndex) && attackIndex > 0 && attackIndex <= _attacks.Count)
        {
            Attack selectedAttack = _attacks[attackIndex - 1];
            selectedAttack.Use(Level);
        }
        else
            Console.WriteLine("Invalid selection. Please try again.");
    }



    public void RaiseLevel()
    {
        Console.WriteLine($"{Name} has leveled up from level {Level} to level {Level + 1}!");
        Level++;

        if (this is IEvolvable evolvablePokemon)
            evolvablePokemon.Evolve();
    }
}