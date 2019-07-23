using Autofac;
using Movies.Domain.DTO;
using Movies.Domain.Interfaces.Repository;
using Movies.Domain.Interfaces.Services;
using Movies.Domain.Services;
using Movies.Mongo.Repository.Models;
using Movies.Mongo.Repository.Repository;

namespace Movies.Infra.IOC
{
    public class InjectionContainer: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MovieRepository>().As<IMovieRepository<MovieDto,Movie>>();
            builder.RegisterType<MovieService>().As<IMovieService<MovieDto>>();
        }
    }
}
