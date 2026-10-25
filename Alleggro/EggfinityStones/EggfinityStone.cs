namespace Alleggro.EggfinityStones;

public abstract class EggfinityStone
{
    public string Name
    {
        get;
    }

    public decimal? Increase
    {
        get;
    }

    protected EggfinityStone(
        string name,
        decimal? increase)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        Name = name;
        Increase = increase;
    }
}