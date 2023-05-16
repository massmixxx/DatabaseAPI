namespace DatabaseAPI.Database.Base
{
  public abstract class Entity
  {
    public virtual int Id { get; set; }

    public bool Equals(Entity? other) =>
  other is not null && Id.Equals(other.Id);

    public override bool Equals(object? other) =>
      other is Entity entity
        ? Equals(entity)
        : base.Equals(other);

    public override int GetHashCode() => Id;

    public override string ToString()
    {
      return $"{nameof(Id)}: {Id}";
    }
  }
}
