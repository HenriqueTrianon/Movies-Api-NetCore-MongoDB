using MongoDB.Bson;

namespace Movies.Mongo.Repository.ExtensionMethods
{
    public static class StringExtensions
    {
        public static ObjectId ToObjectID(this string identifier) => ObjectId.Parse(identifier);
    }
}
