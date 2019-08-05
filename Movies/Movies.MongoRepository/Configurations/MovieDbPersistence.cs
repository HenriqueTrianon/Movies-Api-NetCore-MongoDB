using MongoDB.Bson.Serialization;

namespace Movies.Mongo.Repository.Configurations
{
    public class MovieDbPersistence
    {
        private static bool initialized { get;set; }
        public static void Configure()
        {
            if (!initialized)
            {
                BsonSerializer.UseNullIdChecker = true;
                BsonSerializer.UseZeroIdChecker = true;
                BaseEntityConfig<object>.Configure();
                MovieConfig.Configure();
            }
            initialized = true;
        }

    }
}
