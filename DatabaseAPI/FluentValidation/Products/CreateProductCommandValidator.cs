using DatabaseAPI.Models.Commands.Products;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DatabaseAPI.FluentValidation.Products
{
  public static class SKUFormatChecker
  {
    public const string Pattern = @"^([A-Z0-9]{6}|[a-z0-9]{6})$";
    public static bool Check(string value)
    {
      return !string.IsNullOrEmpty(value) && Regex.IsMatch(value, Pattern);
    }
  }

  public class CreateProductCommandValidator : AbstractValidator<ProductCreateCommand>
  {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.CategoryId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.SKU).NotEmpty().Must(SKUFormatChecker.Check);
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
