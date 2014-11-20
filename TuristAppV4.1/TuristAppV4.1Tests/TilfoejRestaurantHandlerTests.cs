using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuristAppV4._1.ViewModel;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
namespace TuristAppV4._1Tests
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
            Assert.AreEqual("daniel", "daniel");

            try
            {
                _handler.RestaurantNavn = null;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Name is null or empty", ex.Message);
            }
        }

    }
}
