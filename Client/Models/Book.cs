namespace BookShop.Client.Models
{
    public class Book
    {
        public string author { get; set; }
        public string name { get; set; }
        public string yearPosted { get; set; }

        public Book(string author, string name, string yearPosted)
        {
            this.author = author;
            this.name = name;
            this.yearPosted = yearPosted;
        }
    }
}
