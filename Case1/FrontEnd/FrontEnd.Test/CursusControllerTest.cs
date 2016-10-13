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

            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void IndexPerWeekTest()
        {
            var service = new CursusServiceMock();
            var target = new CursusController(service);

            ActionResult result = target.IndexPerWeek(41, 2016);

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void IndexPerWeekReturnsCorrectModel()
        {
            var service = new CursusServiceMock();
            var target = new CursusController(service);

            ActionResult result = target.IndexPerWeek(41, 2016);

            Assert.IsNotNull((result as ViewResult).Model);
            Assert.IsInstanceOfType((result as ViewResult).Model, typeof(IndexViewModel));
            var model = (result as ViewResult).Model as IndexViewModel;
            Assert.AreEqual(3, model.Cursussen.Count());
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
        public void ImportFileHappyCase()
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

        [TestMethod]
        public void ImportFileIncorrectFormatCursusCodeNotAtSecondLine()
        {
            // Arrange
            var service = new CursusServiceMock();
            var target = new CursusController(service);

            var mock = new IFromFileMock();
            mock.defaultText = @"Titel: C# Programmeren
Duur: 5 dagen
Cursuscode: CNETIN
Startdatum: 14/10/2013
";

            // Act
            var result = target.Import(mock);

            // Assert
            Assert.IsNotNull((result as ViewResult).Model);
            Assert.IsInstanceOfType((result as ViewResult).Model, typeof(ImportViewModel));
            var model = (result as ViewResult).Model as ImportViewModel;
            Assert.IsFalse(service.PostIsCalled);
            Assert.IsNotNull(model.validationError);
            Assert.AreEqual("IF001", model.validationError.ErrorCode);
        }

        [TestMethod]
        public void ImportFileIncorrectFormatDuurMissing()
        {
            // Arrange
            var service = new CursusServiceMock();
            var target = new CursusController(service);

            var mock = new IFromFileMock();
            mock.defaultText = @"Titel: C# Programmeren
Cursuscode: CNETIN
Startdatum: 14/10/2013";

            // Act
            var result = target.Import(mock);

            // Assert
            Assert.IsNotNull((result as ViewResult).Model);
            Assert.IsInstanceOfType((result as ViewResult).Model, typeof(ImportViewModel));
            var model = (result as ViewResult).Model as ImportViewModel;
            Assert.IsFalse(service.PostIsCalled);
            Assert.IsNotNull(model.validationError);
            Assert.AreEqual("IF001", model.validationError.ErrorCode);
        }

        [TestMethod]
        public void ImportFileIncorrectFormatDateIsIncorrect()
        {
            // Arrange
            var service = new CursusServiceMock();
            var target = new CursusController(service);

            var mock = new IFromFileMock();
            mock.defaultText = @"Titel: C# Programmeren
Cursuscode: CNETIN
Duur: 5 dagen
Startdatum: 14-10-2013";

            // Act
            var result = target.Import(mock);

            // Assert
            Assert.IsNotNull((result as ViewResult).Model);
            Assert.IsInstanceOfType((result as ViewResult).Model, typeof(ImportViewModel));
            var model = (result as ViewResult).Model as ImportViewModel;
            Assert.IsFalse(service.PostIsCalled);
            Assert.IsNotNull(model.validationError);
            Assert.AreEqual("IF001", model.validationError.ErrorCode);
        }

        [TestMethod]
        public void ImportFileIncorrectFormatDuurIsIncorrect()
        {
            // Arrange
            var service = new CursusServiceMock();
            var target = new CursusController(service);

            var mock = new IFromFileMock();
            mock.defaultText = @"Titel: C# Programmeren
Cursuscode: CNETIN
Duur: 5
Startdatum: 14/10/2013";

            // Act
            var result = target.Import(mock);

            // Assert
            Assert.IsNotNull((result as ViewResult).Model);
            Assert.IsInstanceOfType((result as ViewResult).Model, typeof(ImportViewModel));
            var model = (result as ViewResult).Model as ImportViewModel;
            Assert.IsFalse(service.PostIsCalled);
            Assert.IsNotNull(model.validationError);
            Assert.AreEqual("IF001", model.validationError.ErrorCode);
        }

        [TestMethod]
        public void ImportFileIncorrectFormatNoEmptyLine()
        {
            // Arrange
            var service = new CursusServiceMock();
            var target = new CursusController(service);

            var mock = new IFromFileMock();
            mock.defaultText = @"Titel: C# Programmeren
Cursuscode: CNETIN
Duur: 5 dagen
Startdatum: 14/10/2013
Titel: C# Programmeren
Cursuscode: CNETIN
Duur: 5 dagen
Startdatum: 21/10/2013";

            // Act
            var result = target.Import(mock);

            // Assert
            Assert.IsNotNull((result as ViewResult).Model);
            Assert.IsInstanceOfType((result as ViewResult).Model, typeof(ImportViewModel));
            var model = (result as ViewResult).Model as ImportViewModel;
            Assert.IsFalse(service.PostIsCalled);
            Assert.IsNotNull(model.validationError);
            Assert.AreEqual("IF001", model.validationError.ErrorCode);
        }
    }
}
