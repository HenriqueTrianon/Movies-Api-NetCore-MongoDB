namespace Movies.Infra.Core
{
    public abstract class BaseEntity<T>:IEntity<T>
    {
        public T Id { get; set; }
    }
}
