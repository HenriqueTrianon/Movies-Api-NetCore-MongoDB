using Movies.Domain.DTO;
using Movies.Domain.Models;

namespace Movies.Domain.Interfaces.Repository
{
    public interface IMovieRepository: IMongoDbRepository<Movie,MovieDto>
    {
    }
}
