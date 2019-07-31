using System;
using System.Linq;
using Autofac;
using Movies.Domain.Interfaces.Services;
using Movies.Tests.Mock;
using Xunit;
using Xunit.Abstractions;

namespace Movies.Tests.Services
{
    public class MovieServiceTest:BaseTest
    {
        private IMovieService MovieService { get; }
        private ITestOutputHelper TestOutputHelper { get; }
        public MovieServiceTest(ITestOutputHelper output)
        {
            MovieService = container.Resolve<IMovieService>();
            TestOutputHelper = output;
        }
   
        [Fact]
        public void InsertNewBookTest()
        {
            var task = MovieService.Insert(MovieMocker.Get());
            task.Wait();
            TestOutputHelper.WriteLine($"Inicializado");
        }
        [Fact]
        public void GetAllBookTest()
        {
            var task = MovieService.GetAll();
            task.Wait();
            var result = task.Result;
            foreach (var movieDto in result)
            {
                TestOutputHelper.WriteLine($"{movieDto.Author} - {movieDto.Name}");
            }
        }
        [Fact]
        public void GetAllBookExpressionTest()
        {
            var task = MovieService.GetAll(e => e.Price > 70);
            task.Wait();
            var result = task.Result;
            foreach (var movieDto in result)
            {
                TestOutputHelper.WriteLine($"{movieDto.Author} - {movieDto.Name}");
            }
        }
        [Fact]
        public void GetFirstBookTest()
        {
            var task = MovieService.GetFirstorDefault(e => e.Author.StartsWith("Ca"));
            task.Wait();
            var movie = task.Result;
            if (movie == null)
            {
                return;
            }
            TestOutputHelper.WriteLine($"{movie.Author} - {movie.Name}");
        }
    }
}
