namespace Alleggro.Artifacts;

public sealed class AurelianBrooch : Artifact
{
    internal AurelianBrooch(
        string name,
        ArtifactTier tier,
        ArtifactRarity rarity,
        decimal effect,
        int sockets)
        : base(
            name,
            tier,
            rarity,
            effect,
            sockets)
    {
    }
}