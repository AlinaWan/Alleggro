namespace Alleggro.Artifacts;

public sealed class DilithiumMonocle : Artifact
{
    internal DilithiumMonocle(
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