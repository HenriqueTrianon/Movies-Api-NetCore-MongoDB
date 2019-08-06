using System;
using Autofac;
using Bogus;
using Movies.Domain.DTO;
using Movies.Domain.Interfaces.Services;
using Movies.Tests.Mock;
using Xunit;
using Xunit.Abstractions;

namespace Movies.Tests.Services
{
    public class MovieServiceTest : BaseTest
    {
        private IMovieService MovieService { get; }
        private ITestOutputHelper TestOutputHelper { get; }
        private Faker Faker { get; }
        public MovieServiceTest(ITestOutputHelper output)
        {
            MovieService = container.Resolve<IMovieService>();
            TestOutputHelper = output;
            Faker = new Faker();
        }
        [Fact]
        public async void InsertEmptyMovieTest()
        {
            var dto = new MovieDto();
            var task = MovieService.Insert(dto);
            await Assert.ThrowsAsync<FluentValidation.ValidationException>(async () => await task);
        }
        [Fact]
        public async void InsertNewBookTest()
        {
            var dto = MovieMocker.Get();
            await MovieService.Insert(dto);
        }

        [Fact]
        public async void GetAllMovieTest()
        {
            var result = await MovieService.GetAll();
            Assert.NotNull(result);
        }

        [Fact]
        public async void GetAllMovieExpressionTest()
        {
            var result = await MovieService.GetAll(e => e.Price > 70);
            Assert.NotNull(result);
        }

        [Fact]
        public async void GetFirstMovieTest()
        {
            var movie = await MovieService.GetFirstorDefault(e => true);
            Assert.NotNull(movie);
            TestOutputHelper.WriteLine($"{movie.Author} - {movie.Name}");
        }

        [Fact]
        public async void GetFirstAndUpdate()
        {
            var movie = await MovieService.GetFirstorDefault(e => true);
            Assert.NotNull(movie);
            TestOutputHelper.WriteLine($"actual... {movie.Author} - {movie.Name}");
            movie.Author = Faker.Person.FullName;
            movie.Name = Faker.Commerce.ProductAdjective();
            var updateTask = MovieService.Update(movie);
            updateTask.Wait();
            TestOutputHelper.WriteLine($"changed into...  {movie.Author} - {movie.Name}");
        }

        [Fact]
        public async void DeleteLastOne()
        {
            var movie = await MovieService.GetLastorDefault(e => true);
            Assert.NotNull(movie);
            TestOutputHelper.WriteLine($"The movie {movie.Name} of {movie.Author} has been removed.");
            var deleteTask = MovieService.DeleteById(movie.Id);
            deleteTask.Wait();
            Assert.True(deleteTask.Result);
        }
    }
}
