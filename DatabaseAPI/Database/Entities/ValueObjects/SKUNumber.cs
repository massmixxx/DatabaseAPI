using System.Text.RegularExpressions;

namespace DatabaseAPI.Database.Entities.ValueObjects
{
  public class SKUNumber : ValueObject
  {
    private const string Pattern = @"^([0-9a-z]{6}|[[0-9A-Z]{6})$";
    public const string ValuePropertyName = nameof(Value);
    protected virtual string Value { get; init; } = null!;

    public SKUNumber() { }

   public SKUNumber(string value)
   {
      if(!Regex.IsMatch(value, Pattern))
      {
        throw new ArgumentException("Passed SKU has got wrong format");
      }

      Value = value;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
      yield return Value;
    }

    public override string ToString()
    {
      return Value;
    }
  }
}
