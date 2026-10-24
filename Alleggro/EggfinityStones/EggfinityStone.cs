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

    internal EggfinityStone(
        string name,
        EggfinityStoneType type)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        Name = name;
        Type = type;
    }
}