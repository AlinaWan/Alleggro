using System.Numerics;

namespace Alleggro.Currencies;

public readonly record struct Bocks(BigInteger Value)
{
    public static implicit operator BigInteger(Bocks amount) =>
        amount.Value;

    public static implicit operator Bocks(BigInteger value) =>
        new(value);

    public override string ToString() =>
        Value.ToString(System.Globalization.CultureInfo.InvariantCulture);
}