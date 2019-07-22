using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Movies.Domain.Interfaces.Repository;
using Movies.MongoRepository.ExtensionMethods;
using Movies.MongoRepository.Models;
using Tmodels.MongoRepository.Repository;

namespace Movies.MongoRepository.Repository
{
    public class MovieRepository:BaseRepository<Movie>
    {
        protected override string DatabaseName { get; } = "movieapi";
        protected override string CollectionName { get; } = "movies";
        private IMongoCollection<Movie> MoviesCollection { get; }
        public MovieRepository(IMongoClient client) : base(client)
        {
        }
    }
}
