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
            DilithiumMonocle? dilithiumMonocle = null,
            IReadOnlyList<DilithiumStone>? dilithiumStones = null)
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

        dilithiumStones ??= Array.Empty<DilithiumStone>();

        Boost[] eligibleBoosts = Items.Boosts.All
            .Where(static boost =>
                boost is BoostBeacon
                    or TachyonPrism)
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
                long totalCost = 0;

                foreach (Boost boost in combination)
                {
                    totalCost = checked(totalCost + (boost.Cost ?? 0));
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
        DilithiumMonocle? dilithiumMonocle = null,
        IReadOnlyList<DilithiumStone>? dilithiumStones = null)
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
        DilithiumMonocle? dilithiumMonocle,
        IReadOnlyList<DilithiumStone> dilithiumStones)
    {
        if (combination.Count == 0 || baseRate == 0)
        {
            return 0;
        }

        double durationMultiplier =
            GetDurationMultiplier(dilithiumStones);

        TimeSpan[] expirationTimes = combination
            .Select(boost => boost switch
            {
                TachyonPrism prism => prism.Duration,
                BoostBeacon beacon => beacon.Duration,
                _ => throw new ArgumentException(
                    $"Boost type '{boost.GetType().Name}' does not have a duration.",
                    nameof(combination))
            })
            .Select(duration => TimeSpan.FromTicks(
                checked((long)Math.Truncate(
                    duration.Ticks * durationMultiplier))))
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
        DilithiumMonocle? dilithiumMonocle)
    {
        double multiplier = 1;
        double dilithiumMonocleMultiplier =
            dilithiumMonocle is not null
                ? 1 + (double)dilithiumMonocle.Effect
                : 1;

        foreach (IGrouping<Type, Boost> group in combination
            .Where(boost => boost switch
            {
                TachyonPrism prism =>
                    prism.Duration.Ticks * durationMultiplier > elapsed.Ticks,
                BoostBeacon beacon =>
                    beacon.Duration.Ticks * durationMultiplier > elapsed.Ticks,
                _ => false
            })
            .GroupBy(static boost => boost.GetType()))
        {
            double typeMultiplier = group.Sum(boost => boost switch
            {
                TachyonPrism prism => prism.Multiplier * dilithiumMonocleMultiplier,
                BoostBeacon beacon => beacon.Multiplier,
                _ => 0
            });

            multiplier *= typeMultiplier;
        }

        return multiplier;
    }

    private static double GetDurationMultiplier(
        IReadOnlyList<DilithiumStone> dilithiumStones)
    {
        double increase = 0;

        foreach (DilithiumStone stone in dilithiumStones)
        {
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