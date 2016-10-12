using FrontEnd.Agents;
using FrontEnd.Agents.Models;
using FrontEnd.Controllers;
using FrontEnd.Mock;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Test
{
    [TestClass]
    public class CursusControllerTest
    {
        [TestMethod]
        public void IndexTest()
        {
            var service = new CursusService();
            var target = new CursusController(service);

            ActionResult result = target.Index();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void IndexReturnsCorrectModel()
        {
            var service = new CursusService();
            var target = new CursusController(service);

            ActionResult result = target.Index();

            Assert.IsNotNull((result as ViewResult).Model);
            Assert.IsInstanceOfType((result as ViewResult).Model, typeof(IEnumerable<CursusInstantie>));
            var model = (result as ViewResult).Model as IEnumerable<CursusInstantie>;
            Assert.AreEqual(0, model.Count());
        }

        [TestMethod]
        public void Import()
        {
            var service = new CursusService();
            var target = new CursusController(service);

            ActionResult result = target.Import();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void ImportFile()
        {
            // Arrange
            var service = new CursusService();
            var target = new CursusController(service);

            var path = @"C:\TFS\LarsC\Case1\goedvoorbeeld.txt";

            var file = File.OpenRead(path);

            //Act
            //target.Import(file);
        }
    }
}
