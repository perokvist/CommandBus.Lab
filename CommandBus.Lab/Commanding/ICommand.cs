using System;

namespace CommandBus.Lab.Commanding
{
    public interface ICommand
    {
        Guid AggregateId { get;  }

        Guid CorrelationId { get; }
    }
}
