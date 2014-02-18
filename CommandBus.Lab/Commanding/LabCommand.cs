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

        public Guid AggregateId { get; set; }
        public Guid CorrelationId { get; set; }
    }
}