
internal abstract class Pokemon
{
    private readonly List<Attack> _attacks;

    public string Name { get; }
    public ElementType Type { get; }
    public int Level { get; private set; }

    public Pokemon(string name, ElementType type, int level, List<Attack> attacks)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or empty.", nameof(name));

        if (name.Length < 2 || name.Length > 15)
            throw new ArgumentException("Name must be between 2 and 15 characters.", nameof(name));

        if (!Enum.IsDefined(typeof(ElementType), type))
            throw new ArgumentException("Invalid element type.", nameof(type));

        if (level < 1)
            throw new ArgumentException("Level must be greater than or equal to 1.", nameof(level));

        Name = name;
        Type = type;
        Level = level;
        _attacks = attacks ?? throw new ArgumentNullException(nameof(attacks));
    }

    public void RandomAttack()
    {
        // Picks a random attack from the list of attacks and invokes its .Use-method.
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
        // Lets the user pick an attack from the list of attacks and invoke its .Use-method.
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
        // That should increment the level of the given pokemon and print that the pokemon has leveled up.
        Level++;
        Console.WriteLine($"{Name} has leveled up from level {Level} to level {Level + 1}!");
    }

}

