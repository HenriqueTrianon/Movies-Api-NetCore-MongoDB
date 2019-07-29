using Autofac;
using Movies.Infra.IOC.Containers;
using Movies.Mongo.Repository.Configurations;

namespace Movies.Tests
{
    public abstract class BaseTest
    {
        protected IContainer container;

        protected BaseTest()
        {
            container = MovieContainerBuilder.Build();
            MongoDbPersistence.Configure();
        }
    }
}
