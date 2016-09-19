using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Minor.Dag08.StringEnRegex.Test
{
    [TestClass]
    public class Program
    {
        [TestMethod]
        public void CorrecteCheck()
        {
            //Arrange
            RegexValutaChecker target = new RegexValutaChecker();

            //Act
            bool result = target.Check("1.00");

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NIET_EindigenMetMeerDan2Getallen()
        {
            //Arrange
            RegexValutaChecker target = new RegexValutaChecker();

            //Act
            bool result = target.Check("3.000");

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void NIET_EindigenMetMinderDan2Getallen()
        {
            //Arrange
            RegexValutaChecker target = new RegexValutaChecker();

            //Act
            bool result = target.Check("3.0");

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void NIET_EindigenMetEenPunt()
        {
            //Arrange
            RegexValutaChecker target = new RegexValutaChecker();

            //Act
            bool result = target.Check("3.");

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EindigMetPuntEn2Getallen()
        {
            //Arrange
            RegexValutaChecker target = new RegexValutaChecker();

            //Act
            bool result = target.Check("3.00");

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GEEN_lettersBevatten()
        {
            //Arrange
            RegexValutaChecker target = new RegexValutaChecker();

            //Act
            bool result = target.Check("p3.00");

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void BevatCommaAlsGroterDan4cijfers()
        {
            //Arrange
            RegexValutaChecker target = new RegexValutaChecker();

            //Act
            bool result = target.Check("1,234.67");

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Bevat2CommasAlsGroterDan7cijfers()
        {
            //Arrange
            RegexValutaChecker target = new RegexValutaChecker();

            //Act
            bool result = target.Check("1,234,567.89");

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Mag2getallenAlsBeginHebben()
        {
            //Arrange
            RegexValutaChecker target = new RegexValutaChecker();

            //Act
            bool result = target.Check("11,234,567.89");

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Mag3getallenAlsBeginHebben()
        {
            //Arrange
            RegexValutaChecker target = new RegexValutaChecker();

            //Act
            bool result = target.Check("111,234,567.89");

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MagOptioneelNegatiefZijn()
        {
            //Arrange
            RegexValutaChecker target = new RegexValutaChecker();

            //Act
            bool result = target.Check("-11,234,567.89");

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MagMetNulBeginnen()
        {
            //Arrange
            RegexValutaChecker target = new RegexValutaChecker();

            //Act
            bool result = target.Check("00.80");

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NIET_MetPlusBeginnen()
        {
            //Arrange
            RegexValutaChecker target = new RegexValutaChecker();

            //Act
            bool result = target.Check("+0.89");

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Moet3getallenTussenCommas()
        {
            //Arrange
            RegexValutaChecker target = new RegexValutaChecker();

            //Act
            bool result = target.Check("1,234567.80");

            //Assert
            Assert.IsFalse(result);
        }

    }
}
