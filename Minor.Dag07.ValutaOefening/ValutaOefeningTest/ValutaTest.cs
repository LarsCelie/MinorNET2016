using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ValutaOefeningTest
{
    [TestClass]
    public class ValutaTest
    {


        [TestMethod]
        public void Euro100en12Test()
        {
            //Arrange
            Valuta val = new Valuta(Muntsoort.Euro, 100.12M);

            //Act
            string result = val.ToString();

            //Assert
            Assert.AreEqual("EUR 100,12", result);
        }

        [TestMethod]
        public void Euro10Test()
        {
            //Arrange
            Valuta val = new Valuta(Muntsoort.Euro, 10M);

            //Act
            string result = val.ToString();

            //Assert
            Assert.AreEqual("EUR 10,00", result);
        }

        [TestMethod]
        public void Gulden50en80Test()
        {
            //Arrange
            Valuta val = new Valuta(Muntsoort.Gulden, 50.80M);

            //Act
            string result = val.ToString();

            //Assert
            Assert.AreEqual("fl 50,80", result);
        }

        [TestMethod]
        public void Florijn25Test()
        {
            //Arrange
            Valuta val = new Valuta(Muntsoort.Florijn, 25M);

            //Act
            string result = val.ToString();

            //Assert
            Assert.AreEqual("fl 25,00", result);
        }

        [TestMethod]
        public void Dukaat75Test()
        {
            //Arrange
            Valuta val = new Valuta(Muntsoort.Dukaat, 75M);

            //Act
            string result = val.ToString();

            //Assert
            Assert.AreEqual("HD 75,00", result);
        }

        [TestMethod]
        public void EuroNaarGulden()
        {
            //Arrange
            Valuta euro = new Valuta(Muntsoort.Euro, 1M);
            Valuta gulden = euro.BerekenNaar(Muntsoort.Gulden);

            //Act
            string result = gulden.ToString();

            //Assert
            Assert.AreEqual("fl 2,20", result);
        }

        [TestMethod]
        public void EuroNaarFlorijn()
        {
            //Arrange
            Valuta euro = new Valuta(Muntsoort.Euro, 1M);
            Valuta florijn = euro.BerekenNaar(Muntsoort.Florijn);

            //Act
            string result = florijn.ToString();

            //Assert
            Assert.AreEqual("fl 2,20", result);
        }

        [TestMethod]
        public void EuroNaarDukaat()
        {
            //Arrange
            Valuta euro = new Valuta(Muntsoort.Euro, 1M);
            Valuta florijn = euro.BerekenNaar(Muntsoort.Dukaat);

            //Act
            string result = florijn.ToString();

            //Assert
            Assert.AreEqual("HD 11,24", result);
        }

        [TestMethod]
        public void EuroNaarEuro()
        {
            //Arrange
            Valuta euro = new Valuta(Muntsoort.Euro, 1M);
            Valuta florijn = euro.BerekenNaar(Muntsoort.Euro);

            //Act
            string result = florijn.ToString();

            //Assert
            Assert.AreEqual("EUR 1,00", result);
        }

        [TestMethod]
        public void GuldenNaarDukaat()
        {
            //Arrange
            Valuta gulden = new Valuta(Muntsoort.Gulden, 1M);
            Valuta dukaat = gulden.BerekenNaar(Muntsoort.Dukaat);

            //Act
            string result = dukaat.ToString();

            //Assert
            Assert.AreEqual("HD 5,10", result);
        }

        [TestMethod]
        public void DukaatNaarGulden()
        {
            //Arrange
            Valuta gulden = new Valuta(Muntsoort.Dukaat, 5.1M);
            Valuta dukaat = gulden.BerekenNaar(Muntsoort.Gulden);

            //Act
            string result = dukaat.ToString();

            //Assert
            Assert.AreEqual("fl 1,00", result);
        }

        [TestMethod]
        public void GuldenPlusGulden()
        {
            //Arrange
            Valuta gulden = new Valuta(Muntsoort.Gulden, 1M);
            Valuta gulden2 = new Valuta(Muntsoort.Gulden, 1M);

            Valuta combineerd = gulden + gulden2;

            //Act
            string result = combineerd.ToString();

            //Assert
            Assert.AreEqual("fl 2,00", result);
        }


        [TestMethod]
        public void GuldenPlusDukaat()
        {
            //Arrange
            Valuta gulden = new Valuta(Muntsoort.Gulden, 1M);
            Valuta dukaat = new Valuta(Muntsoort.Dukaat, 1M);

            Valuta combineerd = gulden + dukaat;

            //Act
            string result = combineerd.ToString();

            //Assert
            Assert.AreEqual("fl 1,20", result);
        }

        [TestMethod]
        public void GuldenPlusFlorijn()
        {
            //Arrange
            Valuta gulden = new Valuta(Muntsoort.Gulden, 1M);
            Valuta florijn = new Valuta(Muntsoort.Florijn, 1M);

            Valuta combineerd = gulden + florijn;

            //Act
            string result = combineerd.ToString();

            //Assert
            Assert.AreEqual("fl 2,00", result);
        }

        [TestMethod]
        public void GuldenPlusEuro()
        {
            //Arrange
            Valuta gulden = new Valuta(Muntsoort.Gulden, 1M);
            Valuta euro = new Valuta(Muntsoort.Euro, 1M);

            Valuta combineerd = gulden + euro;

            //Act
            string result = combineerd.ToString();

            //Assert
            Assert.AreEqual("fl 3,20", result);
        }

        [TestMethod]
        public void EuroMaalEuro()
        {
            //Arrange
            Valuta euro2 = new Valuta(Muntsoort.Euro, 5M);
            Valuta euro = new Valuta(Muntsoort.Euro, 5M);

            Valuta combineerd = euro2 * euro;

            //Act
            string result = combineerd.ToString();

            //Assert
            Assert.AreEqual("EUR 25,00", result);
        }

        [TestMethod]
        public void GuldenMaalDukaat()
        {
            //Arrange
            Valuta gulden = new Valuta(Muntsoort.Gulden, 10M);
            Valuta dukaat = new Valuta(Muntsoort.Dukaat, 51M);

            Valuta combineerd = gulden * dukaat;

            //Act
            string result = combineerd.ToString();

            //Assert
            Assert.AreEqual("fl 100,00", result);
        }

        [TestMethod]
        public void ValutaPlus10Decimal()
        {
            //Arrange
            Valuta val = new Valuta(Muntsoort.Euro, 5M);
            val += 10M;

            //Act

            string result = val.ToString();

            //Assert
            Assert.AreEqual("EUR 15,00", result);
        }

        [TestMethod]
        public void ValutaIsDecimal()
        {
            //Arrange
            Valuta val = new Valuta(Muntsoort.Euro, 10M);

            //Act

            string result = String.Format("{0:N2}", (decimal)val);

            //Assert
            Assert.AreEqual("10,00", result);
        }

        [TestMethod]
        public void DecimalIsValuta()
        {
            //Arrange
            decimal dec = 10M;

            //Act
            Valuta val = dec;

            //Assert
            Assert.AreEqual(new Valuta(Muntsoort.Euro, 10M), val);
        }

        [TestMethod]
        public void ValutaPlusPlus()
        {
            //Arrange
            Valuta val = new Valuta(Muntsoort.Euro, 10);

            //Act
            val++;

            //Assert
            Assert.AreEqual("EUR 11,00", val.ToString());
        }
    }
}
