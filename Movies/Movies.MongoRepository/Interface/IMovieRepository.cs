using Movies.Mongo.Repository.Interface;

namespace Movies.Domain.Interfaces.Repository
{
    public interface IMovieRepository<MovieDTO,Movie>: IMongoDBRepository<Movie,MovieDTO>
    {
    }
}
