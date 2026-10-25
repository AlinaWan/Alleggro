namespace Alleggro.Artifacts;

public abstract class Artifact
{
    public string Name
    {
        get;
    }

    public ArtifactTier Tier
    {
        get;
    }
    public ArtifactRarity Rarity
    {
        get;
    }
    public decimal Effect
    {
        get;
    }

    public int Sockets
    {
        get;
    }

    protected Artifact(
        string name,
        ArtifactTier tier,
        ArtifactRarity rarity,
        decimal effect,
        int sockets)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        Name = name;
        Tier = tier;
        Rarity = rarity;
        Effect = effect;
        Sockets = sockets;
    }
}