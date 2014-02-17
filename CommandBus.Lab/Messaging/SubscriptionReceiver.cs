using System;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

namespace CommandBus.Lab.Messaging
{
    public class SubscriptionReceiver : IMessageReceiver
    {
        private readonly SubscriptionClient _client;
        public SubscriptionReceiver(string topic, string subscription)
        {
            var messagingFactory = MessagingFactory.Create();
            _client = messagingFactory.CreateSubscriptionClient(topic, subscription);
        }

        public void Start(Func<BrokeredMessage, Task> messageHandler)
        {
            var options = new OnMessageOptions {MaxConcurrentCalls = 1};
            _client.OnMessageAsync(messageHandler, options);
        }

        public Task StopAsync()
        {
            return _client.CloseAsync();
        }
    }
}