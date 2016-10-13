using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.Dag19.WebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System.Net;

namespace Minor.Dag19.WebApi.IntegrationTest
{
    [TestClass]
    public class MonumentenServiceTest
    {
        [TestMethod]
        public async Task MonumentenGetAllTest()
        {
            // Arrange
            var _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            var _client = _server.CreateClient();

            // Act
            var response = await _client.GetAsync("api/v1/monumenten");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.AreEqual("[{\"id\":1,\"hoogte\":300,\"naam\":\"Eiffeltoren\"},{\"id\":2,\"hoogte\":56,\"naam\":\"Toren van Pisa\"},{\"id\":3,\"hoogte\":381,\"naam\":\"Empire State Building\"}]", responseString);
        }

        [TestMethod]
        public async Task MonumentenGetByIdTest()
        {
            // Arrange
            var _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            var _client = _server.CreateClient();

            // Act
            var response = await _client.GetAsync("api/v1/monumenten/2");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.AreEqual("{\"id\":2,\"hoogte\":56,\"naam\":\"Toren van Pisa\"}", responseString);
        }

        [TestMethod]
        public async Task MonumentenGetByIdReturnsBadRequestTest()
        {
            // Arrange
            var _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            var _client = _server.CreateClient();

            // Act
            var response = await _client.GetAsync("api/v1/monumenten/5");

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public async Task MonumentenPost()
        {
            // Arrange
            var _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            var _client = _server.CreateClient();

            var monument = new Monument { Id = 4, Naam = "Gert", Hoogte = 2 };
            var json = JsonConvert.SerializeObject(monument);

            // Act
            var response = await _client.PostAsync("api/v1/monumenten", new StringContent(json, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task MonumentenPostReturnsBadRequest()
        {
            // Arrange
            var _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            var _client = _server.CreateClient();

            var nietEenMonument = new { Ip = 999, Nazm = "Gert", Hoeegte = 2, pizza = "kaas" };
            var json = JsonConvert.SerializeObject(nietEenMonument);

            // Act
            var response = await _client.PostAsync("api/v1/monumenten", new StringContent(json, Encoding.UTF8, "application/json"));

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
