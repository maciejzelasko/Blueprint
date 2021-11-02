namespace Blueprint.Domain.BuildingBlocks.Entities;

public abstract class Entity
{
    private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

    protected Entity()
    {
    }

    protected void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);

    public void ClearDomainEvents() => _domainEvents.Clear();

    public static bool operator ==(Entity a, Entity b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(Entity a, Entity b) => !(a == b);

    public override abstract int GetHashCode();

    public override abstract bool Equals(object obj);
}

public abstract class Entity<TId> : Entity where TId : IComparable<TId>, IEquatable<TId>
{
    protected Entity()
    {
    }

    protected Entity(TId id) : base() => Id = id;

    public TId Id { get; }

    public override int GetHashCode() => ($"{GetRealType()}{Id}").GetHashCode();

    public abstract TId EmptyValue { get; }

    private Type GetRealType()
    {
        var type = GetType();

        return type.ToString().Contains("Castle.Proxies.") ? type.BaseType : type;
    }

    public override bool Equals(object obj)
    {
        if (obj is not Entity<TId> other)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetRealType() != other.GetRealType())
            return false;

        if (Id.Equals(EmptyValue) || other.Id.Equals(EmptyValue))
            return false;

        return Id.Equals(other.Id);
    }
}
