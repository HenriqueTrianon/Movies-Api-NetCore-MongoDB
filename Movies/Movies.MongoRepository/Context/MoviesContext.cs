using System;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;

namespace Movies.Mongo.Repository.Context
{
    public class MoviesContext
    {
        public IMongoDatabase Database { get; set; }
        public string DataBaseName { get; set; } 
        public MoviesContext(string connection,string dataBaseName)
        {
            DataBaseName = dataBaseName;
            Database = new MongoClient(new MongoClientSettings
            {
                    Server = new MongoServerAddress(connection, 27017),
                    ClusterConfigurator = cb =>
                    {
                        cb.Subscribe<CommandStartedEvent>(e =>
                        {
                            Console.WriteLine($"{e.CommandName} - {e.Command.ToJson(new JsonWriterSettings { Indent = true })}");
                            Console.WriteLine(new string('-', 32));
                        });
                    }
            }).GetDatabase(DataBaseName);

        }

       
    }
}
