using Alleggro.Artifacts;
using Alleggro.Boosts;
using Alleggro.Currencies;
using Alleggro.EggfinityStones;
using Alleggro.Items;

namespace Alleggro.Calculations;

public static class ChickenPopulationCalculator
{
    private const int MaximumSlots = 5;

    public static IReadOnlyList<ChickenPopulationResult>
        GetChickenPopulation(
            int internalHatcheryRate,
            int internalHatcheryCalmLevel,
            int habitats,
            Artifact? dilithiumMonocle = null,
            IReadOnlyList<EggfinityStone>? dilithiumStones = null)
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

        dilithiumStones ??= Array.Empty<EggfinityStone>();

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
                    baseRate,
                    dilithiumMonocle,
                    dilithiumStones);

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
        long targetPopulation,
        Artifact? dilithiumMonocle = null,
        IReadOnlyList<EggfinityStone>? dilithiumStones = null)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(targetPopulation);

        return GetChickenPopulation(
                internalHatcheryRate,
                internalHatcheryCalmLevel,
                habitats,
                dilithiumMonocle,
                dilithiumStones)
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
        double baseRate,
        Artifact? dilithiumMonocle,
        IReadOnlyList<EggfinityStone> dilithiumStones)
    {
        if (combination.Count == 0 || baseRate == 0)
        {
            return 0;
        }

        double durationMultiplier =
            GetDurationMultiplier(dilithiumStones);

        TimeSpan[] expirationTimes = combination
            .Select(boost => TimeSpan.FromTicks(
                checked((long)Math.Truncate(
                    boost.Duration.Ticks * durationMultiplier))))
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
                intervalStart,
                durationMultiplier,
                dilithiumMonocle);

            totalChickens +=
                baseRate * multiplier * intervalMinutes;

            intervalStart = intervalEnd;
        }

        return checked((long)Math.Truncate(totalChickens));
    }

    private static double GetMultiplier(
        IReadOnlyList<Boost> combination,
        TimeSpan elapsed,
        double durationMultiplier,
        Artifact? dilithiumMonocle)
    {
        double multiplier = 1;
        double dilithiumMonocleMultiplier =
            dilithiumMonocle is not null
                ? 1 + (double)dilithiumMonocle.Effect
                : 1;

        foreach (IGrouping<BoostType, Boost> group in combination
            .Where(boost =>
                boost.Duration.Ticks * durationMultiplier > elapsed.Ticks)
            .GroupBy(static boost => boost.Type))
        {
            double typeMultiplier = group.Sum(
                static boost => boost.Multiplier);

            if (group.Key is BoostType.BirdFeed
                or BoostType.TachyonPrism
                or BoostType.SoulBeacon)
            {
                typeMultiplier *= dilithiumMonocleMultiplier;
            }

            multiplier *= typeMultiplier;
        }

        return multiplier;
    }

    private static double GetDurationMultiplier(
        IReadOnlyList<EggfinityStone> dilithiumStones)
    {
        double increase = 0;

        foreach (EggfinityStone stone in dilithiumStones)
        {
            if (stone.Type != EggfinityStoneType.DilithiumStone)
            {
                throw new ArgumentException(
                    "All Eggfinity Stones must be Dilithium Stones.",
                    nameof(dilithiumStones));
            }

            if (stone.Increase is not decimal stoneIncrease)
            {
                throw new ArgumentException(
                    "Eggfinity Stones must have a defined increase.",
                    nameof(dilithiumStones));
            }

            increase += (double)stoneIncrease;
        }

        return 1 + increase;
    }
}