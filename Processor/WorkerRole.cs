using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using CommandBus.Lab.Commanding;
using CommandBus.Lab.Infrastructure;
using CommandBus.Lab.Messaging;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;

namespace Processor
{
    public class WorkerRole : RoleEntryPoint
    {
        public override void Run()
        {
            // This is a sample worker implementation. Replace with your logic.
            Trace.TraceInformation("Processor entry point called", "Information");

            var router = new SimpleCommandRouter();
            router.Register<LabCommand>(command => Task.Run(() => Trace.TraceInformation(command.ToString()))); 
            var commandProcessor = new CommandProcessor(new SubscriptionReceiver("commands", "nodeOneSub"), router, new JsonTextSerializer());
            commandProcessor.Start();

            base.Run();
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections 
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            return base.OnStart();
        }
    }
}
