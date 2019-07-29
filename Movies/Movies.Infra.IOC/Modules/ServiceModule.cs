using Autofac;
using Movies.Domain.Interfaces.Services;
using Movies.Domain.Services;

namespace Movies.Infra.IOC
{
    public class ServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MovieService>().As<IMovieService>();
           
        }
    }
}
