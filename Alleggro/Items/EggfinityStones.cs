using Alleggro.EggfinityStones;

namespace Alleggro.Items;

public static class EggfinityStones
{
    // Dilithium Stone
    public static EggfinityStone DilithiumStoneFragment
    {
        get;
    } = new(
        name: "Dilithium Stone Fragment",
        type: EggfinityStoneType.DilithiumStone,
        increase: null
    );

    public static EggfinityStone DilithiumStone
    {
        get;
    } = new(
        name: "Dilithium Stone",
        type: EggfinityStoneType.DilithiumStone,
        increase: 0.03m
    );

    public static EggfinityStone EggsquisiteDilithiumStone
    {
        get;
    } = new(
        name: "Egsquisite Dilithium Stone",
        type: EggfinityStoneType.DilithiumStone,
        increase: 0.06m
    );

    public static EggfinityStone BrilliantDilithiumStone
    {
        get;
    } = new(
        name: "Brilliant Dilithium Stone",
        type: EggfinityStoneType.DilithiumStone,
        increase: 0.08m
    );

    public static IReadOnlyList<EggfinityStone> All
    {
        get;
    } =
        Array.AsReadOnly(
        [
            DilithiumStoneFragment,
                DilithiumStone,
                EggsquisiteDilithiumStone,
                BrilliantDilithiumStone
        ]);
}