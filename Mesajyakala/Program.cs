using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Runtime.CompilerServices;
using System.Text;

namespace NesajYakala
{
    public class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://peorsfgb:uTDp6Yxo5VUu0_cec-CqaSboXY0ZpUGX@toad.rmq.cloudamqp.com/peorsfgb");
            using  var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare("mesaj-kuryk", true, false, false);
            var consumer=new EventingBasicConsumer(channel);
            channel.BasicConsume("mesaj-kuyruk",true,consumer);
            consumer.Received += Consumer_Received;
            Console.ReadKey();
        }
        private static void Consumer_Received(object sender, BasicDeliverEventArgs e) {
            Console.WriteLine(Encoding.UTF8.GetString(e.Body.ToArray()));

        }
    }
}