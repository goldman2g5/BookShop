using Newtonsoft.Json;
using BookShop.Server.Models;

namespace BookShop.Server.Data
{
    public class UserService
    {
            private static HttpClient client = new HttpClient();

            public static async Task<List<User>> GetAll()
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:7093/api/Book");
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<User>>(json);
            }
            

            public static async Task AddUser()
            {

            }


        }
    }
