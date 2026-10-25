using Alleggro.Currencies;

namespace Alleggro.Boosts;

public sealed class SoulMirror : Boost
{
    public TimeSpan Duration
    {
        get;
    }

    internal SoulMirror(
        string name,
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
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(duration.Ticks);

        Duration = duration;
    }
}