using System;
using System.Collections.Generic;
using Kiuss.Domain.KiussEvents.Model;

namespace Kiuss.Domain.Integration.Model
{
  /// <summary>
  /// Интеграционное событие КиУСС.
  /// </summary>
  public class IntegrationEvent : KiussEvent
  {
    private IntegrationEvent(Guid id) : base(id)
    {
      Type = KiussEventType.Integration;
    }

    /// <summary>
    /// Тип события.
    /// </summary>
    public IntegrationEventType IntegrationEventType { get; private set; }

    /// <summary>
    /// Данные события.
    /// </summary>
    public byte[] EventData { get; private set; }

    /// <summary>
    /// Версия структуры данных, записанных в EventData.
    /// </summary>
    public string DataVersion { get; private set; }

    /// <summary>
    /// Алгоритм сжатия, примененный к данным в EventData.
    /// Null, если данные не упакованы.
    /// </summary>
    public string DataZipMethod { get; private set; }

    /// <summary>
    /// Код , примененный к данным в EventData.
    /// </summary>
    public string DataHashCode { get; private set; }


    public static IntegrationEvent New(IntegrationEventType eventType, Guid kiussModuleId, Guid kiussSectionId, byte[] eventData, string dataVersion, string dataZipMethod, string dataHashCode)
      => new IntegrationEvent(Guid.NewGuid())
      {
        Issued = DateTime.Now,
        KiussModuleId = kiussModuleId,
        KiussSectionId = kiussSectionId,
        IntegrationEventType = eventType,
        EventData = eventData,
        DataVersion = dataVersion,
        DataZipMethod = dataZipMethod,
        DataHashCode = dataHashCode
      };
  }
}
