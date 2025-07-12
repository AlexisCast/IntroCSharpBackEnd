using CSharpBackend.DTOs;
using FluentValidation;

namespace CSharpBackend.Validators
{
    public class BeerUpdateValidator : AbstractValidator<BeerUpdateDto>
    {
        public BeerUpdateValidator()
        {

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name field is required");
            RuleFor(x => x.Name)
                .Length(3, 20).WithMessage("Name must be between 3 and 20 characters long");
            RuleFor(x => x.BrandId)
                .NotNull().WithMessage("BrandId must is required");
            RuleFor(x => x.BrandId)
                .GreaterThan(0).WithMessage("Error with the BrandId");
            RuleFor(x => x.Alcohol)
                .GreaterThan(0).WithMessage("The {PropertyName} must be greater than 0");
        }
    }
}
