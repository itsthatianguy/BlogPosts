using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using TriggerService.ServiceListeners;
using Microsoft.ServiceBus.Messaging;
using System.Diagnostics;

namespace TriggerService
{
    /// <summary>
    /// An instance of this class is created for each service instance by the Service Fabric runtime.
    /// </summary>
    internal sealed class TriggerService : StatelessService
    {
        private string _connectionString;
        private string _queueName;

        public TriggerService(StatelessServiceContext context)
            : base(context)
        {
            var config = Context.CodePackageActivationContext.GetConfigurationPackageObject("Config");

            _connectionString = Environment.GetEnvironmentVariable("ServiceBusConnectionString");
            _queueName = Environment.GetEnvironmentVariable("ServiceBusQueueName");
        }

        /// <summary>
        /// Optional override to create listeners (e.g., TCP, HTTP) for this service replica to handle client or user requests.
        /// </summary>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            Action<BrokeredMessage> testAction = Test;
            yield return new ServiceInstanceListener(context => new ServiceBusQueueListener(testAction, _connectionString, _queueName), "StatelessService-ServiceBusQueueListener");
        }

        private void Test(BrokeredMessage message)
        {
            Debug.WriteLine(message.GetBody<string>());
        }
    }
}
