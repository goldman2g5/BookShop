namespace BookShop.Client.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Author { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string YearPosted { get; set; } = null!;

        public string Tags { get; set; } = null!;

        public Book( string name, string author, string yearPosted, string tags)
        {
            Author = author;
            Name = name;
            YearPosted = yearPosted;
            Tags = tags;
        }
    }
}
