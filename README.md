# Alleggro

An object-oriented C# library for Egg, Inc. featuring strongly typed game data access through `Type.Item.Property` and APIs for various calculations.

## Example Usage

### Accessing Item Data

```csharp
using Alleggro.Items;

GoldenEggs cost = Items.Boosts.SupremeTachyonPrism.Cost;
// 25000

decimal increase = Items.EggfinityStones.EggsquisiteDilithiumStone.Increase;
// 0.06m

int sockets = Items.Artifacts.EggceptionalAurelianBroochEpic.Sockets;
// 2
```

### Querying & Filtering Items

```csharp
using Alleggro.Boosts;
using Alleggro.Items;

Boost[] eligibleBoosts = Items.Boosts.All
    .Where(static boost =>
        boost is BoostBeacon
            or TachyonPrism)
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