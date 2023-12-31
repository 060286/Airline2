using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace FormulaAirline.API.Services;

public class MessageProducer : IMessageProducer
{
    public void SendingMessage<T>(T message)
    {
        // Initialize configuration
        var factory = new ConnectionFactory
        {
            HostName = "localhost",
            UserName = "guess",
            Password = "guess",
            VirtualHost = "/"
        };

        // Creating connection.
        var connection = factory.CreateConnection();

        using var channel = connection.CreateModel();
        // channel.QueueDeclare(queue: "bookings",
        //     durable: true,
        //     exclusive: true);

        // Able to take json.
        var jsonString = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(jsonString);

        // Sending it.
        channel.BasicPublish(exchange: string.Empty,
            routingKey: "bookings",
            body: body);
    }
}