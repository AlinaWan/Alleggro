namespace Alleggro.Currencies;

public readonly record struct BoostTokens(int Value)
{
    public static implicit operator int(BoostTokens amount) =>
        amount.Value;

    public static implicit operator BoostTokens(int value) =>
        new(value);

    public override string ToString() =>
        Value.ToString(System.Globalization.CultureInfo.InvariantCulture);
}