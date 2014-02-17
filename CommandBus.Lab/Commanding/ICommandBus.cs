using System.Collections.Generic;
using System.Threading.Tasks;
using CommandBus.Lab.Infrastructure;
using CommandBus.Lab.Messaging;

namespace CommandBus.Lab.Commanding
{
    public interface ICommandBus
    {
        Task SendAsync(Envelope<ICommand> command);
        void Send(IEnumerable<Envelope<ICommand>> commands);
    }
}
