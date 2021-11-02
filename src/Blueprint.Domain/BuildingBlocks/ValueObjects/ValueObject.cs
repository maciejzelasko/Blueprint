using System.Reflection;

namespace Blueprint.Domain.BuildingBlocks.ValueObjects;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public bool Equals(ValueObject other) => Equals(other as object);

    public override abstract int GetHashCode();

    public static bool operator ==(ValueObject obj1, ValueObject obj2)
    {
        return obj1?.Equals(obj2) ?? Equals(obj2, null);
    }

    public static bool operator !=(ValueObject obj1, ValueObject obj2)
    {
        return !(obj1 == obj2);
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        return GetEqualityProperties().Select(p => GetType().GetProperty(p)).All(p => PropertiesAreEqual(obj, p));
    }

    protected abstract IEnumerable<string> GetEqualityProperties();

    private bool PropertiesAreEqual(object obj, PropertyInfo p) => Equals(p.GetValue(this, null), p.GetValue(obj, null));
}
