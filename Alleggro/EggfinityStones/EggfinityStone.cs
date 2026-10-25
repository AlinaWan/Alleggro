namespace Alleggro.EggfinityStones;

public sealed class EggfinityStone
{
    public string Name
    {
        get;
    }

    public EggfinityStoneType Type
    {
        get;
    }

    public decimal? Increase
    {
        get;
    }

    internal EggfinityStone(
        string name,
        EggfinityStoneType type,
        decimal? increase)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        Name = name;
        Type = type;
        Increase = increase;
    }
}