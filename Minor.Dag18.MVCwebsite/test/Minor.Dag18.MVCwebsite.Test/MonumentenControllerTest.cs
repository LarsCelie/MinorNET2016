using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Minor.Dag18.MVCwebsite.Controllers;
using Minor.Dag18.MVCwebsite.Agents;
using Minor.Dag18.MVCwebsite.Entities;

namespace Minor.Dag18.MVCwebsite.Test
{
    [TestClass]
    public class MonumentenControllerTest
    {
        [TestMethod]
        public void IndexTest()
        {
            // Arrange
            IMonumentAgent agent = new MonumentAgentDummy();
            MonumentenController target = new MonumentenController(agent);

            // Act
            ActionResult result = target.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void IndexReturnsCorrectModel()
        {
            // Arrange
            IMonumentAgent agent = new MonumentAgentDummy();
            MonumentenController target = new MonumentenController(agent);

            // Act
            ActionResult result = target.Index();

            // Assert
            Assert.IsNotNull((result as ViewResult).Model);
            Assert.IsInstanceOfType((result as ViewResult).Model, typeof(IEnumerable<Monument>));
            var model = (result as ViewResult).Model as IEnumerable<Monument>;
            Assert.AreEqual(3, model.Count());
        }

        [TestMethod]
        public void DeleteReturnsRedirection()
        {
            // Arrange
            IMonumentAgent agent = new MonumentAgentDummy();
            MonumentenController target = new MonumentenController(agent);

            // Act
            ActionResult result = target.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }


        [TestMethod]
        public void DeleteReturnsCorrectModel()
        {
            // Arrange
            IMonumentAgent agent = new MonumentAgentDummy();
            MonumentenController target = new MonumentenController(agent);

            // Act
            target.Delete(1);
            ActionResult result = target.Index();

            // Assert
            Assert.IsNotNull((result as ViewResult).Model);
            Assert.IsInstanceOfType((result as ViewResult).Model, typeof(IEnumerable<Monument>));
            var model = (result as ViewResult).Model as IEnumerable<Monument>;
            Assert.AreEqual(2, model.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            // Arrange
            IMonumentAgent agent = new MonumentAgentDummy();
            MonumentenController target = new MonumentenController(agent);

            // Act
            Monument m = new Monument { Id = 4, Naam = "Twin Towers", Hoogte = 0 };
            target.Insert(m);
            ActionResult result = target.Index();

            // Assert
            Assert.IsNotNull((result as ViewResult).Model);
            Assert.IsInstanceOfType((result as ViewResult).Model, typeof(IEnumerable<Monument>));
            var model = (result as ViewResult).Model as IEnumerable<Monument>;
            Assert.AreEqual(2, model.Count());
        }
    }
}
