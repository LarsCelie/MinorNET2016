using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag34.RabbitMQTopics.Test
{
    [TestClass]
    public class TestProgram
    {
        [TestMethod]
        public static void MyTestMethod()
        {
            var mock = new Mock<IModel>(MockBehavior.Strict);

            Program.Setup(mock.Object);
            
        }
    }
}
