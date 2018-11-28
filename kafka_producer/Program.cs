using System;
using System.Text;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using System.Collections.Generic;

namespace kafka_producer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello kafka producer...!");

            var config = new Dictionary<string, object>{
            { "bootstrap.servers", "localhost:9092" }

        };

            using (var producer = new Producer<Null, string>(config, null, new StringSerializer(Encoding.UTF8)))
            {
                string text = null;
		Console.WriteLine("Producer ready, type message below and press Enter to send it.");
                while (text != "exit")
                {
                    text = Console.ReadLine();
                    producer.ProduceAsync("hello-topic", null, text);
                }

                producer.Flush(100);

            }

        }
    }
}
