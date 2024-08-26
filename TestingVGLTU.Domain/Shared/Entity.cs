﻿namespace TestingVGLTU.Domain.Shared
{
    public abstract class Entity<TId> where TId : notnull
    {
        protected Entity(TId id) => Id = id;

        public TId Id { get; private set; }

        public override bool Equals(object? obj)
        {
            if (obj is not Entity<TId> other)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return (GetType().FullName + Id).GetHashCode();
        }

        public static bool operator ==(Entity<TId> left, Entity<TId> right)
        {
            if (left is null && right is null)
                return true;

            if (left is null || right is null)
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(Entity<TId> left, Entity<TId> right) => !(left == right);

    }
}
