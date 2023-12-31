using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

Console.WriteLine("Hello, World!");
Console.WriteLine("Welcome to the ticketing service");

var factory = new ConnectionFactory
{
    HostName = "localhost",
    UserName = "guess",
    Password = "guess",
    VirtualHost = "/"
};

var connection = factory.CreateConnection();

using var channel = connection.CreateModel();
channel.QueueDeclare(queue: "bookings",
    durable: true,
    exclusive: true);

var consumer = new EventingBasicConsumer(model: channel);

consumer.Received += (model, eventArgs) =>
{
    // Getting my byte[]
    var body = eventArgs.Body.ToArray();

    var message = Encoding.UTF8.GetString(body);

    Console.WriteLine($"New ticker processing is initiated for - {message}");
};

channel.BasicConsume(queue: "bookings",
    autoAck: true,
    consumer: consumer);

Console.ReadKey();