using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyClient
{
    class Program
    {
        private static string _connectionString = "your-connection-string";
        private static string _queueName = "your-queue-name";

        static void Main(string[] args)
        {
            // Writing to the service bus for testing purposes
            var client = QueueClient.CreateFromConnectionString(_connectionString, _queueName);
            var message = new BrokeredMessage("Testing 123");

            client.Send(message);
        }
    }
}
