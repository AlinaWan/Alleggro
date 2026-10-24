# Alleggro

An object-oriented C# library for Egg, Inc. featuring strongly typed game data access through `Type.Item.Property` and APIs for various calculations.

## Example Usage

### Accessing Item Data

```csharp
using Alleggro.Items;

GoldenEggs cost = Items.Boosts.SupremeTachyonPrism.Cost;
// 25000

double multiplier = Items.Boosts.SupremeTachyonPrism.Multiplier;
// 1000
```

### Querying & Filtering Items

```csharp
using Alleggro.Boosts;
using Alleggro.Items;

Boost[] eligibleBoosts = Items.Boosts.All
    .Where(static boost =>
        boost.Type is BoostType.BoostBeacon
            or BoostType.TachyonPrism)
    .ToArray();
```

### Calculating Chicken Population

```csharp
using Alleggro.Calculations;

IReadOnlyList<ChickenPopulationResult> results =
    ChickenPopulationCalculator.GetChickenPopulation(
        internalHatcheryRate: 8000,
        internalHatcheryCalmLevel: 20,
        habitats: 4);

foreach (ChickenPopulationResult result in results)
{
    Console.WriteLine(
        $"Population: {result.ChickenPopulation:N0}, " +
        $"Cost: {result.Cost}");
}
```