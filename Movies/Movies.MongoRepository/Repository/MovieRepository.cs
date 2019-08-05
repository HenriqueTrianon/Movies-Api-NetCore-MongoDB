using System.Threading.Tasks;
using MongoDB.Bson;
using Movies.Domain.DTO;
using Movies.Domain.Interfaces.Repository;
using Movies.Domain.Models;
using Movies.Mongo.Repository.Context;

namespace Movies.Mongo.Repository.Repository
{
    public class MovieRepository : BaseRepository<MovieDto,string, Movie>, IMovieRepository
    {
        protected override string CollectionName { get; } = "movies";
        public MovieRepository( MoviesContext context) : base(context)
        {

        }

        public override Task Insert(MovieDto dto)
        {
            dto.Id = ObjectId.GenerateNewId().ToString();
            return base.Insert(dto);
        }
    }
}
