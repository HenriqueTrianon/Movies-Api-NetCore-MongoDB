namespace Movies.Mongo.Repository.Configurations
{
    public class MovieDbPersistence
    {
        public static void Configure()
        {
            BaseEntityConfig<object>.Configure();
            MovieConfig.Configure();
            
        }
    }
}
