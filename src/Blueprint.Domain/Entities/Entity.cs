using System;
using System.Collections.Generic;

namespace Blueprint.Domain.Entities;

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

    public abstract override int GetHashCode();

    public abstract override bool Equals(object obj);
}

public abstract class Entity<T> : Entity where T : IComparable<T>, IEquatable<T>
{
    protected Entity()
    {
    }

    protected Entity(T id)
        : base() =>
        Id = id;

    public T Id { get; }

    public override int GetHashCode() => (GetRealType().ToString() + Id).GetHashCode();

    public abstract T EmptyValue { get; }

    private Type GetRealType()
    {
        var type = GetType();

        return type.ToString().Contains("Castle.Proxies.") ? type.BaseType : type;
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Entity<T> other))
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
