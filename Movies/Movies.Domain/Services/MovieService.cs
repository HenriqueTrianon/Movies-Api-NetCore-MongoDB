using Movies.Domain.Interfaces.Services;

namespace Movies.Domain.Services
{
    public class MovieService:BaseService<MovieService>,IMovieService<MovieService>
    {

    }
}
