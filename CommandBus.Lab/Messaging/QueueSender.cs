using System;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

namespace CommandBus.Lab.Messaging
{
    public class QueueSender : IMessageSender
    {
        private readonly QueueClient _client;

        public QueueSender(string connectionString, string path)
        {
            _client = QueueClient.CreateFromConnectionString(connectionString, path, ReceiveMode.PeekLock);
            //client.RetryPolicy = new RetryExponential();
        }

        public void Send(Func<BrokeredMessage> messageFactory)
        {
            _client.Send(messageFactory());
        }

        public Task SendAsync(Func<BrokeredMessage> messageFactory)
        {
            return _client.SendAsync(messageFactory());
        }

        public event EventHandler Retrying;
    }
}