using FrontEnd.Controllers;
using FrontEnd.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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
            var target = new CursusController();

            ActionResult result = target.Index();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void IndexReturnsCorrectModel()
        {
            var target = new CursusController();

            ActionResult result = target.Index();

            Assert.IsNotNull((result as ViewResult).Model);
            Assert.IsInstanceOfType((result as ViewResult).Model, typeof(IEnumerable<Cursus>));
            var model = (result as ViewResult).Model as IEnumerable<Cursus>;
            Assert.AreEqual(5, model.Count());
        }

        [TestMethod]
        public void Import()
        {
            var target = new CursusController();

            ActionResult result = target.Import();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
