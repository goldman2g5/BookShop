using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using BookShop.Client.Models;
using static System.Net.WebRequestMethods;
using System.Net.Http;
using System.Net.Http.Json;

namespace BookShop.Client.Data
{
    public static class BookService
    {
        private static HttpClient client = new HttpClient();



        public static async Task<List<Book>> GetAll()
        {
            HttpResponseMessage response = await client.GetAsync("https://localhost:7093/api/Book");
            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Book>>(json);
        }
        public static async Task Add(Book book)
        {
            await client.PostAsJsonAsync("https://localhost:7093/api/Book", book);
        }



    }
}
