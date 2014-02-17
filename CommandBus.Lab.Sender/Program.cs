using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using CommandBus.Lab.Commanding;
using CommandBus.Lab.Infrastructure;
using CommandBus.Lab.Messaging;

namespace CommandBus.Lab.Sender
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            var bus = new Commanding.CommandBus(new TopicSender("commands"), new JsonTextSerializer());
            Seed(bus);
        }

        static async void Seed(ICommandBus bus)
        {
            while (true)
            {
                await bus.SendAsync(new LabCommand());
                await Task.Delay(3000);
            }
        }
    }
}
