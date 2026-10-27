using System.Numerics;
using Alleggro.Boosts;

namespace Alleggro.Items;

public static class Boosts
{
    // Bird Feed
    public static BirdFeed JimbosExcellentBirdFeed
    {
        get;
    } = new(
        name: "Jimbo's Excellent Bird Feed",
        multiplier: 3,
        duration: TimeSpan.FromMinutes(20),
        cost: 50,
        soulEggsRequirement: (BigInteger)0,
        boostTokensCost: 0
    );

    public static BirdFeed JimbosExcellentBirdFeedBig
    {
        get;
    } = new(
        name: "Jimbo's Excellent Bird Feed",
        multiplier: 3,
        duration: TimeSpan.FromMinutes(240),
        cost: null,
        soulEggsRequirement: (BigInteger)0,
        boostTokensCost: 1
    );

    public static BirdFeed JimbosPremiumBirdFeed
    {
        get;
    } = new(
        name: "Jimbo's Premium Bird Feed",
        multiplier: 10,
        duration: TimeSpan.FromMinutes(15),
        cost: 150,
        soulEggsRequirement: (BigInteger)1,
        boostTokensCost: 1
    );

    public static BirdFeed JimbosPremiumBirdFeedBig
    {
        get;
    } = new(
        name: "Jimbo's Premium Bird Feed",
        multiplier: 10,
        duration: TimeSpan.FromMinutes(180),
        cost: 750,
        soulEggsRequirement: (BigInteger)1,
        boostTokensCost: 1
    );

    public static BirdFeed JimbosBestBirdFeed
    {
        get;
    } = new(
        name: "Jimbo's Best Bird Feed",
        multiplier: 50,
        duration: TimeSpan.FromMinutes(10),
        cost: 2500,
        soulEggsRequirement: (BigInteger)100,
        boostTokensCost: 2
    );

    public static BirdFeed JimbosBestBirdFeedBig
    {
        get;
    } = new(
        name: "Jimbo's Best Bird Feed",
        multiplier: 50,
        duration: TimeSpan.FromMinutes(120),
        cost: 7500,
        soulEggsRequirement: (BigInteger)100,
        boostTokensCost: 3
    );

    // Tachyon Prism
    public static TachyonPrism TachyonPrism
    {
        get;
    } = new(
        name: "Tachyon Prism",
        multiplier: 10,
        duration: TimeSpan.FromMinutes(10),
        cost: 50,
        soulEggsRequirement: (BigInteger)0,
        boostTokensCost: 0
    );

    public static TachyonPrism LargeTachyonPrism
    {
        get;
    } = new(
        name: "Large Tachyon Prism",
        multiplier: 10,
        duration: TimeSpan.FromMinutes(240),
        cost: 500,
        soulEggsRequirement: (BigInteger)0,
        boostTokensCost: 0
    );

    public static TachyonPrism PowerfulTachyonPrism
    {
        get;
    } = new(
        name: "Powerful Tachyon Prism",
        multiplier: 100,
        duration: TimeSpan.FromMinutes(10),
        cost: 1000,
        soulEggsRequirement: (BigInteger)0,
        boostTokensCost: 2
    );

    public static TachyonPrism EpicTachyonPrism
    {
        get;
    } = new(
        name: "Epic Tachyon Prism",
        multiplier: 100,
        duration: TimeSpan.FromMinutes(120),
        cost: 5000,
        soulEggsRequirement: (BigInteger)100,
        boostTokensCost: 2
    );

    public static TachyonPrism LegendaryTachyonPrism
    {
        get;
    } = new(
        name: "Legendary Tachyon Prism",
        multiplier: 1000,
        duration: TimeSpan.FromMinutes(10),
        cost: 12000,
        soulEggsRequirement: (BigInteger)2500,
        boostTokensCost: 4
    );

    public static TachyonPrism SupremeTachyonPrism
    {
        get;
    } = new(
        name: "Supreme Tachyon Prism",
        multiplier: 1000,
        duration: TimeSpan.FromMinutes(60),
        cost: 25000,
        soulEggsRequirement: (BigInteger)100000,
        boostTokensCost: 4
    );

    // Boost Beacon
    public static BoostBeacon BoostBeacon
    {
        get;
    } = new(
        name: "Boost Beacon",
        multiplier: 2,
        duration: TimeSpan.FromMinutes(30),
        cost: 1000,
        soulEggsRequirement: (BigInteger)1000,
        boostTokensCost: 1
    );

