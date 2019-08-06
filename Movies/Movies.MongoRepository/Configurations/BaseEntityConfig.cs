using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using Movies.Infra.Core;

namespace Movies.Mongo.Repository.Configurations
{
    public class BaseEntityConfig<T>
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<BaseEntity<T>>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.Id).SetIsRequired(true);
                
            });
        }
        
    }
}
