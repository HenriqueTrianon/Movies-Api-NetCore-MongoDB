using System;
using Autofac;
using AutoMapper;
using Movies.Domain.Mapper;
using Movies.Infra.IOC.Containers;
using Movies.Mongo.Repository.Configurations;

namespace Movies.Tests
{
    public abstract class BaseTest:IDisposable
    {
        protected IContainer container;

        protected BaseTest()
        {
            container = MovieContainerBuilder.Build();
            Mapper.Initialize(cfg => cfg.AddProfile<MoviesDomainProfile>());
            MovieDbPersistence.Configure();
        }

        public void Dispose()
        {
            container?.Dispose();
            Mapper.Reset();
            
        }
    }
}
