namespace Alleggro.Currencies;

public readonly record struct GoldenEggs(int Value)
{
    public static implicit operator int(GoldenEggs amount) =>
        amount.Value;

    public static implicit operator GoldenEggs(int value) =>
        new(value);

    public override string ToString() =>
        Value.ToString(System.Globalization.CultureInfo.InvariantCulture);
}