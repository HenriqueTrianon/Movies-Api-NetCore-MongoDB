using Movies.Infra.Core;

namespace Movies.Domain.Models
{
    public class Movie:BaseEntity<string>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string[] Category { get; set; }

        public string Author { get; set; }
    }
}
