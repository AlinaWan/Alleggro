using Alleggro.Boosts;

namespace Alleggro.Items;

public static class Boosts
{
    public static Boost TachyonPrism
    {
        get;
    } = new(
        name: "Tachyon Prism",
        type: BoostType.TachyonPrism,
        multiplier: 10,
        duration: TimeSpan.FromMinutes(10),
        cost: 50
    );

    public static Boost LargeTachyonPrism
    {
        get;
    } = new(
        name: "Large Tachyon Prism",
        type: BoostType.TachyonPrism,
        multiplier: 10,
        duration: TimeSpan.FromMinutes(240),
        cost: 500
    );

    public static Boost PowerfulTachyonPrism
    {
        get;
    } = new(
        name: "Powerful Tachyon Prism",
        type: BoostType.TachyonPrism,
        multiplier: 100,
        duration: TimeSpan.FromMinutes(10),
        cost: 1000
    );

    public static Boost EpicTachyonPrism
    {
        get;
    } = new(
        name: "Epic Tachyon Prism",
        type: BoostType.TachyonPrism,
        multiplier: 100,
        duration: TimeSpan.FromMinutes(120),
        cost: 5000
    );

    public static Boost LegendaryTachyonPrism
    {
        get;
    } = new(
        name: "Legendary Tachyon Prism",
        type: BoostType.TachyonPrism,
        multiplier: 1000,
        duration: TimeSpan.FromMinutes(10),
        cost: 12000
    );

    public static Boost SupremeTachyonPrism
    {
        get;
    } = new(
        name: "Supreme Tachyon Prism",
        type: BoostType.TachyonPrism,
        multiplier: 1000,
        duration: TimeSpan.FromMinutes(60),
        cost: 25000
    );

    public static Boost BoostBeacon
    {
        get;
    } = new(
        name: "Boost Beacon",
        type: BoostType.BoostBeacon,
        multiplier: 2,
        duration: TimeSpan.FromMinutes(30),
        cost: 1000
    );

    public static Boost EpicBoostBeacon
    {
        get;
    } = new(
        name: "Epic Boost Beacon",
        type: BoostType.BoostBeacon,
        multiplier: 10,
        duration: TimeSpan.FromMinutes(10),
        cost: 8000
    );

    public static Boost LargeBoostBeacon
    {
        get;
    } = new(
        name: "Large Boost Beacon",
        type: BoostType.BoostBeacon,
        multiplier: 5,
        duration: TimeSpan.FromMinutes(60),
        cost: 15000
    );

    public static Boost LegendaryBoostBeacon
    {
        get;
    } = new(
        name: "Legendary Boost Beacon",
        type: BoostType.BoostBeacon,
        multiplier: 50,
        duration: TimeSpan.FromMinutes(10),
        cost: 50000
    );

    public static IReadOnlyList<Boost> All
    {
        get;
    } =
        Array.AsReadOnly(
        [
            TachyonPrism,
            LargeTachyonPrism,
            PowerfulTachyonPrism,
            EpicTachyonPrism,
            LegendaryTachyonPrism,
            SupremeTachyonPrism,
            BoostBeacon,
            EpicBoostBeacon,
            LargeBoostBeacon,
            LegendaryBoostBeacon
        ]);
}