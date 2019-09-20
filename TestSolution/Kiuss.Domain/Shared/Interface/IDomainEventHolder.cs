using System.Collections.Generic;
using MediatR;

namespace Kiuss.Domain.Shared.Interface
{
  public interface IDomainEventHolder
  {
    IList<INotification> Events { get; }
    void Add(INotification eventItem);
    void Clear();
    bool Any();
  }
}
