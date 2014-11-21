using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuristAppV4._1.ViewModel;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
namespace TuristAppV4._1Tests1.ViewModel
{
    [TestClass()]
    public class TilfoejRestaurantHandlerTests
    {

        private TilfoejRestaurantHandler _handler;

        [TestInitialize]
        public void BeforeTest()
        {
            _handler = new TilfoejRestaurantHandler();
        }


        [TestMethod]
        public void TestName()
        {
            _handler.RestaurantNavn = "daniel";
            Assert.AreEqual("daniel", _handler.RestaurantNavn);

            try
            {
                _handler.RestaurantNavn = null;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Restaurantnavnet er null, tomt eller over 30 tegn", ex.Message);
            }
        }
    }
}
