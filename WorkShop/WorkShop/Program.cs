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
            var msgGET = await ClientGET();
            var msgPOST = await ClientPOST();
            
            Console.WriteLine(JToken.Parse(msgGET).ToString());
            Console.WriteLine(msgPOST);
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

                requestUri = "https://localhost:7190/api/Characters";
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

            var characterPOST = new Character
            {
                PlayerName = "string",
                 Name = "string",
                 Class = "string",
                 Level = 0,
                 Race = "string",
                 Allignment = "string",
                 Background = "string",
                 ProficiencyBonus = 0,
                 Experiance = 0,
                 ArmorClass = 0,
                 Initiative = 0,
                 HitPoints = 0,
                 Speed = 0,
                 PartyId = 1 , 
                /* AbilitiesId = null,
                 Abilities = {
                    Id = null,
                    Strength = 0,
                    Dexterity = 0,
                    Constitution = 0,
                    Intelligence = 0,
                    Wisdom = 0,
                    Charisma = 0
                  },
                 InventoryId = null,
                 Inventory = {
                    Id = null,
                    ItemName = "string",
                    Amount = 0
                  }*/
            };
            var resultPOST = await client.PostAsync<Character>(requestUri, characterPOST, new JsonMediaTypeFormatter());


            return (HttpResponseMessage)resultPOST;

        }



    }
}