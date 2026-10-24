namespace Alleggro.Currencies;

public readonly record struct Bocks(int Value)
{
    public static implicit operator int(Bocks amount) =>
        amount.Value;

    public static implicit operator Bocks(int value) =>
        new(value);

    public override string ToString() =>
        Value.ToString(System.Globalization.CultureInfo.InvariantCulture);
}