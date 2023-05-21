namespace Store.Core.DomainObjects
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            var compareTo = obj as Entity;

            return ReferenceEquals(this, compareTo) || (compareTo is not null && Id.Equals(compareTo.Id));
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }

        public static bool operator !=(Entity? a, Entity? b)
        {
            return !(a == b);
        }

        public static bool operator ==(Entity? a, Entity? b)
        {
            return a is null && b is null || a is not null && b is not null && a.Equals(b);
        }
    }
}