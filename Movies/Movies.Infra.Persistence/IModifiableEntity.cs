using System;

namespace Movies.Infra.Persistence
{
    public interface IModifiableEntity<T>:IEntity<T>
    {
        DateTime CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
    }
}
