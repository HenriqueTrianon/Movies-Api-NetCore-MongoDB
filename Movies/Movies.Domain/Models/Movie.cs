namespace Movies.Domain.Models
{
    public class Movie
    {
        public string Id { get; set; }

        public string BookName { get; set; }

        public decimal Price { get; set; }

        public string[] Category { get; set; }

        public string Author { get; set; }
    }
}
