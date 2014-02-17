using System;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

namespace CommandBus.Lab.Messaging
{
    public interface IMessageSender
    {
        /// <summary>
        /// Sends the specified message synchronously.
        /// </summary>
        void Send(Func<BrokeredMessage> messageFactory);

        /// <summary>
        /// Sends the specified message asynchronously.
        /// </summary>
        Task SendAsync(Func<BrokeredMessage> messageFactory);
        
        /// <summary>
        /// Notifies that the sender is retrying due to a transient fault.
        /// </summary>
        event EventHandler Retrying;
    }
}