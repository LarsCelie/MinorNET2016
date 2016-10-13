using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Net;
using BackendService.Entities;

namespace BackendService.IntegrationTest
{
    [TestClass]
    public class IntegrationTest
    {

        [TestMethod]
        public async Task GetAllCursusInstanties()
        {
            // Arrange
            var _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>().UseContentRoot(@"C:\TFS\LarsC\Case1\BackendService\src\BackendService"));
            var _client = _server.CreateClient();

            // Act
            var response = await _client.GetAsync("api/v1/cursus");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.IsTrue(!String.IsNullOrWhiteSpace(responseString));
        }

        [TestMethod]
        public async Task PostListOfCursusInstanties()
        {
            // Arrange
            var _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>().UseContentRoot(@"C:\TFS\LarsC\Case1\BackendService\src\BackendService"));
            var _client = _server.CreateClient();

            List<CursusInstantie> lijst = new List<CursusInstantie>();
            var cursus = new Cursus { Duur = 5, Titel = "Programmeren met Marco", Code = "MARCO" };
            var instantie = new CursusInstantie { Cursus = cursus, Startdatum = "13/10/2016" };
            lijst.Add(instantie);

            // Act
            string json = JsonConvert.SerializeObject(lijst);
            var response = await _client.PostAsync("api/v1/cursus", new StringContent(json, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(responseString.EndsWith("total\":1}"));
        }

        [TestMethod]
        public async Task PostListOfIncorrectCursusInstanties()
        {
            // Arrange
            var _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>().UseContentRoot(@"C:\TFS\LarsC\Case1\BackendService\src\BackendService"));
            var _client = _server.CreateClient();

            // Act
            string json = JsonConvert.SerializeObject(new { Kaas = "Gouda", Worst = "Chorizo" });
            var response = await _client.PostAsync("api/v1/cursus", new StringContent(json, Encoding.UTF8, "application/json"));

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
