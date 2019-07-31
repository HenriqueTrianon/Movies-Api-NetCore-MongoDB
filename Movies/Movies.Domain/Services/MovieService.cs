using Movies.Domain.DTO;
using Movies.Domain.Interfaces.Repository;
using Movies.Domain.Interfaces.Services;
using Movies.Domain.Models;
namespace Movies.Domain.Services
{
    public class MovieService:BaseService<MovieDto,string,Movie>,IMovieService
    {
        public MovieService(IMovieRepository repository) : base(repository)
        {
        }
    }
}
