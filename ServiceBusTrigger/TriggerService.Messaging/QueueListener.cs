using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;
using System.Diagnostics;

namespace TriggerService.Messaging
{
    public class QueueListener
    {
        // Wrapper around service bus

        // Service has a queue, initialized on the openasync method
        // All this class does, is receive the messages - just needs to keep receiving

        private QueueClient _client;

        public QueueListener(string connectionString, string queueName)
        {
            _client = QueueClient.CreateFromConnectionString(connectionString, queueName);

            _client.OnMessage(message => HandleMessage(message));
        }

        public void Stop()
        {
            if (_client != null
                && !_client.IsClosed)
            {
                _client.Close();
            }
        }

        private void HandleMessage(BrokeredMessage message)
        {
            // Do whatever
            Debug.WriteLine(String.Format("Message received: {0}", message.GetBody<String>()));
        }
    }
}
