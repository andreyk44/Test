using System.Collections.Generic;
using System.Linq;
using Kiuss.Domain.Shared.Interface;
using MediatR;

namespace Kiuss.Domain.Shared.Model
{
  public class DomainEventHolder : IDomainEventHolder
  {

    #region IEntity

    private static readonly IList<INotification> EmptyEventList = new INotification[0];

    private List<INotification> _domainEvents;
    IList<INotification> IDomainEventHolder.Events => (IList<INotification>)_domainEvents ?? new INotification[0];

    public void Add(INotification eventItem)
      => (_domainEvents ?? (_domainEvents = new List<INotification>())).Add(eventItem);

    void IDomainEventHolder.Clear() => _domainEvents?.Clear();

    bool IDomainEventHolder.Any() => _domainEvents?.Any() ?? false;

    #endregion

  }
}
