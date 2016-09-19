using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsDrivenAssignment.Test
{

    [TestClass]
    public class PersoonTest
    {
        [TestMethod]
        public void PersoonCreatieSucces()
        {
            // Arrange
            Persoon target = new Persoon { Naam = "Lars", Leeftijd = 24 };

            // Act
            string naam = target.Naam;
            int leeftijd = target.Leeftijd;

            // Assert
            Assert.AreEqual("Lars", naam);
            Assert.AreEqual(24, leeftijd);
        }

        [TestMethod]
        public void PersoonVerjaarMethode()
        {
            // Arrange
            Persoon target = new Persoon { Naam = "Lars", Leeftijd = 24 };

            // Act
            target.Verjaar();
            int leeftijd = target.Leeftijd;

            // Assert
            Assert.AreEqual(25, leeftijd);
        }

        [TestMethod]
        public void LeeftijdChangedEventCalled()
        {
            var target = new Persoon();
            var mock = new ListenerMock();

            target.LeeftijdChanged += mock.LeeftijdChangedHandled;

            target.Verjaar();

            Assert.IsTrue(mock.LeeftijdChangedHandledHasBeenCalled);

        }

        [TestMethod]
        public void VerjaarMethodAddsOneYearThroughLeeftijdChangedEvent()
        {
            // Arrange
            var target = new Persoon { Naam = "Lars", Leeftijd = 24 };
            var mock = new ListenerMock();

            // Act
            target.LeeftijdChanged += mock.LeeftijdChangedHandled;
            target.Verjaar();

            // Assert
            Assert.AreEqual(25, mock.LeeftijdChangedEventArgs.NieuweLeeftijd);

        }

        [TestMethod]
        public void LeeftijdChangedEventFiredThroughPropertySet()
        {
            // Arrange
            var target = new Persoon();
            var mock = new ListenerMock();

            // Act
            target.LeeftijdChanged += mock.LeeftijdChangedHandled;
            target.Leeftijd = 20;

            // Assert
            Assert.IsTrue(mock.LeeftijdChangedHandledHasBeenCalled);
        }
    }
}
