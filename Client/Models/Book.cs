namespace BookShop.Client.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Author { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string YearPosted { get; set; } = null!;

        public string Tags { get; set; } = null!;

        public Book(int id, string author, string name, string yearPosted, string tags)
        {
            Id = id;
            Author = author;
            Name = name;
            YearPosted = yearPosted;
            Tags = tags;
        }
    }
}
