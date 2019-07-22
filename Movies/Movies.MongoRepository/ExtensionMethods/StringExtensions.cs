using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace Movies.MongoRepository.ExtensionMethods
{
    public static class StringExtensions
    {
        public static ObjectId ToObjectID(this string identifier) => ObjectId.Parse(identifier);
    }
}
