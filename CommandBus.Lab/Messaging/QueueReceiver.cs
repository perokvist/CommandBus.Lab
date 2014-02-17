using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

namespace CommandBus.Lab.Messaging
{
    public class QueueReceiver : IMessageReceiver
    {
        private readonly QueueClient _client;

        public QueueReceiver(string connectionString, string path)
        {
            _client = QueueClient.CreateFromConnectionString(connectionString, path, ReceiveMode.PeekLock);
        }

        public void Start(Func<BrokeredMessage, Task> messageHandler)
        {
            var options = new OnMessageOptions {MaxConcurrentCalls = 1};
            //_client.RetryPolicy = new RetryExponential();
            options.ExceptionReceived += (sender, args) => OnException(sender as BrokeredMessage, (dynamic) args.Exception);
            _client.OnMessageAsync(messageHandler, options);
        }

        private void OnException(BrokeredMessage message, SerializationException exception)
        {
            throw new NotImplementedException();
            //message.DeadLetterAsync()
        }


        private void OnException(object sender, Exception exception)
        {
            if (exception != null)
                throw exception;
        }

        public Task StopAsync()
        {
            return _client.CloseAsync();
        }
    }
}