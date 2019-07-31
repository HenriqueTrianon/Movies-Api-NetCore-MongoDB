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
        }

        [Fact]
        public void GetAllBookTest()
        {
            var task = MovieService.GetAllAsync();
            task.Wait();
            var result = task.Result;
            foreach (var movieDto in result)
            {
                TestOutputHelper.WriteLine($"{movieDto.Author} - {movieDto.BookName}");
            }
        }

        [Fact]
        public void GetFirstBookTest()
        {

        }
    }
}
