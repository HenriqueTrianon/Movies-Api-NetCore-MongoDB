using Bogus;
using Movies.Domain.DTO;

namespace Movies.Tests.Mock
{
    public static class MovieMocker
    {
        private static readonly Faker<MovieDto> _faker = new Faker<MovieDto>()
            //Ensure all properties have rules. By default, StrictMode is false
            //Set a global policy by using Faker.DefaultStrictMode
            .StrictMode(true)
            //OrderId is deterministic
            .RuleFor(o => o.Id, f => f.Random.Hash())
            //Pick some fruit from a basket
            .RuleFor(o => o.Author, f => f.Name.FirstName())
            //A random quantity from 1 to 10
            .RuleFor(o => o.Name, f => f.Commerce.ProductName())
            //A nullable int? with 80% probability of being null.
            //The .OrNull extension is in the Bogus.Extensions namespace.
            .RuleFor(o => o.Price, f => f.Random.Decimal(50, 100))
            .RuleFor(o => o.Category, f => f.Commerce.Categories(3));

        public static MovieDto Get() => _faker.Generate();
        
    }
}
