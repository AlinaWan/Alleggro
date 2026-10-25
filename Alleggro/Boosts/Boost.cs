using Alleggro.Currencies;

namespace Alleggro.Boosts;

public abstract class Boost
{
    public string Name
    {
        get;
    }
    public GoldenEggs? Cost
    {
        get;
    }

    public SoulEggs SoulEggsRequirement
    {
        get;
    }

    public BoostTokens? BoostTokensCost
    {
        get;
    }

    protected Boost(
        string name,
        GoldenEggs? cost,
        SoulEggs soulEggsRequirement,
        BoostTokens? boostTokensCost)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        if (cost.HasValue)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(cost.Value.Value);
        }

        Name = name;
        Cost = cost;
        SoulEggsRequirement = soulEggsRequirement;
        BoostTokensCost = boostTokensCost;
    }
}