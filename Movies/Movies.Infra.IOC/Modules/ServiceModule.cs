using System;
using Autofac;
using AutoMapper;
using Movies.Domain.DTO;
using Movies.Domain.Interfaces.Repository;
using Movies.Domain.Interfaces.Services;
using Movies.Domain.Models;
using Movies.Domain.Services;
using Movies.Mongo.Repository.Repository;

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
