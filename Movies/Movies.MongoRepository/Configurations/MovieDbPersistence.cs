namespace Movies.Mongo.Repository.Configurations
{
    public class MovieDbPersistence
    {
        private static bool initialized { get;set; } = false;
        public static void Configure()
        {
            if (!initialized)
            {
                BaseEntityConfig<object>.Configure();
                MovieConfig.Configure();
            }
            initialized = true;
        }
    }
}
