using Alleggro.Artifacts;

namespace Alleggro.Items;

public static class Artifacts
{
    // Aurelian Brooch
    public static AurelianBrooch PlainAurelianBroochCommon
    {
        get;
    } = new(
        name: "Plain Aurelian Brooch",
        tier: ArtifactTier.Tier1,
        rarity: ArtifactRarity.Common,
        effect: 0.10m,
        sockets: 0
    );

    public static AurelianBrooch AurelianBroochCommon
    {
        get;
    } = new(
        name: "Aurelian Brooch",
        tier: ArtifactTier.Tier2,
        rarity: ArtifactRarity.Common,
        effect: 0.25m,
        sockets: 0
    );

    public static AurelianBrooch JeweledAurelianBroochCommon
    {
        get;
    } = new(
        name: "Jeweled Aurelian Brooch",
        tier: ArtifactTier.Tier3,
        rarity: ArtifactRarity.Common,
        effect: 0.50m,
        sockets: 0
    );

    public static AurelianBrooch JeweledAurelianBroochRare
    {
        get;
    } = new(
        name: "Jeweled Aurelian Brooch",
        tier: ArtifactTier.Tier3,
        rarity: ArtifactRarity.Rare,
        effect: 0.60m,
        sockets: 1
    );

    public static AurelianBrooch JeweledAurelianBroochEpic
    {
        get;
    } = new(
        name: "Jeweled Aurelian Brooch",
        tier: ArtifactTier.Tier3,
        rarity: ArtifactRarity.Epic,
        effect: 0.70m,
        sockets: 2
    );

    public static AurelianBrooch EggceptionalAurelianBroochCommon
    {
        get;
    } = new(
        name: "Eggceptional Aurelian Brooch",
        tier: ArtifactTier.Tier4,
        rarity: ArtifactRarity.Common,
        effect: 1.0m,
        sockets: 0
    );

    public static AurelianBrooch EggceptionalAurelianBroochRare
    {
        get;
    } = new(
        name: "Eggceptional Aurelian Brooch",
        tier: ArtifactTier.Tier4,
        rarity: ArtifactRarity.Rare,
        effect: 1.25m,
        sockets: 1
    );

    public static AurelianBrooch EggceptionalAurelianBroochEpic
    {
        get;
    } = new(
        name: "Eggceptional Aurelian Brooch",
        tier: ArtifactTier.Tier4,
        rarity: ArtifactRarity.Epic,
        effect: 1.50m,
        sockets: 2
    );

    public static AurelianBrooch EggceptionalAurelianBroochLegendary
    {
        get;
    } = new(
        name: "Eggceptional Aurelian Brooch",
        tier: ArtifactTier.Tier4,
        rarity: ArtifactRarity.Legendary,
        effect: 2.0m,
        sockets: 3
    );

    // Dilithium Monocle
    public static DilithiumMonocle DilithiumMonocleCommon
    {
        get;
    } = new(
        name: "Dilithium Monocle",
        tier: ArtifactTier.Tier1,
        rarity: ArtifactRarity.Common,
        effect: 0.05m,
        sockets: 0
    );

    public static DilithiumMonocle PreciseDilithiumMonocleCommon
    {
        get;
    } = new(
        name: "Precise Dilithium Monocle",
        tier: ArtifactTier.Tier2,
        rarity: ArtifactRarity.Common,
        effect: 0.10m,
        sockets: 0
    );

    public static DilithiumMonocle EggsactingDilithiumMonocleCommon
    {
        get;
    } = new(
        name: "Eggsacting Dilithium Monocle",
        tier: ArtifactTier.Tier3,
        rarity: ArtifactRarity.Common,
        effect: 0.15m,
        sockets: 0
    );

    public static DilithiumMonocle FlawlessDilithiumMonocleCommon
    {
        get;
    } = new(
        name: "Flawless Dilithium Monocle",
        tier: ArtifactTier.Tier4,
        rarity: ArtifactRarity.Common,
        effect: 0.20m,
        sockets: 0
    );

    public static DilithiumMonocle FlawlessDilithiumMonocleEpic
    {
        get;
    } = new(
        name: "Flawless Dilithium Monocle",
        tier: ArtifactTier.Tier4,
        rarity: ArtifactRarity.Epic,
        effect: 0.25m,
        sockets: 2
    );

    public static DilithiumMonocle FlawlessDilithiumMonocleLegendary
    {
        get;
    } = new(
        name: "Flawless Dilithium Monocle",
        tier: ArtifactTier.Tier4,
        rarity: ArtifactRarity.Legendary,
        effect: 0.30m,
        sockets: 3
    );

    public static IReadOnlyList<Artifact> All
    {
        get;
    } =
        Array.AsReadOnly<Artifact>(
        [
            PlainAurelianBroochCommon,
                AurelianBroochCommon,
                JeweledAurelianBroochCommon,
                JeweledAurelianBroochRare,
                JeweledAurelianBroochEpic,
                EggceptionalAurelianBroochCommon,
                EggceptionalAurelianBroochRare,
                EggceptionalAurelianBroochEpic,
                EggceptionalAurelianBroochLegendary,
            DilithiumMonocleCommon,
                PreciseDilithiumMonocleCommon,
                EggsactingDilithiumMonocleCommon,
                FlawlessDilithiumMonocleCommon,
                FlawlessDilithiumMonocleEpic,
                FlawlessDilithiumMonocleLegendary
        ]);
}