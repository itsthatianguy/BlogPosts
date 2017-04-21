using Microsoft.ServiceFabric.Services.Communication.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.ServiceBus.Messaging;
using System.Diagnostics;
using System.Fabric;

namespace TriggerService.ServiceListeners
{
    internal class ServiceBusQueueListener : ICommunicationListener
    {
        private string _queueName;
        private string _connectionString;
        private QueueClient _client;
        private Action<BrokeredMessage> _callback;

        public ServiceBusQueueListener(Action<BrokeredMessage> callback, string connectionString, string queueName)
        {
            // Set variables
            _callback = callback;
            _connectionString = connectionString;
            _queueName = queueName;
        }

        public void Abort()
        {
            // Close down
            Stop();
        }

        public Task CloseAsync(CancellationToken cancellationToken)
        {
            // Close down
            Stop();
            return Task.FromResult(true);
        }

        public Task<string> OpenAsync(CancellationToken cancellationToken)
        {
            _client = QueueClient.CreateFromConnectionString(_connectionString, _queueName);
            _client.OnMessage(message => _callback.Invoke(message));

            // Return the uri - in this case, that's just our connection string
            return Task.FromResult(_connectionString);
        }

        private void Stop()
        {
            if (_client != null && !_client.IsClosed)
            {
                _client.Close();
                _client = null;
            }
        }
    }
}
