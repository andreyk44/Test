using System.Threading.Tasks;
using Kiuss.Domain.Integration.Model;
using Kiuss.Domain.KiussEvents.Model;

namespace Kiuss.Domain.Integration.Interfaces
{
  public interface IIntegrationRepositoryCommand
  {
    /// <summary>
    /// Возвращает очередь "по умолчанию" для исходящих событий.
    /// </summary>
    /// <returns></returns>
    Task<EventOutQueue> GetDefaultOutQueue();

    /// <summary>
    /// Возвращает очередь "по умолчанию" для отосланных событий.
    /// </summary>
    /// <returns></returns>
    Task<EventSentQueue> GetDefaultSentQueue();

    /// <summary>
    /// Возвращает очередь "по умолчанию" для входящих событий.
    /// </summary>
    /// <returns></returns>
    Task<EventInQueue> GetDefaultInQueue();

    /// <summary>
    /// Возвращает очередь "по умолчанию" для обработанных событий.
    /// </summary>
    /// <returns></returns>
    Task<EventProcessedQueue> GetDefaultProcessedQueue();


    /// <summary>
    /// Возвращает событие, ассоциированное с элементом очереди.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    Task<IntegrationEvent> FetchEventFromQueueItem(EventQueueItem item);

    /// <summary>
    /// Сохранить все изменения в хранилище данных.
    /// </summary>
    /// <returns></returns>
    Task CommitChanges();

  }
}
