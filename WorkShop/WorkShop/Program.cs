using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace WorkShop
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("User-Agent", "Kolton's API");

            
            var requestUri = "https://localhost:7190/api/Character";

            var stringTask = client.GetStringAsync(requestUri);
            var msg = await stringTask;

            Console.WriteLine(JToken.Parse(msg).ToString());
        }
    }
}