namespace Alleggro.Currencies;

public readonly record struct GoldenEggs(long Value)
{
    public static implicit operator long(GoldenEggs amount) =>
        amount.Value;

    public static implicit operator GoldenEggs(long value) =>
        new(value);

    public override string ToString() =>
        Value.ToString(System.Globalization.CultureInfo.InvariantCulture);
}