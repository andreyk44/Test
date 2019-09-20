using System;
using System.Collections.Generic;
using System.Linq;

using Kiuss.Domain.Shared.Model;
using Kiuss.Domain.Structure.Model;

namespace Kiuss.Domain.Integration.Model
{
  /// <summary>
  /// Очередь событий.
  /// </summary>
  public class EventQueue : EntityBase<Guid>
  {
    protected EventQueue(Guid id) : base (id) { }

    /// <summary>
    /// Название очереди.
    /// </summary>
    public string Name { get; protected set; }

    /// <summary>
    /// Тип очереди.
    /// </summary>
    public EventQueueType Type { get; protected set; }

    /// <summary>
    /// Признак очереди по умолчанию.
    /// </summary>
    public bool IsDefault{ get; protected set; }

    /// <summary>
    /// Элементы очереди.
    /// </summary>
    public IList<EventQueueItem> Items { get; protected set; }

    public void Enqueue(IntegrationEvent integrationEvent, DrillingFacility facility = null)
    {
      Items.Add(EventQueueItem.New(integrationEvent, facility));
    }

    public EventQueueItem DequeueItem()
    {
      if (!Items.Any())
        return null;
      var firstItem = Items.OrderBy(e => e.Added).First();
      Items.Remove(firstItem);
      return firstItem;
    }

  }
}
