using Autofac;
using Movies.Domain.Interfaces.Repository;
using Movies.Mongo.Repository.Repository;

namespace Movies.Infra.IOC.Modules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MovieRepository>().As<IMovieRepository>();
        }
    }
}
