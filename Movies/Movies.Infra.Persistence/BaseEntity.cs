namespace Movies.Infra.Persistence
{
    public abstract class BaseEntity<T>:IEntity<T>
    {
        public T Id { get; set; }
    }
}
