using AutoMapper;
using MongoDB.Driver;
using Movies.Domain.DTO;
using Movies.Domain.Interfaces.Repository;
using Movies.Domain.Models;

namespace Movies.Mongo.Repository.Repository
{
    public class MovieRepository : BaseRepository<MovieDto, Movie>, IMovieRepository
    {
        protected override string DatabaseName { get; } = "movieapi";
        protected override string CollectionName { get; } = "movies";
        public MovieRepository(IMongoClient client, IMapper mapper) : base(client, mapper)
        {

        }

    }
}
