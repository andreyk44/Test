using System;
using System.Collections.Generic;

namespace Kiuss.Domain.Integration.Model
{
  /// <summary>
  /// Очередь входящих событий.
  /// </summary>
  public class EventInQueue : EventQueue
  {
    public EventInQueue(Guid id) : base(id)
    {
      Type = EventQueueType.Input;
    }
    public static EventInQueue New(string name, bool isDefault = false) => new EventInQueue(Guid.NewGuid())
    {
      Name = name,
      IsDefault = isDefault,
      Items = new List<EventQueueItem>()
    };
  }
}