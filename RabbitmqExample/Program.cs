using RabbitMQ.Client;
using System;
using System.Text;
namespace RabbitmqExample
{
    public class Program
    {
        static void Main(string[] args)
        {
            for(int i = 0; i < 10; i++) {

                MesajGonder();
            }
        }
        public  static void MesajGonder()
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://peorsfgb:uTDp6Yxo5VUu0_cec-CqaSboXY0ZpUGX@toad.rmq.cloudamqp.com/peorsfgb");
            var connection= factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare("mesaj-kuyruk",true,false,false);
            var mesaj = "merhaba ben ali can yücel";
            var body=Encoding.UTF8.GetBytes(mesaj);
            Console.ReadKey();

        }
    }
}