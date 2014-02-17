using System;

namespace CommandBus.Lab.Commanding
{
    public class LabCommand : ICommand
    {
        public LabCommand()
        {
            AggregateId = Guid.NewGuid();
            CorrelationId = Guid.NewGuid();
        }

        public Guid AggregateId { get; private set; }
        public Guid CorrelationId { get; private set; }
    }
}