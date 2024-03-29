﻿using AutoMapper;
using Movies.Domain.DTO;
using Movies.Domain.Models;

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
