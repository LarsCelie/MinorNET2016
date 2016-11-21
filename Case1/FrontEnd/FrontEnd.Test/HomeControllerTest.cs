using FrontEnd.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Test
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexTest()
        {
            var target = new HomeController();

            ActionResult result = target.Index();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
