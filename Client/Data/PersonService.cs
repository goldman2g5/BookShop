using BookShop.Client.Models;

namespace BookShop.Client.Data
{
    public class PersonService
    {
        private static Role adminRole = new Role("admin");
        private static Role userRole = new Role("user");

        public static readonly List<Person> persons = new List<Person>()
        {
            new Person("tom@bebra.com", "1234", adminRole),
            new Person("hitler@nigger.gay", "1488", userRole),
        };
    }
}
