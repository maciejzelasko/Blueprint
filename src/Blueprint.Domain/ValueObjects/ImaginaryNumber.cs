namespace Blueprint.Domain.ValueObjects;

public class ImaginaryNumber : ValueObject
{
    public ImaginaryNumber(double realNumber, double imaginaryUnit)
    {
        RealNumber = realNumber;
        ImaginaryUnit = imaginaryUnit;
    }

    public double RealNumber { get; }

    public double ImaginaryUnit { get; }

    public override int GetHashCode()
    {
        return HashCode.Combine(RealNumber, ImaginaryUnit);
    }

    protected override IEnumerable<string> GetEqualityProperties()
    {
        yield return nameof(RealNumber);
        yield return nameof(ImaginaryUnit);
    }
}
