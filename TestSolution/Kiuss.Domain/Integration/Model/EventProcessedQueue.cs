using System;
using System.Collections.Generic;

namespace Kiuss.Domain.Integration.Model
{
  /// <summary>
  /// Очередь обработанных событий.
  /// </summary>
  public class EventProcessedQueue : EventQueue
  {
    public EventProcessedQueue(Guid id) : base(id)
    {
      Type = EventQueueType.Processed;
    }
    public static EventProcessedQueue New(string name, bool isDefault = false) => new EventProcessedQueue(Guid.NewGuid())
    {
      Name = name,
      IsDefault = isDefault,
      Items = new List<EventQueueItem>()
    };
  }
}