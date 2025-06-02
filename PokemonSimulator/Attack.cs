
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

    public void Use(int level)
    {
        int damage = CalculateDamage(level);
        Console.WriteLine($"{Name} hits with total power {damage}!");
    }

    internal int CalculateDamage(int level)
    {
        return BasePower + level;
    }
}
