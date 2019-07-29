using MongoDB.Driver;

namespace Movies.Mongo.Repository.Context
{
    public class MoviesContext
    {
        public IMongoDatabase Database { get; set; }
        public string DataBaseName { get; set; } 
        public MoviesContext(string connection,string dataBaseName)
        {
            DataBaseName = dataBaseName;
            Database = new MongoClient(connection).GetDatabase(DataBaseName);
        }

       
    }
}
