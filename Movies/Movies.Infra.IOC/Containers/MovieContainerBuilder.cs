
using System.Reflection;
using Autofac;
using Movies.Infra.IOC.Modules;

namespace Movies.Infra.IOC.Containers
{
    public class MovieContainerBuilder
    {
        private static ContainerBuilder builder { get; set; }

        public static IContainer Build(ContainerBuilder builder)
        {
            // Register your Web API controllers.
            RegisterTypes(builder);
            return builder.Build();
        }
        public static IContainer Build()
        {
            builder = new ContainerBuilder();
            // Register your Web API controllers.
            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterWebApiModelBinderProvider();
            RegisterTypes(builder);
            return builder.Build();
        }
       

        private static void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterModule<MapperModule>();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<ValidatorModule>();
        }
    }
}
