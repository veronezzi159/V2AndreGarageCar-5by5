using Models;
using Newtonsoft.Json;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using AndreGarageConsumerBank.Services;

const string _QueueName = "Bank";
var factory = new ConnectionFactory() { HostName = "localhost" };   

using(var connection = factory.CreateConnection())
{
    using (var channel = connection.CreateModel())
    {
        channel.QueueDeclare(queue: _QueueName, 
                            durable: false,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null
        );
        while (true)
        {
            
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var returnMessage = Encoding.UTF8.GetString(body);
                var bank = JsonConvert.DeserializeObject<Bank>(returnMessage);
                Bank bk = new BankService().PostBankMongo(bank).Result;
                Console.WriteLine(" Banco: " + bk.Name);
            };
            channel.BasicConsume(queue: _QueueName,
                                autoAck: true,
                                consumer: consumer
            );

            Thread.Sleep(2000);
        }
        
    }
}