using System;
using System.Collections.Generic;

namespace Blueprint.Domain.ValueObjects
{
    public class ImaginaryNumber : ValueObject
    {
        public ImaginaryNumber(double realNumber, double imaginaryUnit)
        {
            RealNumber = realNumber;
            ImaginaryUnit = imaginaryUnit;
        }

        public double RealNumber { get; }

        public double ImaginaryUnit { get; }

        protected override IEnumerable<string> GetEqualityProperties()
        {
            yield return nameof(RealNumber);
            yield return nameof(ImaginaryUnit);
        }

        protected override int GetHashCodeValue()
        {
            return HashCode.Combine(RealNumber, ImaginaryUnit);
        }
    }
}