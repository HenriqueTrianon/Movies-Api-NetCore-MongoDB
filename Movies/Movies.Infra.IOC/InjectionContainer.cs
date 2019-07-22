using System;
using Autofac;

namespace Movies.Infra.IOC
{
    public class InjectionContainer: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IMo,>()
        }
    }
}
