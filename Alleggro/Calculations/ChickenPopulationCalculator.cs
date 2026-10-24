using Alleggro.Currencies;
using Alleggro.Boosts;
using Alleggro.Items;

namespace Alleggro.Calculations;

public static class ChickenPopulationCalculator
{
    private const int MaximumSlots = 5;

    public static IReadOnlyList<ChickenPopulationResult>
        GetChickenPopulation(
            int internalHatcheryRate,
            int internalHatcheryCalmLevel,
            int habitats)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(
            internalHatcheryRate);

        if (internalHatcheryCalmLevel is < 0 or > 20)
        {
            throw new ArgumentOutOfRangeException(
                nameof(internalHatcheryCalmLevel),
                internalHatcheryCalmLevel,
                "Internal hatchery calm level must be between 0 and 20.");
        }

        if (habitats is < 1 or > 4)
        {
            throw new ArgumentOutOfRangeException(
                nameof(habitats),
                habitats,
                "Habitats must be between 1 and 4.");
        }

        Boost[] eligibleBoosts = Items.Boosts.All
            .Where(static boost =>
                boost.Type is BoostType.BoostBeacon
                    or BoostType.TachyonPrism)
            .ToArray();

        double baseRate =
            internalHatcheryRate
            * (1.0 + internalHatcheryCalmLevel * 0.10)
            * habitats;

        var results = new List<ChickenPopulationResult>();

        for (int slots = 0; slots <= MaximumSlots; slots++)
        {
            foreach (IReadOnlyList<Boost> combination
                in GenerateCombinations(eligibleBoosts, slots))
            {
                int totalCost = 0;

                foreach (Boost boost in combination)
                {
                    totalCost = checked(totalCost + boost.Cost.Value);
                }

                long chickenPopulation = CalculatePopulation(
                    combination,
                    baseRate);

                results.Add(new ChickenPopulationResult(
                    combination,
                    chickenPopulation,
                    new GoldenEggs(totalCost)));
            }
        }

        return results.AsReadOnly();
    }

    public static IReadOnlyList<ChickenPopulationResult> GetChickenPopulationMeetingTarget(
        int internalHatcheryRate,
        int internalHatcheryCalmLevel,
        int habitats,
        long targetPopulation)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(targetPopulation);

        return GetChickenPopulation(
                internalHatcheryRate,
                internalHatcheryCalmLevel,
                habitats)
            .Where(result => result.ChickenPopulation >= targetPopulation)
            .ToList()
            .AsReadOnly();
    }

    private static IEnumerable<IReadOnlyList<Boost>>
        GenerateCombinations(
            IReadOnlyList<Boost> boosts,
            int slots)
    {
        var selected = new Boost[slots];

        return Generate(0, 0);

        IEnumerable<IReadOnlyList<Boost>> Generate(
            int position,
            int firstIndex)
        {
            if (position == slots)
            {
                yield return Array.AsReadOnly(
                    (Boost[])selected.Clone());

                yield break;
            }

            for (int i = firstIndex; i < boosts.Count; i++)
            {
                selected[position] = boosts[i];

                foreach (IReadOnlyList<Boost> combination
                    in Generate(position + 1, i))
                {
                    yield return combination;
                }
            }
        }
    }

    // TODO: Implement calculation accounting for the effect of Artifacts and Eggfinity Stones on the population (e.g., Chalice, Life Stone).
    //       I think it's already included in the internalHatcheryRate so this might not be needed to be taken into account here, but I will need to verify that.
    private static long CalculatePopulation(
        IReadOnlyList<Boost> combination,
        double baseRate)
    {
        if (combination.Count == 0 || baseRate == 0)
        {
            return 0;
        }

        TimeSpan[] expirationTimes = combination
            .Select(static boost => boost.Duration)
            .Distinct()
            .Order()
            .ToArray();

        double totalChickens = 0;
        TimeSpan intervalStart = TimeSpan.Zero;

        foreach (TimeSpan intervalEnd in expirationTimes)
        {
            double intervalMinutes =
                (intervalEnd - intervalStart).TotalMinutes;

            double multiplier = GetMultiplier(
                combination,
                intervalStart);

            totalChickens +=
                baseRate * multiplier * intervalMinutes;

            intervalStart = intervalEnd;
        }

        return checked((long)Math.Truncate(totalChickens));
    }

    // TODO: Implement calculation accounting for the effect of Artifacts and Eggfinity Stones on the multiplier (e.g., Dilithium Monocle, Dilithium Stone).
    private static double GetMultiplier(
        IReadOnlyList<Boost> combination,
        TimeSpan elapsed)
    {
        double multiplier = 1;

        foreach (IGrouping<BoostType, Boost> group
            in combination
                .Where(boost => boost.Duration > elapsed)
                .GroupBy(static boost => boost.Type))
        {
            double typeMultiplier = group.Sum(
                static boost => boost.Multiplier);

            multiplier *= typeMultiplier;
        }

        return multiplier;
    }
}