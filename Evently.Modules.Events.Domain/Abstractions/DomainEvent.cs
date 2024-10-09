namespace Evently.Modules.Events.Domain.Abstractions;

public abstract class DomainEvent : IDomainEvent
{
    protected DomainEvent(Guid id, DateTime occurredOnUtc)
    {
        Id = id;
        OccurredOnUtc = occurredOnUtc;
    }
    protected DomainEvent()
    {
        Id = Guid.NewGuid();
        OccurredOnUtc = DateTime.UtcNow;
    }


    public Guid Id { get; init; }
    public DateTime OccurredOnUtc { get; init; }
}
