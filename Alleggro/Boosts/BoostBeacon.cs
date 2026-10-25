using System.Xml.Linq;
using Alleggro.Currencies;

namespace Alleggro.Boosts;

public sealed class BoostBeacon : Boost
{
    public double Multiplier
    {
        get;
    }
    public TimeSpan Duration
    {
        get;
    }

    internal BoostBeacon(
        string name,
        double multiplier,
        TimeSpan duration,
        GoldenEggs? cost,
        SoulEggs soulEggsRequirement,
        BoostTokens? boostTokensCost)
        : base(
            name,
            cost,
            soulEggsRequirement,
            boostTokensCost)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(multiplier);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(duration.Ticks);

        Multiplier = multiplier;
        Duration = duration;
    }
}