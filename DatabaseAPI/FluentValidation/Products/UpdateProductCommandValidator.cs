using DatabaseAPI.Models.Commands.Products;
using FluentValidation;

namespace DatabaseAPI.FluentValidation.Products
{
  public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
  {
        public UpdateProductCommandValidator()
        {
          RuleFor(x => x.CategoryId).NotEmpty().GreaterThan(0);
          RuleFor(x => x.SKU).NotEmpty().Must(SKUFormatChecker.Check);
          RuleFor(x => x.Name).NotEmpty();
        }
    }
}
