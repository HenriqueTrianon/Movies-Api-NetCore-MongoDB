using Autofac;
using Movies.Domain.Interfaces.Repository;
using Movies.Mongo.Repository.Context;
using Movies.Mongo.Repository.Repository;

namespace Movies.Infra.IOC.Modules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MovieRepository>().As<IMovieRepository>();
            builder.RegisterType<MoviesContext>()
       .WithParameter(
           (pi, ctx) => pi.ParameterType == typeof(string) && pi.Name == "connection",
           (pi, ctx) => "localhost")
       .WithParameter(
           (pi, ctx) => pi.ParameterType == typeof(string) && pi.Name == "dataBaseName",
           (pi, ctx) => "movies");
            ;
        }
    }
}
