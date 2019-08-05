using Autofac;
using FluentValidation;
using Movies.Domain.DTO;
using Movies.Domain.Validators;

namespace Movies.Infra.IOC.Modules
{
    public class ValidatorModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MovieValidator>().As<IValidator<MovieDto>>();
        }
    }
}
