using CSharpBackend.DTOs;
using FluentValidation;

namespace CSharpBackend.Validators
{
    public class BeerInsertValidator : AbstractValidator<BeerInsertDto>
    {
        public BeerInsertValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
