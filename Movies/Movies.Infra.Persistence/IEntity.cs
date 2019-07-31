namespace Movies.Infra.Persistence
{
    public interface IEntity<T> 
    {
         T Id { get; set; }
    }
}
