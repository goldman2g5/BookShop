using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using BookShop.Client.Models;
using static System.Net.WebRequestMethods;
using System.Net.Http;

namespace BookShop.Client.Data
{
    public static class BookService
    {
        private static string apiurl = "http://localhost:8082/api/";
        private static HttpClient client = new HttpClient();

        private static string CallApi(string route)
        {
            var json = client.GetAsync(apiurl + route);
            return json.Result.Content.ReadAsStringAsync().Result;
        }

       public static async Task<List<Book>> GetAll()
        {
            HttpResponseMessage response = await client.GetAsync(apiurl + "book");
            return JsonConvert.DeserializeObject<List<Book>>(response.Content.ToString());
            //var result = await client.GetFromJsonAsync<List<Book>>("api/Book");
        }



    }
}
