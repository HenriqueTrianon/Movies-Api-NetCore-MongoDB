using System;
using Autofac;
using AutoMapper;

namespace Movies.Infra.IOC.Modules
{
    public class MapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract && t.IsPublic)
                .As<Profile>();
            builder.Register(
                    ctx =>
                    {
                        var scope = ctx.Resolve<ILifetimeScope>();
                        return new Mapper(
                            ctx.Resolve<IConfigurationProvider>(),
                            scope.Resolve);
                    })
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}
