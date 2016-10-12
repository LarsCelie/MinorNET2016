using FrontEnd.Agents;
using FrontEnd.Agents.Models;
using FrontEnd.Controllers;
using FrontEnd.Mock;
using FrontEnd.Viewmodels;
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
            var service = new CursusServiceMock();
            var target = new CursusController(service);

            ActionResult result = target.Index();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void IndexReturnsCorrectModel()
        {
            var service = new CursusServiceMock();
            var target = new CursusController(service);

            ActionResult result = target.Index();

            Assert.IsNotNull((result as ViewResult).Model);
            Assert.IsInstanceOfType((result as ViewResult).Model, typeof(IEnumerable<CursusInstantie>));
            var model = (result as ViewResult).Model as IEnumerable<CursusInstantie>;
            Assert.AreEqual(3, model.Count());
        }

        [TestMethod]
        public void Import()
        {
            var service = new CursusServiceMock();
            var target = new CursusController(service);

            ActionResult result = target.Import();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void ImportFile()
        {
            // Arrange
            var service = new CursusServiceMock();
            var target = new CursusController(service);

            var mock = new IFromFileMock();

            // Act
            var result = target.Import(mock);

            // Assert
            Assert.IsNotNull((result as ViewResult).Model);
            Assert.IsInstanceOfType((result as ViewResult).Model, typeof(ImportViewModel));
            var model = (result as ViewResult).Model as ImportViewModel;
            Assert.IsTrue(service.PostIsCalled);
            Assert.AreEqual(1, model.success.Total);
        }
    }
}
