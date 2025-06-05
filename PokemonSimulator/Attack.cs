internal class Attack
{
    public string Name { get; private set; }
    public ElementType Type { get; private set; }
    public int BasePower { get; private set; }

    public Attack(string name, ElementType type, int basePower)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Type = type;
        BasePower = basePower;
    }

    public void Use(string pokemonName, int level)
    {
        int damage = CalculateDamage(level);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\n{pokemonName} attacks!");
        Console.WriteLine($"{Name} hits with total power {damage}!\n");
        Console.ForegroundColor = ConsoleColor.Cyan;
    }

    internal int CalculateDamage(int level)
    {
        return BasePower + level;
    }
}
