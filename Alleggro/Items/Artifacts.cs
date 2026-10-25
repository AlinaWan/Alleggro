using Alleggro.Artifacts;

namespace Alleggro.Items;

public static class Artifacts
{
    // Aurelian Brooch
    public static Artifact PlainAurelianBroochCommon
    {
        get;
    } = new(
        name: "Plain Aurelian Brooch",
        type: ArtifactType.AurelianBrooch,
        tier: ArtifactTier.Tier1,
        rarity: ArtifactRarity.Common,
        effect: 0.10m,
        sockets: 0
    );

    public static Artifact AurelianBroochCommon
    {
        get;
    } = new(
        name: "Aurelian Brooch",
        type: ArtifactType.AurelianBrooch,
        tier: ArtifactTier.Tier2,
        rarity: ArtifactRarity.Common,
        effect: 0.25m,
        sockets: 0
    );

    public static Artifact JeweledAurelianBroochCommon
    {
        get;
    } = new(
        name: "Jeweled Aurelian Brooch",
        type: ArtifactType.AurelianBrooch,
        tier: ArtifactTier.Tier3,
        rarity: ArtifactRarity.Common,
        effect: 0.50m,
        sockets: 0
    );

    public static Artifact JeweledAurelianBroochRare
    {
        get;
    } = new(
        name: "Jeweled Aurelian Brooch",
        type: ArtifactType.AurelianBrooch,
        tier: ArtifactTier.Tier3,
        rarity: ArtifactRarity.Rare,
        effect: 0.60m,
        sockets: 1
    );

    public static Artifact JeweledAurelianBroochEpic
    {
        get;
    } = new(
        name: "Jeweled Aurelian Brooch",
        type: ArtifactType.AurelianBrooch,
        tier: ArtifactTier.Tier3,
        rarity: ArtifactRarity.Epic,
        effect: 0.70m,
        sockets: 2
    );

    public static Artifact EggceptionalAurelianBroochCommon
    {
        get;
    } = new(
        name: "Eggceptional Aurelian Brooch",
        type: ArtifactType.AurelianBrooch,
        tier: ArtifactTier.Tier4,
        rarity: ArtifactRarity.Common,
        effect: 1.0m,
        sockets: 0
    );

    public static Artifact EggceptionalAurelianBroochRare
    {
        get;
    } = new(
        name: "Eggceptional Aurelian Brooch",
        type: ArtifactType.AurelianBrooch,
        tier: ArtifactTier.Tier4,
        rarity: ArtifactRarity.Rare,
        effect: 1.25m,
        sockets: 1
    );

    public static Artifact EggceptionalAurelianBroochEpic
    {
        get;
    } = new(
        name: "Eggceptional Aurelian Brooch",
        type: ArtifactType.AurelianBrooch,
        tier: ArtifactTier.Tier4,
        rarity: ArtifactRarity.Epic,
        effect: 1.50m,
        sockets: 2
    );

    public static Artifact EggceptionalAurelianBroochLegendary
    {
        get;
    } = new(
        name: "Eggceptional Aurelian Brooch",
        type: ArtifactType.AurelianBrooch,
        tier: ArtifactTier.Tier4,
        rarity: ArtifactRarity.Legendary,
        effect: 2.0m,
        sockets: 3
    );

    // Dilithium Monocle
    public static Artifact DilithiumMonocleCommon
    {
        get;
    } = new(
        name: "Dilithium Monocle",
        type: ArtifactType.DilithiumMonocle,
        tier: ArtifactTier.Tier1,
        rarity: ArtifactRarity.Common,
        effect: 0.05m,
        sockets: 0
    );

    public static Artifact PreciseDilithiumMonocleCommon
    {
        get;
    } = new(
        name: "Precise Dilithium Monocle",
        type: ArtifactType.DilithiumMonocle,
        tier: ArtifactTier.Tier2,
        rarity: ArtifactRarity.Common,
        effect: 0.10m,
        sockets: 0
    );

    public static Artifact EggsactingDilithiumMonocleCommon
    {
        get;
    } = new(
        name: "Eggsacting Dilithium Monocle",
        type: ArtifactType.DilithiumMonocle,
        tier: ArtifactTier.Tier3,
        rarity: ArtifactRarity.Common,
        effect: 0.15m,
        sockets: 0
    );

    public static Artifact FlawlessDilithiumMonocleCommon
    {
        get;
    } = new(
        name: "Flawless Dilithium Monocle",
        type: ArtifactType.DilithiumMonocle,
        tier: ArtifactTier.Tier4,
        rarity: ArtifactRarity.Common,
        effect: 0.20m,
        sockets: 0
    );

    public static Artifact FlawlessDilithiumMonocleEpic
    {
        get;
    } = new(
        name: "Flawless Dilithium Monocle",
        type: ArtifactType.DilithiumMonocle,
        tier: ArtifactTier.Tier4,
        rarity: ArtifactRarity.Epic,
        effect: 0.25m,
        sockets: 2
    );

    public static Artifact FlawlessDilithiumMonocleLegendary
    {
        get;
    } = new(
        name: "Flawless Dilithium Monocle",
        type: ArtifactType.DilithiumMonocle,
        tier: ArtifactTier.Tier4,
        rarity: ArtifactRarity.Legendary,
        effect: 0.30m,
        sockets: 3
    );

    public static IReadOnlyList<Artifact> All
    {
        get;
    } =
        Array.AsReadOnly(
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