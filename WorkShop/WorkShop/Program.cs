using DnDCharacter.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace WorkShop
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var msg = await ClientGET();
            
            Console.WriteLine(JToken.Parse(msg).ToString());
        }

        public class Header : HttpClient
        {
            public string requestUri { get; set; }
            public HttpClient client { get; set; }

            public Header()
            {
                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Clear();

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("User-Agent", "Kolton's API");

                var requestUri = "https://localhost:7190/api/Character/";
            }
        }


        public static async Task<string> ClientGET()
        {
            
            Header client = new Header();
            var requestUri = client.requestUri;
            
            var stringTask = client.GetStringAsync(requestUri);
            var msg = await stringTask;

            return msg;

        }
        public static async Task<HttpResponseMessage> ClientPOST()
        {
            Header client = new Header();
            var requestUri = client.requestUri;

            var characterPOST = new Character {PartyId = 1, PlayerName = "Fred", Name = "Bob", Class = "Fighter", Level = 0, Race = "Orc", Allignment = "Neutral Good", Background = "Entertainer", ProficiencyBonus = 2, Initiative = 3, HitPoints = 30, Speed = 30, ArmorClass = 30, Experiance = 0, AbilitiesId = 4, InventoryId = 4 };
            var resultPOST = await client.PostAsync<Character>(requestUri, characterPOST, new JsonMediaTypeFormatter());


            return (HttpResponseMessage)resultPOST;

        }



    }
}