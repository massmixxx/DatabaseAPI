namespace DatabaseAPI.Database.Base
{
  /// <summary>
  /// Implementing of that interface allows to automatic set modification date while update
  /// </summary>
  public interface IModificationTracked
  {
    DateTime? ModificationDate { get; set; }
  }
}
