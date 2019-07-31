using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization;
using Movies.Infra.Persistence;

namespace Movies.Mongo.Repository.Configurations
{
    public class BaseModifiableEntityConfig<T>
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<BaseModifiableEntity<T>>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.Id).SetIsRequired(true);
                map.MapMember(x => x.CreatedBy).SetIsRequired(true);
                map.MapMember(x => x.CreatedDate).SetIsRequired(false);
                map.MapMember(x => x.ModifiedBy).SetIsRequired(false);
                map.MapMember(x => x.ModifiedDate).SetIsRequired(false);
            });
        }
    }
}
