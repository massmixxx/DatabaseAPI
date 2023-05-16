using System.Diagnostics;

namespace DatabaseAPI.Database.Base
{
  // Taka ciekawostka, jeśli przeciążasz ToString aby widzieć pola w debuggerze
  // Lepiej użyć atrybutu [DebuggerDisplay] a to string zostawić do innych celów
  [DebuggerDisplay("To zobaczysz w debugerze zamiast wartości ToSting. Id: {Id}")]
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
