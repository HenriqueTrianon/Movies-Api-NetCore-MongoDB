using MongoDB.Driver;
using Movies.Domain.DTO;
using Movies.Domain.Interfaces.Repository;
using Movies.Mongo.Repository.Models;

namespace Movies.Mongo.Repository.Repository
{
    public class MovieRepository:BaseRepository<MovieDto,Movie>,IMovieRepository<Movie,MovieDto>
    {
        protected override string DatabaseName { get; } = "movieapi";
        protected override string CollectionName { get; } = "movies";
        private IMongoCollection<Movie> MoviesCollection { get; }
        public MovieRepository(IMongoClient client) : base(client)
        {

        }
    }
}
