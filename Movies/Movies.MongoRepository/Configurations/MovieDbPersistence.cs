using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Mongo.Repository.Configurations
{
    public class MovieDbPersistence
    {
        public static void Configure()
        {
            MovieConfig.Configure();
        }
    }
}
