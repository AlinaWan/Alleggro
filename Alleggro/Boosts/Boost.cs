using Alleggro.Currencies;

namespace Alleggro.Boosts;

public sealed class Boost
{
    public string Name
    {
        get;
    }

    public BoostType Type
    {
        get;
    }

    public double Multiplier
    {
        get;
    }

    public TimeSpan Duration
    {
        get;
    }

    public GoldenEggs Cost
    {
        get;
    }

    internal Boost(
        string name,
        BoostType type,
        double multiplier,
        TimeSpan duration,
        GoldenEggs cost)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(multiplier);

        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(duration.Ticks);

        ArgumentOutOfRangeException.ThrowIfNegative(cost.Value);

        Name = name;
        Type = type;
        Multiplier = multiplier;
        Duration = duration;
        Cost = cost;
    }
}