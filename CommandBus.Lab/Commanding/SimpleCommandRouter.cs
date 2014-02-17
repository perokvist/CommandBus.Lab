using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommandBus.Lab.Commanding
{
    public class SimpleCommandRouter : ICommandRouter
    {
        private readonly IDictionary<Type, Func<ICommand, Task>> _routes = new Dictionary<Type, Func<ICommand, Task>>();

        public void Register<T>(Func<T,Task> handler)
            where T : ICommand
        {
            _routes.Add(typeof(T),command => handler((T)command));
        }

        public Func<ICommand, Task> GetHandler<T>(T command) where T : ICommand
        {
            return _routes[typeof (T)];
        }
    }
}