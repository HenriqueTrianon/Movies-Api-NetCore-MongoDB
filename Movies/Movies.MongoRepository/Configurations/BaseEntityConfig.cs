using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization;
using Movies.Infra.Persistence;

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
