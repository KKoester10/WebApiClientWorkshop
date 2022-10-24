using System.Net.Http.Headers;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public  async void Test1()
        {
            // Arrange
            HttpClient client = new HttpClient();
            
            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("User-Agent", "Kolton's API");

            // Action
            var requestUri = "https://localhost:7190/api/Character";

            var stringTask = client.GetStringAsync(requestUri);
            var msg = await stringTask;

            // Assertion
            Assert.NotNull(msg);
        }
    }
}