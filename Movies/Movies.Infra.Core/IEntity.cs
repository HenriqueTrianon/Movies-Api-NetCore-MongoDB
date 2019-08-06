namespace Movies.Infra.Core
{
    public interface IEntity<T> 
    {
         T Id { get; set; }
    }
}
