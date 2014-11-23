﻿using System;
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

        public void beforeTest()
        {
            _handler = new TilfoejRestaurantHandler();
        }

        [TestMethod()]
        public void CheckTelefonTest()
        {
            string telefon = "";
            for (int i = 0; i < 9; i++)
            {
                telefon = telefon + "a";
            }

            string telefon2 = "";
            for (int i = 0; i < 8; i++)
            {
                telefon2 = telefon2 + "a";
            }

            string telefon3 = "";
            for (int i = 0; i < 7; i++)
            {
                telefon3 = telefon3 + "a";
            }

            string telefon4 = "";

            string telefon5 = null;


            _handler.Telefon = telefon2;                  // hvis telefon nummert er på ni cifre
            Assert.AreEqual(telefon2, _handler.Telefon);
            try
            {
                _handler.Telefon = telefon;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {

                Assert.AreEqual("Telefon skal være 8 tegn", ex.Message);
            }

            _handler.Telefon = telefon2;
            Assert.AreEqual(telefon2, _handler.Telefon); // hvis telefon nummert er på syv cifre 
            try
            {
                _handler.Telefon = telefon3;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {

                Assert.AreEqual("Telefon skal være 8 tegn", ex.Message);
            }
            _handler.Telefon = telefon2;                     // hvis telefon nummert er tomt
            Assert.AreEqual(telefon2, _handler.Telefon);
            try
            {
                _handler.Telefon = telefon4;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {

                Assert.AreEqual("Telefon skal være 8 tegn", ex.Message);
            }

            _handler.Telefon = telefon2;                       // hvis telefon nummert er null
            Assert.AreEqual(telefon2, _handler.Telefon);
            try
            {
                _handler.Telefon = telefon5;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Telefon skal være 8 tegn", ex.Message);
            }
        }

        [TestMethod()]
        public void CheckRestaurantNavnTest()
        {
            string navn = "";
            for (int i = 0; i < 27; i++)
            {
                navn = navn + "a";
            }


            string navn2 = "";
            for (int i = 0; i < 2; i++)
            {
                navn2 = navn2 + "a";
            }

            string navn3 = null;

            string navn4 = "";

            string navn5 = "";
            for (int i = 0; i < 31; i++)
            {
                navn5 = navn5 + "a";
            }

            _handler.RestaurantNavn = navn;          // navnet er tomt
            Assert.AreEqual(navn, _handler.RestaurantNavn);

            try
            {
                _handler.RestaurantNavn = navn4;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Restaurantnavnet er null, tomt eller over 30 tegn", ex.Message);
            }

            _handler.RestaurantNavn = navn;               // navnet består af over 30 bogstaver
            Assert.AreEqual(navn, _handler.RestaurantNavn);
            try
            {
                _handler.RestaurantNavn = navn5;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {

                Assert.AreEqual("Restaurantnavnet er null, tomt eller over 30 tegn", ex.Message);
            }
            _handler.RestaurantNavn = navn;        // restaurant navnet er nul
            Assert.AreEqual(navn, _handler.RestaurantNavn);
            try
            {
                _handler.RestaurantNavn = navn3;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {

                Assert.AreEqual("Restaurantnavnet er null, tomt eller over 30 tegn", ex.Message);
            }


        }

        [TestMethod()]
        public void CheckBeskrivelseTest()
        {
            string beskrivelse = "";
            for (int i = 0; i < 400; i++)
            {
                beskrivelse = beskrivelse + "a";
            }

            string beskrivelse2 = "";

            string beskrivelse3 = "";
            for (int i = 0; i < 501; i++)
            {
                beskrivelse3 = beskrivelse3 + "a";
            }

            string beskrivelse4 = "";
            for (int i = 0; i < 19; i++)
            {
                beskrivelse4 = beskrivelse4 + "a";
            }

            string beskrivelse5 = null;

            _handler.Beskrivelse = beskrivelse; // hvis navnet er tomt
            Assert.AreEqual(beskrivelse, _handler.Beskrivelse);
            try
            {
                _handler.Beskrivelse = beskrivelse2;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("beskrivelse skal indholde tegn", ex.Message);

            }

            _handler.Beskrivelse = beskrivelse;         // hvis restaurant beskrivelsen er over 500 tegn
            Assert.AreEqual(beskrivelse, _handler.Beskrivelse);
            try
            {
                _handler.Beskrivelse = beskrivelse3;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {

                Assert.AreEqual("beskrivelse skal indholde tegn", ex.Message);
            }

            _handler.Beskrivelse = beskrivelse;            // hvis navnet er null
            Assert.AreEqual(beskrivelse, _handler.Beskrivelse);
            try
            {
                _handler.Beskrivelse = beskrivelse5;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {

                Assert.AreEqual("beskrivelse skal indholde tegn", ex.Message);
            }


            _handler.Beskrivelse = beskrivelse;               // hvis beskrivelsen er under 20
            Assert.AreEqual(beskrivelse, _handler.Beskrivelse);
            try
            {
                _handler.Beskrivelse = beskrivelse4;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {

                Assert.AreEqual("beskrivelse skal indholde tegn", ex.Message);
            }  
                                    // hvis beskrivelsen består
        }

            [TestMethod()]
            public void CheckBedømmelseTest()
            {
                string bedømmelse = "1";

                string bedømmelse2 = null;
              
                _handler.Bedømmelse = bedømmelse;
                Assert.AreEqual(bedømmelse, _handler.Bedømmelse);
                try
                {
                    _handler.Bedømmelse = bedømmelse2; 
                    Assert.Fail();
                }
                catch (ArgumentException ex )
                {

                    Assert.AreEqual("bedømmelse", ex.Message );
                }

            }
        }
}