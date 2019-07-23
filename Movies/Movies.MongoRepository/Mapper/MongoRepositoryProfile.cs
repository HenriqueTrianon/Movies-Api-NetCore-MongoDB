using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Movies.Domain.DTO;
using Movies.Mongo.Repository.Models;

namespace Movies.Mongo.Repository.Mapper
{
    public class MongoRepositoryProfile:Profile
    {
        public MongoRepositoryProfile()
        {
            CreateMap<Movie, MovieDto>().ReverseMap();

        }
    }
}
