using MongoDB.Bson.Serialization;
using Movies.Domain.Models;

namespace Movies.Mongo.Repository.Configurations
{
    public class MovieConfig
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Movie>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.Id);
                map.MapMember(x => x.Author).SetIsRequired(true);
                map.MapMember(x => x.BookName).SetIsRequired(true);
                map.MapMember(x => x.Category).SetIsRequired(false);
                map.MapMember(x => x.Price).SetIsRequired(true);
            });
        }
    }
}
