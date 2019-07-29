using AutoMapper;
using Movies.Domain.DTO;
using Movies.Domain.Models;

namespace Movies.Domain.Mapper
{
    public class MoviesDomainProfile:Profile
    {
        public MoviesDomainProfile()
        {
            CreateMap<Movie, MovieDto>().ReverseMap();
        }
    }
}
