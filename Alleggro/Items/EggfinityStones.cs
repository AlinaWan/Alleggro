using Alleggro.EggfinityStones;

namespace Alleggro.Items;

public static class EggfinityStones
{
    // Dilithium Stone
    public static DilithiumStone DilithiumStoneFragment
    {
        get;
    } = new(
        name: "Dilithium Stone Fragment",
        increase: null
    );

    public static DilithiumStone DilithiumStone
    {
        get;
    } = new(
        name: "Dilithium Stone",
        increase: 0.03m
    );

    public static DilithiumStone EggsquisiteDilithiumStone
    {
        get;
    } = new(
        name: "Eggsquisite Dilithium Stone",
        increase: 0.06m
    );

    public static DilithiumStone BrilliantDilithiumStone
    {
        get;
    } = new(
        name: "Brilliant Dilithium Stone",
        increase: 0.08m
    );

    public static IReadOnlyList<EggfinityStone> All
    {
        get;
    } =
        Array.AsReadOnly<EggfinityStone>(
        [
            DilithiumStoneFragment,
                DilithiumStone,
                EggsquisiteDilithiumStone,
                BrilliantDilithiumStone
        ]);
}