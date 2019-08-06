using Bogus;
using Movies.Domain.DTO;

namespace Movies.Tests.Mock
{
    public static class MovieMocker
    {
        private static readonly Faker<MovieDto> _faker = new Faker<MovieDto>()
            .StrictMode(false)
            .RuleFor(o => o.Author, f => f.Name.FirstName())
            .RuleFor(o => o.Name, f => f.Commerce.ProductName())
            .RuleFor(o => o.Price, f => f.Random.Decimal(50, 100))
            .RuleFor(o => o.Category, f => f.Commerce.Categories(3));
        public static MovieDto Get() => _faker.Generate();
        
    }
}
