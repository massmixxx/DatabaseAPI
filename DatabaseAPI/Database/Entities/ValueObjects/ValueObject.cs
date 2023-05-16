namespace DatabaseAPI.Database.Entities.ValueObjects
{
    // From: https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects
    public abstract class ValueObject
    {
        public static bool operator !=(ValueObject? obj1, ValueObject? obj2) => !(obj1 == obj2);

        public static bool operator ==(ValueObject? obj1, ValueObject? obj2)
        {
            if (Equals(obj1, null))
            {
                if (Equals(obj2, null))
                {
                    return true;
                }

                return false;
            }

            return obj1.Equals(obj2);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            ValueObject other = (ValueObject)obj;
            using IEnumerator<object?> thisValues = GetEqualityComponents().GetEnumerator();
            using IEnumerator<object?> otherValues = other.GetEqualityComponents().GetEnumerator();

            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (thisValues.Current is null ^ otherValues.Current is null)
                {
                    return false;
                }

                if (thisValues.Current is not null &&
                    !thisValues.Current.Equals(otherValues.Current))
                {
                    return false;
                }
            }

            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }

        public override int GetHashCode() =>
          GetEqualityComponents()
          .Select(x => x?.GetHashCode() ?? 0)
          .Aggregate((x, y) => x ^ y);

        protected static bool EqualOperator(ValueObject? left, ValueObject? right)
        {
            if (left is null ^ right is null)
            {
                return false;
            }

            return left?.Equals(right) != false;
        }

        protected static bool NotEqualOperator(ValueObject? left, ValueObject? right) => !EqualOperator(left, right);

        protected abstract IEnumerable<object?> GetEqualityComponents();
    }
}
