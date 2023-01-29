using System;
using RabbitMQ.Client;
using System.Text;
using System.Threading;
using System.Text.Json;

class Send
{
    public static void Main()
    {
        var linhaVazia = Encoding.UTF8.GetBytes("");

        var factory = new ConnectionFactory() { HostName = "localhost" };
        using(var connection = factory.CreateConnection())
        using(var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "fila1",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var rand = new Random();
            var stop = false;

            while (!stop) {
                var qtdBoletos = rand.Next(10);

                for(int i = 1; i <= qtdBoletos; i++) {
                    string message = JsonSerializer.Serialize(GeradorAleatorio.GerarBoleto());
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                    routingKey: "fila1",
                                    basicProperties: null,
                                    body: body);
                    Console.WriteLine(" [x] Enviou {0}", message, i);
                    Thread.Sleep(500);
                }

                channel.BasicPublish(exchange: "",
                                    routingKey: "fila1",
                                    basicProperties: null,
                                    body: linhaVazia);
                Console.WriteLine("");
                Thread.Sleep(2500);
            }
        }

        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
    }
}
