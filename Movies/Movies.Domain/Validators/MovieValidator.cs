using FluentValidation;
using Movies.Domain.DTO;

namespace Movies.Domain.Validators
{
    public class MovieValidator: AbstractValidator<MovieDto>
    {
        public MovieValidator()
        {
            RuleFor(x => x.Name).NotNull().Length(5, 100);
            RuleFor(x => x.Category).NotNull().NotEmpty();
            RuleFor(x => x.Price).NotNull().GreaterThan(0);
            RuleFor(x => x.Author).NotNull().Length(3, 100);
        }
    }
}
