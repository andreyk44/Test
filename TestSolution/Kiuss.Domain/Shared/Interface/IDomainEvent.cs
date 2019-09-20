namespace Kiuss.Domain.Shared.Interface
{
  public interface IDomainEvent
  {
    IDomainEventHolder EventHolder { get; }
  }
}
