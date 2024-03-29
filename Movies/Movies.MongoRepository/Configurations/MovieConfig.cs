﻿using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
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
                map.MapMember(x => x.Author).SetIsRequired(true);
                map.MapMember(x => x.Name).SetIsRequired(true);
                map.MapMember(x => x.Category).SetIsRequired(false);
                map.MapMember(x => x.Price).SetIsRequired(true);
               
            });
        }
    }
}
