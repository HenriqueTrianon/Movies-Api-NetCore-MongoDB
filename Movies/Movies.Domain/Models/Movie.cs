using Movies.Infra.Persistence;

namespace Movies.Domain.Models
{
    public class Movie:BaseModifiableEntity<string>
    {
        public string BookName { get; set; }

        public decimal Price { get; set; }

        public string[] Category { get; set; }

        public string Author { get; set; }
    }
}
