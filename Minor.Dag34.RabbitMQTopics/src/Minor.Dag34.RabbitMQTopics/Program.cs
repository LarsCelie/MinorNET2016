using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Minor.Dag34.RabbitMQTopics
{
    public class Program
    {
        private static string routingKey = "chat.message";

        public static void Main(string[] args)
        {
            Console.WriteLine("Type your username");
            var username = Console.ReadLine();

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                // Setup
                string queueName = Setup(channel);

                // Consumer
                CreateConsumer(channel, queueName);

                // Publish
                StartPublishing(username, channel);

            }

        }

        public static string Setup(IModel channel)
        {
            channel.ExchangeDeclare("chat", ExchangeType.Fanout);
            var queueName = channel.QueueDeclare().QueueName;
            channel.QueueBind(queue: queueName, exchange: "chat", routingKey: routingKey);
            return queueName;
        }

        private static void StartPublishing(string username, IModel channel)
        {
            Console.WriteLine("You entered the chatroom, type '/exit' to leave.");
            String line;
            while ((line = Console.ReadLine()).ToLower() != "/exit")
            {
                var time = DateTime.Now.ToString("HH:mm:ss");
                var message = $"{time} {username}: {line}";

                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "chat", routingKey: routingKey, basicProperties: null, body: body);
            }
        }

        private static void CreateConsumer(IModel channel, string queueName)
        {
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += Consumer_Received;
            channel.BasicConsume(queue: queueName, noAck: true, consumer: consumer);
        }

        private static void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body;
            var message = Encoding.UTF8.GetString(body);
            var routingKey = e.RoutingKey;
            Console.WriteLine(message);
            Console.Beep(1100, 500);
        }

    }
}
