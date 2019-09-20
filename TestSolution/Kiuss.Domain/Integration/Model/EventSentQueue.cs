using System;
using System.Collections.Generic;

namespace Kiuss.Domain.Integration.Model
{
  /// <summary>
  /// Очередь отосланных событий.
  /// </summary>
  public class EventSentQueue : EventQueue
  {
    public EventSentQueue(Guid id) : base(id)
    {
      Type = EventQueueType.Sent;
    }
    public static EventSentQueue New(string name, bool isDefault = false) => new EventSentQueue(Guid.NewGuid())
    {
      Name = name,
      IsDefault = isDefault,
      Items = new List<EventQueueItem>()
    };
  }
}