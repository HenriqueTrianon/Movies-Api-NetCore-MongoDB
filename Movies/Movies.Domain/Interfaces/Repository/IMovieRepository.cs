namespace Movies.Domain.Interfaces.Repository
{
    public interface IMovieRepository<Tmodel>:IMongoDBRepository<Tmodel>
    {
    }
}
