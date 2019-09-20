using System;
using System.Collections.Generic;
using Kiuss.Domain.KiussEvents.Model;
using Kiuss.Domain.Shared.Model;
using Kiuss.Domain.Structure.Model;

namespace Kiuss.Domain.Integration.Model
{
  public class EventQueueItem : ValueObject
  {
    private EventQueueItem() { }

    /// <summary>
    /// Событие КиУСС.
    /// </summary>
    public IntegrationEvent Event { get; private set; }
    /// <summary>
    /// Идентификатор события КиУСС.
    /// </summary>
    public Guid EventId { get; private set; }


    /// <summary>
    /// Технологический объект.
    /// </summary>
    public DrillingFacility Facility { get; private set; }
    /// <summary>
    /// Идентификатор технологического объекта.
    /// </summary>
    public Guid? FacilityId { get; private set; }

    /// <summary>
    /// Дата/время добавления события в очередь.
    /// </summary>
    public DateTime Added { get; private set; }

    protected override IEnumerable<object> GetAtomicValues()
    {
      yield return EventId;
      yield return FacilityId;
      yield return Added;
    }

    public static EventQueueItem New(IntegrationEvent integrationEvent, DrillingFacility facility) => new EventQueueItem()
    {
      Added = DateTime.Now,
      Event = integrationEvent,
      EventId = integrationEvent.Id,
      Facility = facility,
      FacilityId = facility?.Id
    };
  }
}