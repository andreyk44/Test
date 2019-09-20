using System;
using System.Collections.Generic;

namespace Kiuss.Domain.Integration.Model
{
  /// <summary>
  /// Очередь исходящих событий.
  /// </summary>
  public class EventOutQueue : EventQueue
  {
    public EventOutQueue(Guid id) : base(id)
    {
      Type = EventQueueType.Output;
    }
    public static EventOutQueue New(string name, bool isDefault = false) => new EventOutQueue(Guid.NewGuid())
    {
      Name = name,
      IsDefault = isDefault,
      Items = new List<EventQueueItem>()
    };
  }
}