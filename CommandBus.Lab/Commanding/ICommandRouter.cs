using System;
using System.Threading.Tasks;

namespace CommandBus.Lab.Commanding
{
    public interface ICommandRouter
    {
        Func<ICommand, Task> GetHandler<T>(T command) where T : ICommand;
    }
}