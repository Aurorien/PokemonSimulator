using PokemonSimulator.Abstractions;
using System.Diagnostics.CodeAnalysis;

namespace PokemonSimulator.Pokemons;

internal abstract class Pokemon
{
    private string _name;
    private ElementType _type;
    private int _level;

    private readonly List<Attack> _attacks;

    private bool HasAttacks() => _attacks?.Count > 0;

    protected readonly IUserInterface _ui;


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


    public Pokemon(string name, ElementType type, int level, List<Attack> attacks, IUserInterface ui)
    {
        Name = name;
        Type = type;
        Level = level;
        _attacks = attacks ?? throw new ArgumentNullException(nameof(attacks));
        _ui = ui ?? throw new ArgumentNullException(nameof(ui));
    }


    public void RandomAttack()
    {
        if (_attacks.Count == 0)
        {
            _ui.WriteLine($"{Name} has no attacks to use!");
            return;
        }

        var random = new Random();
        int randomIndex = random.Next(_attacks.Count);
        Attack selectedAttack = _attacks[randomIndex];
        selectedAttack.Use(Name, Level);
    }


    public void Attack()
    {
        if (!HasAttacks())
        {
            _ui.WriteLine($"\n{Name} has no attacks to use!");
            return;
        }

        DisplayAttacks();

        var selectedAttack = PromptForAttackSelection();
        selectedAttack?.Use(Name, Level);
    }


    public void RaiseLevel()
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        _ui.WriteLine($"{Name} has leveled up from level {Level} to level {Level + 1}!\n");
        Console.ForegroundColor = ConsoleColor.Cyan;

        Level++;

        if (this is IEvolvable evolvablePokemon)
            evolvablePokemon.Evolve();
    }


    private void DisplayAttacks()
    {
        _ui.WriteLine($"\n{Name} has the following attacks:");
        for (int i = 0; i < _attacks.Count; i++)
        {
            var atk = _attacks[i];
            _ui.WriteLine($"{i + 1}: {atk.Name} (Type: {atk.Type}, Power: {atk.BasePower})");
        }
    }


    private Attack PromptForAttackSelection()
    {
        while (true)
        {
            _ui.Write("Choose an attack by number: ");
            var input = _ui.ReadLine();

            if (int.TryParse(input, out int index) &&
                index >= 1 && index <= _attacks.Count)
            {
                return _attacks[index - 1];
            }

            _ui.WriteLine("Invalid selection. Please try again.");
        }
    }
}