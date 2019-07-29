using System;
using Autofac;
using AutoMapper.Configuration.Annotations;
using Movies.Domain.Interfaces.Services;
using Movies.Tests.Mock;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Movies.Tests.Services
{
    public class MovieServiceTest:BaseTest
    {
        private IMovieService MovieService { get; }
        private ITestOutputHelper TestOutputHelper { get; }
        public MovieServiceTest()
        {
            MovieService = container.Resolve<IMovieService>();
            TestOutputHelper = new TestOutputHelper();
        }
   
        [Fact]
        public void InsertNewBookTest()
        {
            var task = MovieService.Insert(MovieMocker.Get());
            task.Wait();
        }

        [Fact]
        public void GetBookTest()
        {
            var task = MovieService.GetAllAsync();
            task.Wait();
            foreach (var movieDto in task.Result)
            {
                TestOutputHelper.WriteLine(movieDto.BookName);
            }
        }
    }
}
