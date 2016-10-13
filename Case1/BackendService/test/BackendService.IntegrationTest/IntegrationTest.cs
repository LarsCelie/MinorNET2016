using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.IO;

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

            // Act
            var response = await _client.GetAsync("api/v1/cursus");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.IsTrue(!String.IsNullOrWhiteSpace(responseString));
        }
    }
}
