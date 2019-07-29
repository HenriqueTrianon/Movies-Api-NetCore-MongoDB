
using Autofac;
using Movies.Infra.IOC.Modules;

namespace Movies.Infra.IOC.Containers
{
    public class MovieContainerBuilder
    {
        public static IContainer Build()
        {
            var builder = new ContainerBuilder();
            RegisterTypes(builder);
            return builder.Build();
        }

        private static void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterModule<MapperModule>();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<ServiceModule>();
        }
    }
}
