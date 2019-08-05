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
        public void InsertNewBookEmptyTest()
        {
            var dto = new MovieDto();
            MovieService.Validate(dto).Wait();
            var task = MovieService.Insert(dto);
            TestOutputHelper.WriteLine($"Inserting...  {dto.Name} - {dto.Author} - {dto.Price}");
            task.Wait();
            TestOutputHelper.WriteLine("Done");
        }
        [Fact]
        public void InsertNewBookTest()
        {
            var dto = MovieMocker.Get();
;            var task = MovieService.Insert(dto);
            TestOutputHelper.WriteLine($"Inserting...  {dto.Name} - {dto.Author} - {dto.Price}");
            task.Wait();
            TestOutputHelper.WriteLine("Done");
        }

        [Fact]
        public void GetAllMovieTest()
        {
            var task = MovieService.GetAll();
            task.Wait();
            var result = task.Result;
            result.ForEach(e => TestOutputHelper.WriteLine($"{e.Author} - {e.Name} - {e.Price}$"));
            Assert.NotNull(result);
        }

        [Fact]
        public void GetAllMovieExpressionTest()
        {
            var task = MovieService.GetAll(e => e.Price > 70);
            task.Wait();
            var result = task.Result;
            foreach (var movieDto in result)
            {
                TestOutputHelper.WriteLine($"{movieDto.Author} - {movieDto.Name}");
            }
            Assert.NotNull(result);
        }

        [Fact]
        public void GetFirstMovieTest()
        {
            var task = MovieService.GetFirstorDefault(e => e.Author.StartsWith("Ca"));
            task.Wait();
            var movie = task.Result;
            if (movie != null)
            {
                TestOutputHelper.WriteLine($"{movie.Author} - {movie.Name}");
            }
            Assert.NotNull(movie);
        }

        [Fact]
        public void GetFirstAndUpdate()
        {
            var task = MovieService.GetFirstorDefault(e => true);
            task.Wait();
            var movie = task.Result;
            if (movie == null)
            {
                return;
            }
            TestOutputHelper.WriteLine($"actual... {movie.Author} - {movie.Name}");
            movie.Author = Faker.Person.FullName;
            movie.Name = Faker.Commerce.ProductAdjective();
            var updateTask = MovieService.Update(movie);
            TestOutputHelper.WriteLine($"changed into...  {movie.Author} - {movie.Name}");
            updateTask.Wait();
            TestOutputHelper.WriteLine("Data Updated");
        }

        [Fact]
        public void DeleteLastOne()
        {
            var task = MovieService.GetLastorDefault(e => true);
            task.Wait();
            var movie = task.Result;
            if (movie == null)
            {
                return;
            }
            TestOutputHelper.WriteLine($"Element to be removed...{movie.Name}");
            var deleteTask = MovieService.DeleteById(movie.Id);
            deleteTask.Wait();
            Assert.True(deleteTask.Result);
        }
    }
}
