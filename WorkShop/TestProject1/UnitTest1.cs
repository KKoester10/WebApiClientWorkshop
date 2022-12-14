using DnDCharacter.Models;
using System.Net.Http.Formatting;
using static WorkShop.Program;
using Program = WorkShop.Program;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public  async void TestGET()
        {
            var msg = await Program.ClientGET();

            Assert.NotNull(msg);
        }
        [Fact]
        public async void TestPOST()
        {
           
            var resultPOST = await Program.ClientPOST();

            Assert.Equal((double)201, (double)resultPOST.StatusCode);
        }
        [Fact]
        public async void TestPut()
        {
            var resultPUT = await Program.ClientPUT();

            Assert.Equal((double)204, (double)resultPUT.StatusCode);

        }
        [Fact]
        public async void TestDELETE()
        {
            var resultDELETE = await Program.ClientDELETE();
            Assert.Equal((double)204, (double)resultDELETE.StatusCode);
        }

    }
}