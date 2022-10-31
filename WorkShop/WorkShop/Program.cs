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
            Console.WriteLine(JToken.Parse(msgGET).ToString());
            
            var msgPOST = await ClientPOST();
            Console.WriteLine(msgPOST);

            var msgPUT = await ClientPUT();
            Console.WriteLine(msgPUT);

            var resultDELETE = await ClientDELETE();
            Console.WriteLine(resultDELETE);

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

                requestUri = "https://localhost:7190/api/Characters/";
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

                PlayerName = "Kolton2",
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
                PartyId = 1,
                AbilitiesId = 0,
                Abilities = new Abilities {
                    Strength = 0,
                    Dexterity = 0,
                    Constitution = 0,
                    Intelligence = 0,
                    Wisdom = 0,
                    Charisma = 0
                },
                InventoryId = 0,
                Inventory = new CharacterInventory {
                    ItemName = "string",
                    Amount = 0
                }
            };
            var resultPOST = await client.PostAsync<Character>(requestUri, characterPOST, new JsonMediaTypeFormatter());


            return (HttpResponseMessage)resultPOST;

        }
        public static async Task<HttpResponseMessage> ClientPUT()
        {
            Header client = new Header();
            var requestUri = client.requestUri;

            var characterPUT = new Character
            {
                Id = 7,
                PlayerName = "Kolton5",
                Name = "string",
                Class = "string",
                Level = 50,
                Race = "string",
                Allignment = "string",
                Background = "string",
                ProficiencyBonus = 0,
                Experiance = 5000,
                ArmorClass = 0,
                Initiative = 0,
                HitPoints = 0,
                Speed = 0,
                PartyId = 2,
                AbilitiesId = 7,
                Abilities = new Abilities
                {
                    Strength = 0,
                    Dexterity = 0,
                    Constitution = 0,
                    Intelligence = 0,
                    Wisdom = 0,
                    Charisma = 0
                },
                InventoryId = 5,
                Inventory = new CharacterInventory
                {
                    ItemName = "string",
                    Amount = 0
                }
            };
            var resultPUT = await client.PutAsync<Character>(requestUri + "7", characterPUT, new JsonMediaTypeFormatter());

            return (HttpResponseMessage)resultPUT;
        }
        public static async Task<HttpResponseMessage> ClientDELETE()
        {
            Header client = new Header();
            var requestUri = client.requestUri;

            var resultDELETE = await client.DeleteAsync(requestUri + "7");

            return (HttpResponseMessage)resultDELETE;
        }
    }
}