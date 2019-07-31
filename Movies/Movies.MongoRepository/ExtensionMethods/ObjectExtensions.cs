using MongoDB.Bson;

namespace Movies.Mongo.Repository.ExtensionMethods
{
    public static class ObjectExtensions
    {
        public static ObjectId ToObjectID(this object identifier) => ObjectId.Parse(identifier.ToString());
    }
}