    public static BoostBeacon EpicBoostBeacon
    {
        get;
    } = new(
        name: "Epic Boost Beacon",
        multiplier: 10,
        duration: TimeSpan.FromMinutes(10),
        cost: 8000,
        soulEggsRequirement: (BigInteger)100000,
        boostTokensCost: 4
    );

    public static BoostBeacon LargeBoostBeacon
    {
        get;
    } = new(
        name: "Large Boost Beacon",
        multiplier: 5,
        duration: TimeSpan.FromMinutes(60),
        cost: 15000,
        soulEggsRequirement: (BigInteger)500000,
        boostTokensCost: 3
    );

    public static BoostBeacon LegendaryBoostBeacon
    {
        get;
    } = new(
        name: "Legendary Boost Beacon",
        multiplier: 50,
        duration: TimeSpan.FromMinutes(10),
        cost: 50000,
        soulEggsRequirement: (BigInteger)100000000,
        boostTokensCost: 8
    );

    // Soul Beacon
    public static SoulBeacon SoulBeacon
    {
        get;
    } = new(
        name: "Soul Beacon",
        multiplier: 5,
        duration: TimeSpan.FromMinutes(30),
        cost: 200,
        soulEggsRequirement: (BigInteger)10000,
        boostTokensCost: null
    );

    public static SoulBeacon EpicSoulBeacon
    {
        get;
    } = new(
        name: "Epic Soul Beacon",
        multiplier: 50,
        duration: TimeSpan.FromMinutes(20),
        cost: 1000,
        soulEggsRequirement: (BigInteger)1000000,
        boostTokensCost: null
    );

    public static SoulBeacon LegendarySoulBeacon
    {
        get;
    } = new(
        name: "Legendary Soul Beacon",
        multiplier: 50,
        duration: TimeSpan.FromMinutes(10),
        cost: 10000,
        soulEggsRequirement: (BigInteger)10000000000,
        boostTokensCost: null
    );

    // Subsidy Application
    public static SubsidyApplication SubsidyApplication
    {
        get;
    } = new(
        name: "Subsidy Application",
        increase: 0.1m,
        cost: 200,
        soulEggsRequirement: (BigInteger)0,
        boostTokensCost: 1
    );

    public static SubsidyApplication BlankCheck
    {
        get;
    } = new(
        name: "Blank Check",
        increase: 1.0m,
        cost: 750,
        soulEggsRequirement: (BigInteger)100000,
        boostTokensCost: 1
    );

    public static SubsidyApplication MoneyPrinter
    {
        get;
    } = new(
        name: "Money Printer",
        increase: 5.0m,
        cost: 2500,
        soulEggsRequirement: (BigInteger)5000000,
        boostTokensCost: 2
    );

    // Soul Mirror
    public static SoulMirror SoulMirror
    {
        get;
    } = new(
        name: "Soul Mirror",
        duration: TimeSpan.FromMinutes(10),
        cost: 100,
        soulEggsRequirement: (BigInteger)1000,
        boostTokensCost: 1
    );

    public static SoulMirror EpicSoulMirror
    {
        get;
    } = new(
        name: "Epic Soul Mirror",
        duration: TimeSpan.FromMinutes(60),
        cost: 500,
        soulEggsRequirement: (BigInteger)1000,
        boostTokensCost: 2
    );

    public static SoulMirror LegendarySoulMirror
    {
        get;
    } = new(
        name: "Legendary Soul Mirror",
        duration: TimeSpan.FromMinutes(1440),
        cost: 2000,
        soulEggsRequirement: (BigInteger)10000,
        boostTokensCost: 3
    );

    public static IReadOnlyList<Boost> All
    {
        get;
    } =
        Array.AsReadOnly<Boost>(
        [
            JimbosExcellentBirdFeed,
                JimbosExcellentBirdFeedBig,
                JimbosPremiumBirdFeed,
                JimbosPremiumBirdFeedBig,
                JimbosBestBirdFeed,
                JimbosBestBirdFeedBig,
            TachyonPrism,
                LargeTachyonPrism,
                PowerfulTachyonPrism,
                EpicTachyonPrism,
                LegendaryTachyonPrism,
                SupremeTachyonPrism,
            BoostBeacon,
                EpicBoostBeacon,
                LargeBoostBeacon,
                LegendaryBoostBeacon,
            SoulBeacon,
                EpicSoulBeacon,
                LegendarySoulBeacon,
            SubsidyApplication,
                BlankCheck,
                MoneyPrinter,
            SoulMirror,
                EpicSoulMirror,
                LegendarySoulMirror
        ]);
}