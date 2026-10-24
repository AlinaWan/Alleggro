using Alleggro.Currencies;
using Alleggro.Boosts;

namespace Alleggro.Calculations;

public sealed class ChickenPopulationResult
{
    public IReadOnlyList<Boost> Boosts
    {
        get;
    }

    public long ChickenPopulation
    {
        get;
    }

    public GoldenEggs Cost
    {
        get;
    }

    internal ChickenPopulationResult(
        IReadOnlyList<Boost> boosts,
        long chickenPopulation,
        GoldenEggs cost)
    {
        Boosts = boosts;
        ChickenPopulation = chickenPopulation;
        Cost = cost;
    }
}