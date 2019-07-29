using Movies.Domain.DTO;
using Movies.Domain.Models;

namespace Movies.Domain.Interfaces.Services
{
    public interface IMovieService:IService<MovieDto,Movie> 
    {
    }
}
