using AutoMapper;
using Movies.Domain.DTO;
using Movies.Domain.Interfaces.Repository;
using Movies.Domain.Interfaces.Services;
using Movies.Domain.Models;

namespace Movies.Domain.Services
{
    public class MovieService:BaseService<MovieDto,Movie>,IMovieService
    {
        public MovieService(IMovieRepository Repo) : base(Repo)
        {
        }
    }
}
