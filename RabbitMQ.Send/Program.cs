using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(
    queue: "god's in his heaven, all's right with the world",
    durable: false,
    exclusive: false,
    autoDelete: false,
    arguments: null
);

const string message = "Hello there!";

var body = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(
    exchange: string.Empty,
    routingKey: "hello",
    basicProperties: null,
    body: body
);

Console.WriteLine($"x sent {message}");
Console.WriteLine("Press enter to exit");

Console.ReadLine();
