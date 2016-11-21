using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minor.Dag38.EventSender
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory { HostName ="localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("mijnhuisdier", durable: false, autoDelete: false, exclusive: false, arguments: null);
                string message = "Hello, world";
                byte[] body = Encoding.Unicode.GetBytes(message);
                channel.BasicPublish("", "mijnhuisdier", null, body);
                Console.WriteLine($"sent { message}");
            }
        }
    }
}
