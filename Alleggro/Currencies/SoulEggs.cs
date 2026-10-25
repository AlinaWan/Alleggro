using System.Numerics;

namespace Alleggro.Currencies;

public readonly record struct SoulEggs(BigInteger Value)
{
    public static implicit operator BigInteger(SoulEggs amount) =>
        amount.Value;

    public static implicit operator SoulEggs(BigInteger value) =>
        new(value);

    public override string ToString() =>
        Value.ToString(System.Globalization.CultureInfo.InvariantCulture);
}