using FluentValidation;
using Movies.Domain.DTO;

namespace Movies.Domain.Validators
{
    public class MovieValidator: AbstractValidator<MovieDto>
    {
        public MovieValidator()
        {
            RuleFor(x => x.Name).Length(5, 100);
            RuleFor(x => x.Category).NotEmpty();
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.Author).Length(3, 100);
        }
    }
}
