using Alleggro.Currencies;

namespace Alleggro.Boosts;

public sealed class SubsidyApplication : Boost
{
    public decimal Increase
    {
        get;
    }

    internal SubsidyApplication(
        string name,
        decimal increase,
        GoldenEggs? cost,
        SoulEggs soulEggsRequirement,
        BoostTokens? boostTokensCost)
        : base(
            name,
            cost,
            soulEggsRequirement,
            boostTokensCost)
    {
        Increase = increase;
    }
}